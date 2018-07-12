create function  [PF].[UnclassifiedDatabases]() returns table as return
	select 
		s.SqlNodeId,
		DatabaseType = 'None',
		DatabaseName = db.[name],
		IsModel = cast(0 as bit),
		IsRestore = cast(0 as bit)
	from 
		sys.databases db inner join [PF].[ExecutingServer] s on s.SqlNodeId = s.SqlNodeId

	where 
		db.[name] not in (select DatabaseName from [PF].[HostDatabase])



		
	