create procedure [SqlT].[SynColumnRoleAssignments]
(
	@ServerName sysname, 
	@DatabaseName sysname, 
	@Assignments [SqlT].[ColumnRoleAssignment] readonly
) as

	declare @LoadTS datetime2(0) = getdate();

	with Dst as
	(
		select 
			* 
		from 
			[SqlStore].[ColumnRoleAssignment] 
		where 
			ServerName = @ServerName and DatabaseName = @DatabaseName

	)
	merge into Dst using @Assignments as Src on
		Src.ObjectSchema = Dst.ObjectSchema
	and Src.ObjectName = Dst.ObjectName
	and Src.ColumnName = Dst.ColumnName
	and Src.ServerName = @ServerName
	and Src.DatabaseName = @DatabaseName
	when not matched then insert
	(
		ServerName,
		DatabaseName,
		ObjectName,
		ColumnName,
		ColumnRole
	)
	values 
	(
		Src.ServerName,
		Src.DatabaseName,
		Src.ObjectName,
		Src.ColumnName,
		Src.ColumnRole
	)
	when matched and not exists
	(
		select Src.ColumnRole intersect select Dst.ColumnRole
	)
	then update set
		Dst.ColumnRole = Src.ColumnRole,
		Dst.UpdateTS = @LoadTS
	when not matched by source then delete;

	

	
