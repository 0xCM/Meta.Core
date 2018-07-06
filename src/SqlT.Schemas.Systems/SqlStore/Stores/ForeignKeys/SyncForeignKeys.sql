create procedure [SqlT].[SyncForeignKeys]
(
	@ServerName sysname, 
	@DatabaseName sysname, 
	@ForeignKeys [SqlT].[ForeignKeyInfo] readonly
) as
	
	delete [SqlStore].[ForeignKey] 
	where 
		ServerName = @ServerName 
	and DatabaseName = @DatabaseName

	insert [SqlStore].[ForeignKey]
	(
		ServerName, 
		DatabaseName, 
		ForeignKeySchema, 
		ForeignKeyName, 
		ClientTableSchema, 
		ClientTableName, 
		SupplierTableSchema, 
		SupplierTableName, 
		KeyColumnId, 
		ClientColumnName, 
		ClientColummnId, 
		SupplierColumnName, 
		SupplierColumnId, 
		Documentation
	)
	select 		
		ServerName, 
		DatabaseName, 
		ForeignKeySchema, 
		ForeignKeyName, 
		ClientTableSchema, 
		ClientTableName, 
		SupplierTableSchema, 
		SupplierTableName, 
		KeyColumnId, 
		ClientColumnName, 
		ClientColummnId, 
		SupplierColumnName, 
		SupplierColumnId, 
		Documentation
 from @ForeignKeys
	


	
