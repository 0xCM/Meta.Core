create function [dbo].[DescribeForeignKeys]() returns table as return
	with FK as
	(
		select 
			fk_schema.[schema_id] as fk_schema_id,
			fk_schema.[name] as fk_schema,
			fk.[object_id] as fk_id,
			fk.[name] as fk_name,
			client_schema.[schema_id] as client_schema_id,
			client_schema.[name] as client_schema,
			client.[object_id] as client_id,
			client.[name] as client_name,
			supplier_schema.[schema_id] as supplier_schema_id,
			supplier_schema.[name] as supplier_schema,
			supplier.[object_id] as supplier_id,
			supplier.[name] as supplier_name
		from 
			sys.foreign_keys fk 
				inner join sys.schemas fk_schema on 
					fk_schema.[schema_id] = fk.[schema_id]
		
				inner join sys.objects client on 
					client.[object_id] = fk.parent_object_id
		
				inner join sys.schemas client_schema
					on client_schema.[schema_id] = client.[schema_id]

				inner join sys.objects supplier
					on supplier.[object_id] = fk.referenced_object_id

				inner join sys.schemas supplier_schema
					on supplier_schema.[schema_id] = supplier.[schema_id]
		where 
			fk_schema.[name] not in ('SqlT', 'systems', 'DDL')
		),
		FKCOL as
		(
			select 
				FK.*,
				fkcol.constraint_column_id as fk_col_id,
				fkcol.parent_column_id as client_col_id,
				client_cols.[name] as client_col,
				fkcol.referenced_column_id as supplier_col_id,
				supplier_cols.[name] as supplier_col
		
			from 
				sys.foreign_key_columns fkcol 
					inner join FK on 
						FK.fk_id = fkcol.constraint_object_id
		
					inner join sys.columns client_cols on 
						client_cols.[object_id] = FK.client_id
					and client_cols.[column_id] = fkcol.parent_column_id

					inner join sys.columns supplier_cols on 
						supplier_cols.[object_id] = FK.supplier_id
					and supplier_cols.[column_id] = fkcol.referenced_column_id
		)
		select 
			row_number() over(order by x.fk_schema, x.fk_name, x.fk_col_id) as SequenceNumber,
			db_name() as DatabaseName,
			'1.0.0.0' as DatabaseVersion,
			x.fk_schema as ForeignKeySchema,
			x.fk_name as ForeignKeyName,
			x.client_schema as ClientTableSchema,
			x.client_name as ClientTableName,
			x.supplier_schema as SupplierTableSchema,
			x.supplier_name as SupplierTableName,
			x.fk_col_id as ForeignKeyColumnId,
			x.client_col as ClientColumnName,
			x.client_col_id as ClientColummnId,
			x.supplier_col as SupplierColumn,
			x.supplier_col_id as SupplierColumnId	
		 from FKCOL x
	
