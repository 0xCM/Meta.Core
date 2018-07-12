create procedure [PF].[LogFileReceipt](@Receipts [T0].[FileReceipt] readonly) as
	set nocount on
	set xact_abort on
	
	declare 
		@LoadTS datetime2(0) = getdate(),
		@LoadCT int = 0,
		@StepName nvarchar(250) = object_name(@@procid),
		@Msg nvarchar(250);

	set @Msg = concat('Executing ', @StepName);	
	raiserror(@Msg, 0, 1) with nowait;


	insert [PF].[FileReceiptLog]
	(
		 HostId,
		 FileId,
		 [FileName],
		 FileType,
		 ReceiptPath,
		 WrittenTS,
		 ReceiptTS,
		 LoggedTS
	)	
	select
		 HostId,
		 FileId,
		 [FileName],
		 FileType,
		 ReceiptPath,
		 WrittenTS,
		 ReceiptTS,
		 @LoadTS
	from
		@Receipts


	set @Msg = concat('Executing ', @StepName, ' @LoadCT=',  @LoadCT);	
	raiserror(@Msg, 0, 1) with nowait;
	
	return @LoadCT;

	
