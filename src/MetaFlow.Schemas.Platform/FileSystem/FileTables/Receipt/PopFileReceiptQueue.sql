create procedure [PF].[PopFileReceiptQueue] as
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
			declare  @messageXml xml = convert(xml, @messageBody)
			declare	@streamIds  [T0].[FileStreamIdentifier];

			insert @streamIds (stream_id)
				select T.c.value(N'.[1]', N'uniqueidentifier')
				from @messageXml.nodes(N'/rows/row/stream_id') T(c);
			exec [PF].[ProcessReleases] @streamIds;
			
			end conversation @dialog;
		commit transaction
	end	
GO
