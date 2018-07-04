--https://www.codeproject.com/Articles/584865/SQL-Server-FileTable-My-first-experience
create trigger CommandInserted ON  [Platform].[Commands] 
	after insert as 
begin
    set nocount on;
    declare
		@dialog uniqueidentifier,
        @msg xml,
        @insertCount int,
        @counter int = 0,
        @pageSize int = 28;
    	
	select @insertCount = COUNT(*) from inserted;
    while (@counter < @insertCount)
    BEGIN
        set @msg =   
			(select stream_id from inserted
				order by stream_id asc
                offset @counter rows
                fetch next @pageSize rows only
				for xml raw, 
					root(N'rows'), elements);
            
        set @counter = @counter + @pageSize;
        begin dialog conversation @dialog
        from service PlatformCommandService
        to service N'PlatformCommandService'
        on contract CommandReceiptContract
        with encryption = off;
        send on conversation 
			@dialog message type CommandSubmission(@msg);
    END
END 

GO

create procedure [Platform].[HandleCommandSubmission] as
begin
    DECLARE 
		@messageBody varbinary(max),
        @messageType sysname,
        @dialog uniqueidentifier;
    while (1 = 1)
    begin
        begin tran;
			begin try;
            waitfor
            (
                receive top (1)
                    @messageType = message_type_name,
                    @messageBody = message_body,
                    @dialog = conversation_handle
                FROM 
					[Platform].[CommandSubmissionQueue]
            ), timeout 1000;

            if (@@rowcount=0)
            begin
                if    (@@trancount>0)
                begin
                    commit tran;
                end
                break;
            end
            if    (@messageType=N'CommandSubmission')
            begin
				/*
				<rows>
				  <row>
					<stream_id>AF520FD5-E9AD-E211-BF90-18037345B7C3</stream_id>
				  </row>
				  <row>
					<stream_id>B4C457A4-622B-482D-AA24-B6C8A4C712F3</stream_id>
				  </row>
				</rows>
				*/
                declare @messageXml xml = convert(xml, @messageBody), @streamIds  [Platform].[FileStreamReceipt];
                insert @streamIds (stream_id)
                select    
					T.c.value(N'.[1]', N'uniqueidentifier')
                from    
					@messageXml.nodes(N'/rows/row/stream_id') T(c);

                exec [Platform].[HandleFileStreamReceipts] @streamIds=@streamIds;
                send on conversation 
					@dialog message type CommandSubmisionResponse;
				end conversation @dialog;
          end
                else if (@messageType=N'http://schemas.microsoft.com/SQL/ServiceBroker/EndDialog')
                begin
                    end conversation @dialog;
                end
                else if (@messageType=N'http://schemas.microsoft.com/SQL/ServiceBroker/Error')
                begin
                    -- Log the received error into ERRORLOG and system Event Log (eventvwr.exe)
                    declare 
						@dialog_string nvarchar(100) = convert(nvarchar(64), @dialog),
                        @error_message nvarchar(4000)= convert(nvarchar(4000), @messageBody);                
                    raiserror (N'Conversation %s was ended with error %s', 
						10, 1, @dialog_string, @error_message) with log;
                    end conversation @dialog;
                end
                commit tran;
        end try
        begin catch
            select    
				ErrorNumber = error_number(),
                ErrorSeverity = error_severity(),
                ErrorState = error_state(),
                ErrorProcedure = error_procedure(),
                ErrorLine = error_line(),
                ErrorMessage = error_message();
            declare    
				@ErrNum int = error_number(),
                @ErrMsg nvarchar(4000) = error_message();
            if (@dialog is not null)
            begin
                end conversation @dialog with 
					error = @ErrNum 
					description = @ErrMsg;
            end
            if    (@@TRANCOUNT>0)
            begin
                rollback tran;
            end
        end catch;
    end
end

GO

create procedure [Platform].[HandleFileStreamReceipts](@streamIds [Platform].[FileStreamReceipt] readonly)
	as
