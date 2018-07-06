create procedure [SqlT].[SynColumnGroupMemberships]
(
	@ServerName sysname, 
	@DatabaseName sysname, 
	@Assignments [SqlT].[ColumnGroupMember] readonly
) as

	declare @LoadTS datetime2(0) = getdate();

	with Dst as
	(
		select 
			* 
		from 
			[SqlStore].[ColumnGroupMembership] 
		where 
			ServerName = @ServerName 
		and DatabaseName = @DatabaseName

	)
	merge into Dst using @Assignments as Src on
		Src.ServerName = @ServerName
	and Src.DatabaseName = @DatabaseName
	and	Src.ObjectSchema = Dst.ObjectSchema
	and Src.ObjectName = Dst.ObjectName
	and Src.ColumnName = Dst.ColumnName
	and Src.GroupTypeName = Dst.GroupTypeName
	when not matched then insert
	(
		ServerName,
		DatabaseName,
		ObjectSchema,
		ObjectName,
		ColumnName,
		GroupTypeName
	)
	values 
	(
		Src.ServerName,
		Src.DatabaseName,
		Src.ObjectSchema,
		Src.ObjectName,
		Src.ColumnName,
		Src.GroupTypeName
	)
	when not matched by source then delete;
