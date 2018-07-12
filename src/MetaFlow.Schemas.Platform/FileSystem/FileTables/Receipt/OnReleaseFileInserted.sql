create trigger [PF].[OnReleaseFileInserted] ON  [PF].[SystemDistribution] 
	after insert as 
begin
    set nocount on;    	

	declare @identifers [T0].[FileStreamIdentifier];
	
	insert @identifers
		select 
			row_number() over(order by stream_id desc),
			stream_id 
		from 
			inserted			

	declare @max int = (select max(row_id) from @identifers)
	declare @current int = 1
	while(@current <= @max)
	begin
		declare @dialog uniqueidentifier;	
		declare @stream_id uniqueidentifier = (select stream_id from @identifers where row_id = @current);
		begin dialog @dialog
			from service FileListenerService   
			to service 'FileListenerService'
			on contract FileListener
		with encryption = off;
	
		send on conversation @dialog
				message type FileReceived(@stream_id);	
		set @current = @current + 1
	end
            
end 
GO

