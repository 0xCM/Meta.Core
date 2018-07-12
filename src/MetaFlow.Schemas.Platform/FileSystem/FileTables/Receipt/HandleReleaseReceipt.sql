create procedure [PF].[HandleReleaseReceipt] as
	set xact_abort on;
	
	declare @messageBody varbinary(max)
	declare @messageType sysname
	declare @dialog uniqueidentifier;		

	receive top(1)
		@messageType = message_type_name,
		@messageBody = message_body,
		@dialog = conversation_handle
	from 
		[PF].[FileReceiptQueue]
	

	if (@messageType=N'http://schemas.microsoft.com/SQL/ServiceBroker/EndDialog')
		end conversation @dialog;
	else if(@dialog is not null)
	begin		
		begin transaction
		declare @stream_id uniqueidentifier = cast(@messageBody as uniqueidentifier);
		insert [PF].[ReceivedFile]
		(
			FileId,
			[FileName],
			[FileSize],
			[ReceivedTime],
			[LastWriteTime],
			[ReceiptPath]
		)
		select 
			FileId = ft.stream_id,
			[FileName] = ft.[name],
			FileSize = cached_file_size, 
			ReceivedTime = creation_time,
			LastWriteTime = last_write_time,
			ReceiptPath = FileTableRootPath() + file_stream.GetFileNamespacePath()			
		from 
			 [PF].[SystemDistribution] ft 
		where 		
			ft.stream_id = @stream_id
		and ft.is_directory = 0            

		end conversation @dialog;
		
		commit transaction
	end
GO
