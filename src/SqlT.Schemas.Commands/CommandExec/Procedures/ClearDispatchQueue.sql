create procedure [CommandExec].ClearDispatchQueue(@CommandName nvarchar(250) = null) as
begin
	if @CommandName is null
		truncate table [CommandExec].[CommandDispatch];
	else
		delete [CommandExec].[CommandDispatch] where CommandName = @CommandName
end

