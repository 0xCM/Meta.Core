create function CommandExec.GetSubmissionArguments(@CommandName nvarchar(250)) returns table as return
with Arguments as
(
	select 
		x.SubmissionId,
		x.CommandName,
		x.CommandSpecName,
		x.EnqueuedTime,
		x.CorrelationToken,
		json_query(x.CommandJson, '$.Arguments') as ArgumentJson 
	from 
		CommandExec.CommandSubmission x 
)
select 	
	x.SubmissionId,
	x.CommandName,
	x.CommandSpecName,
	x.EnqueuedTime,
	r.*
from 
	Arguments x cross apply CommandExec.ParseCommandArguments(x.ArgumentJson) r

