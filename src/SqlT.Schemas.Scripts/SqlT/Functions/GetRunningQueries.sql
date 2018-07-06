create function [SqlT].[GetRunningQueries]() returns table as return
--Taken from: http://stackoverflow.com/questions/10767676/currently-running-queries-in-sql-server
	select   
		 SPID       = er.session_id
		,[Status]         = ses.[status]
		,[Login]        = ses.login_name
		,Host           = ses.host_name
		,BlkBy          = er.blocking_session_id
		,DBName         = DB_Name(er.database_id)
		,CommandType    = er.command
		,ObjectName     = OBJECT_NAME(st.objectid)
		,CPUTime        = er.cpu_time
		,StartTime      = er.start_time
		,TimeElapsed    = CAST(GETDATE() - er.start_time AS TIME)
		,SQLStatement   = st.text
	FROM    
		sys.dm_exec_requests er 
			outer apply sys.dm_exec_sql_text(er.sql_handle) st
		left join sys.dm_exec_sessions ses on 
			ses.session_id = er.session_id	
		left join sys.dm_exec_connections con
			ON con.session_id = ses.session_id
	where   
		st.text is not null