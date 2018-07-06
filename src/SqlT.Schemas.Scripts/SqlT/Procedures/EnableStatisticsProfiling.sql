create procedure [SqlT].[EnableStatisticsProfiling] as
	set statistics profile on;
	select @@SPID as SPID
