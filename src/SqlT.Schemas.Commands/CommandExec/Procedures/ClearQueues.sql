create procedure CommandExec.ClearQueues(@CommandName nvarchar(250) = null) as 
begin
	set xact_abort on
	begin transaction
		exec CommandExec.ClearSubmissionQueue @CommandName
		exec CommandExec.ClearDispatchQueue @CommandName
		exec CommandExec.ClearHistoryQueue @CommandName
	commit transaction
end