BEGIN
    SET    NOCOUNT ON;
    DECLARE    @destsByYearMonth    TABLE
        ([Year]            int
        ,[Month]        int
        ,YearName        AS (Format([Year], N'0000'))
        ,[MonthName]        AS (Format([Month], N'00'))
        ,YearFullName        nvarchar(4000)--AS 
        ,MonthFullName        nvarchar(4000)--AS 
        ,AddYear        bit DEFAULT(0)
        ,AddMonth        bit DEFAULT(0)
        ,YearPath        hierarchyid
        ,MonthPath        hierarchyid
        ,PRIMARY KEY([Year], [Month]));
    -- Determine the Years and Months from the creation date of the specified records
    INSERT    @destsByYearMonth ([Year], [Month])
    SELECT    DISTINCT Year(creation_time), Month(creation_time)
    FROM    @streamIds tvp
    JOIN    [myFileTable] ft ON tvp.stream_id=ft.stream_id;
    UPDATE    @destsByYearMonth
    SET    YearFullName = FileTableRootPath(N'myFileTable') + N'\' + YearName;
    UPDATE    @destsByYearMonth
    SET    MonthFullName = YearFullName + N'\' + MonthName;
    -- Retrieving the path_locator for the "Year" directories
    UPDATE    @destsByYearMonth
    SET    YearPath = GetPathLocator(YearFullName)
    FROM    [myFileTable];
    IF    (EXISTS(SELECT TOP (1) 1 FROM @destsByYearMonth WHERE YearPath IS NULL))
    BEGIN
        -- Generating new path_locators for new "Year" directories
        UPDATE    @destsByYearMonth
        SET    AddYear = 1,
            YearPath = dbo.fnGetNewPathLocator(newid(), hierarchyid::GetRoot())
        WHERE    YearPath IS NULL;
        -- Inserting new "Year" directories
        INSERT    [myFileTable](name, path_locator, is_directory)
        SELECT    YearName, YearPath, 1
        FROM    @destsByYearMonth
        WHERE    AddYear = 1;
    END
    -- Retrieving the path_locator for the "Month" directories
    UPDATE    @destsByYearMonth
    SET    MonthPath = GetPathLocator(MonthFullName)
    FROM    [myFileTable];
    IF (EXISTS(SELECT TOP (1) 1 FROM @destsByYearMonth WHERE MonthPath IS NULL))
    BEGIN
        -- Generating new path_locators for new "Month" directories
        UPDATE    @destsByYearMonth
        SET    AddMonth = 1,
            MonthPath = dbo.fnGetNewPathLocator(newid(), YearPath)
        WHERE    MonthPath IS NULL;
        -- Inserting new "Month" directories
        INSERT    [myFileTable](name, path_locator, is_directory)
        SELECT    [MonthName], MonthPath, 1
        FROM    @destsByYearMonth
        WHERE    AddMonth = 1;
    END
    UPDATE    d
    SET    path_locator=d.path_locator.GetReparentedValue(d.parent_path_locator, i.MonthPath)
    FROM    @streamIds s
    JOIN    [myFileTable] d ON s.stream_id=d.stream_id
    JOIN    @destsByYearMonth i ON Year(creation_time)=i.[Year] AND Month(creation_time)=i.[Month];
END
GO

CREATE FUNCTION [dbo].[fnGetNewPathLocator] 
    (@child uniqueidentifier
    ,@parent hierarchyid = NULL)
RETURNS    hierarchyid
AS
BEGIN
    DECLARE    @result hierarchyid,
        @binId binary(16) = CONVERT(binary(16), @child);
    SELECT @result = hierarchyid::Parse
        (
            COALESCE(@parent.ToString(), N'/') +
            CONVERT(nvarchar, CONVERT(bigint, SUBSTRING(@binId, 1, 6))) + N'.' +
            CONVERT(nvarchar, CONVERT(bigint, SUBSTRING(@binId, 7, 6))) + N'.' +
            CONVERT(nvarchar, CONVERT(bigint, SUBSTRING(@binId, 13, 4))) + N'/'
        );
    RETURN @result;
END