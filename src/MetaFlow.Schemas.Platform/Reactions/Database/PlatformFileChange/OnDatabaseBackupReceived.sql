create trigger  [PF].[OnDatabaseBackupReceived]
	on [PF].[DatabaseBackup] after insert as	

	set nocount, xact_abort on;   
	
	declare @Receipts [T0].[FileReceipt]
	insert @Receipts
	(
		 HostId,
		 FileId,
		 [FileName],
		 FileType,
		 ReceiptPath,
		 WrittenTS,
		 ReceiptTS
	)
	select 
		HostId = [PF].[SqlNodeId](),
		FileId = stream_id,
		[FileName] = [name],
		FileType = 'DatabaseBackup',
		ReceiptPath = FileTableRootPath() 
			+ file_stream.GetFileNamespacePath(),
		WrittenTS = last_write_time,
		ReceiptTS = creation_time
	from 
		inserted 

	declare @ReceiptCount int; 
	exec @ReceiptCount = [PF].[LogFileReceipt] @Receipts;

