create procedure [SqlT].[SyncTables]
(
	@ServerName nvarchar(128), 
	@DatabaseName nvarchar(128), 
	@Tables [SqlT].[TableDescription] readonly, 
	@Columns [SqlT].[TableColumn] readonly
) as
	set nocount on;
	set xact_abort on;

	begin transaction;
	
		with Dst as
		(
			select 
				* 
			from 
				[SqlStore].[Table] 
			where 
				ServerName = @ServerName 
			and DatabaseName = @DatabaseName
		)
		merge into Dst 
			using @Tables as Src on
				Src.SchemaName = Dst.SchemaName
			and Src.TableName = Dst.TableName
		when not matched then insert
		(
			ServerName,
			DatabaseName,
			SchemaName,
			TableName,
			FileGroupName,
			Documentation
		)
		values
		(
			Src.ServerName,
			Src.DatabaseName,
			Src.SchemaName,
			Src.TableName,
			Src.FileGroupName,
			Src.Documentation
		)
		when matched and not exists
		(
			select
		
				Src.FileGroupName,
				Src.Documentation

			intersect

			select

				Dst.FileGroupName,
				Dst.Documentation
		)
		then update set
			Dst.FileGroupName = Src.FileGroupName,
			Dst.Documentation = Src.Documentation
		when not matched by source then delete;
		

		with Dst as
		(
			select 
				* 
			from 
				[SqlStore].[TableColumn] 
			where 
				ServerName = @ServerName 
			and DatabaseName = @DatabaseName
		)
		merge into Dst using @Columns as Src on
			Dst.SchemaName = Src.SchemaName
		and Dst.TableName = src.TableName
		and Dst.ColumnName = src.ColumnName
		when not matched then insert
		(
			ServerName,
			DatabaseName,
			SchemaName,	
			TableName,
			ColumnName,
			ColumnId,
			ColumnPosition,
			DataTypeName,
			IsNullable,
			IsIdentity,
			[Length],
			[Precision],
			Scale,
			ComputationExpression,
			ComputationPersisted,
			ColumnRole,
			Documentation
		)	
		values
		(
			Src.ServerName,
			Src.DatabaseName,
			Src.SchemaName,	
			Src.TableName,
			Src.ColumnName,
			Src.ColumnId,
			Src.ColumnPosition,
			Src.DataTypeName,
			Src.IsNullable,
			Src.IsIdentity,
			Src.[Length],
			Src.[Precision],
			Src.Scale,
			Src.ComputationExpression,
			Src.ComputationPersisted,
			Src.ColumnRole,
			Src.Documentation
		)
		when matched and not exists
		(

			select
				Src.ColumnId,
				Src.ColumnPosition,
				Src.DataTypeName,
				Src.IsNullable,
				Src.IsIdentity,
				isnull(Src.[Length],0),
				isnull(Src.[Precision],0),
				isnull(Src.Scale,0),
				isnull(Src.ComputationExpression,''),
				isnull(Src.ComputationPersisted,0),
				isnull(Src.ColumnRole,0),
				isnull(Src.Documentation,0)

			intersect

			select
				Dst.ColumnId,
				Dst.ColumnPosition,
				Dst.DataTypeName,
				Dst.IsNullable,
				Dst.IsIdentity,
				isnull(Dst.[Length],0),
				isnull(Dst.[Precision],0),
				isnull(Dst.Scale,0),
				isnull(Dst.ComputationExpression,''),
				isnull(Dst.ComputationPersisted,0),
				isnull(Dst.ColumnRole,0),
		    	isnull(Dst.Documentation,0)
		
		)
		then update set
			Dst.ColumnId = Src.ColumnId,
			Dst.ColumnPosition = Src.ColumnPosition,
			Dst.DataTypeName = Src.DataTypeName,
			Dst.IsNullable = Src.IsNullable,
			Dst.IsIdentity = Src.IsIdentity,
			Dst.[Length] = Src.[Length],
			Dst.[Precision] = Src.[Precision],
			Dst.Scale = Src.Scale,
			Dst.ComputationExpression = Src.ComputationExpression,
			Dst.ComputationPersisted = Src.ComputationPersisted,
			Dst.ColumnRole = Src.ColumnRole,
			Dst.Documentation = Src.Documentation,
			Dst.UpdateTS = getdate();

	commit transaction


