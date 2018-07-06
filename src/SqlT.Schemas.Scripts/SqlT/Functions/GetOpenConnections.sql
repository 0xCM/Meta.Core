﻿create function [SqlT].[GetOpenConnections]() returns table as return
	SELECT 
		DB_NAME(dbid) as DBName, 
		COUNT(dbid) as NumberOfConnections,
		loginame as LoginName
	FROM
		sys.sysprocesses
	WHERE 
		dbid > 0
	GROUP BY 
		dbid, loginame
