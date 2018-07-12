
create service FileListenerService
	on queue [PF].[FileReceiptQueue](FileListener)
GO



