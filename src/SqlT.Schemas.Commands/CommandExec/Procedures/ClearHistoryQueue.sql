create procedure [CommandExec].ClearHistoryQueue(@CommandName nvarchar(250) = null) as
begin
	if @CommandName is null
		truncate table [CommandExec].[CommandHistory];
	else
		delete [CommandExec].[CommandHistory] where CommandName = @CommandName
end

