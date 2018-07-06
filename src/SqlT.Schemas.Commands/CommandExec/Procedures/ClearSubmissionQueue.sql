create procedure [CommandExec].ClearSubmissionQueue(@CommandName nvarchar(250) = null) as
begin
	if @CommandName is null
		truncate table [CommandExec].[CommandSubmission];
	else
		delete [CommandExec].[CommandSubmission] where CommandName = @CommandName
end

