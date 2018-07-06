create function [SqlT].[GetIndexCreationProgress](@SessionId int) returns table as return
--Adapted from http://dba.stackexchange.com/questions/139191/sql-server-how-to-track-progress-of-create-index-command
--Must enable profiling for this to work - [SqlT].[EnableStatisticsProfiling]
	with agg AS
	(
		select 
			RowsProcessed = sum(qp.[row_count]),
			TotalRows = sum(qp.[estimate_row_count]),
			ElapsedMS = MAX(qp.last_active_time) - MIN(qp.first_active_time),
			CurrentStep =max(iif(qp.[close_time] = 0 AND qp.[first_row_time] > 0, [physical_operator_name], N'<Transition>'))				
		from 
			sys.dm_exec_query_profiles qp
		where 
			qp.physical_operator_name in (N'Table Scan', N'Clustered Index Scan', N'Sort')
		and qp.session_id = coalesce(@SessionId, qp.[session_id])
	), comp AS
	(
		 select 
			*,
			RowsLeft = ([TotalRows] - [RowsProcessed]),
			ElapsedSeconds =	([ElapsedMS] / 1000.0) 
		 from   
			agg
	)
	select 
		CurrentStep,
		TotalRows,
		RowsProcessed,
		RowsLeft,
		CONVERT(DECIMAL(5, 2),
				(([RowsProcessed] * 1.0) / [TotalRows]) * 100) AS [PercentComplete],
		[ElapsedSeconds],
		(([ElapsedSeconds] / [RowsProcessed]) * [RowsLeft]) AS [EstimatedSecondsLeft],
		DATEADD(SECOND,
				(([ElapsedSeconds] / [RowsProcessed]) * [RowsLeft]),
				GETDATE()) AS [EstimatedCompletionTime]
	FROM   comp;

	GO
