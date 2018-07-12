create procedure [PF].[PurgeFileReceiptQueue] as
	set xact_abort on
	set nocount on

	begin transaction
	
		declare @handle uniqueidentifier;
		while(exists (select top(1) * from [PF].[FileReceiptQueue]))
		begin
			set @handle = 
				(select top(1) conversation_handle 
				from 
					[PF].[FileReceiptQueue]
				)
			end conversation @handle with cleanup    
		end
	
	commit transaction
Go
