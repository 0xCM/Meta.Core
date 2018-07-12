create procedure [PF].[PublishFileReceipt](@MessageContent nvarchar(max)) as
begin
	declare @dialog uniqueidentifier;	
	begin dialog @dialog
			from service FileListenerService   
			to service 'FileListenerService'
			on contract FileListener
			with
				encryption = off;
	send on conversation @dialog
			message type FileReceived(@MessageContent);	
end
GO
