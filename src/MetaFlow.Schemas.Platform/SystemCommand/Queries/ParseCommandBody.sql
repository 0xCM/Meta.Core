create function [WF].[ParseCommandBody](@TaskId bigint) returns table as return
	with Arguments as
	(
		select 
			x.TaskId,
			json_query(x.CommandBody, '$.Arguments') as ArgumentJson 
		from 
			[WF].[SystemTaskQueue] x 
		where
			x.TaskId = @TaskId
	)
	select 	
		x.TaskId,
		r.*
	from 
		Arguments x cross apply [WF].[ParseCommandArgument](x.ArgumentJson) r
	
		

