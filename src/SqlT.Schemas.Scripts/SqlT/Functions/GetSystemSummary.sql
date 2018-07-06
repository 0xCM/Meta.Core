create function [SqlT].[GetSystemSummary]() returns table as return
select 
	MetricName = 'Database Size (GB)',  
	MetricValue = (select (size*8 /1024) /1000 from sys.database_files where type = 0)
