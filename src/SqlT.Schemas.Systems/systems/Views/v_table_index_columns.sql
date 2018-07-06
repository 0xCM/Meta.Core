CREATE VIEW [systems].[v_table_index_columns]
	as select 
		[systems_server_name], 
		[systems_database_name], 
		[systems_schema_name], 
		[systems_parent_name], 
		[systems_parent_type], 
		[systems_column_name], 
		[systems_index_name], 
		[object_id], 
		[index_id], 
		[index_column_id], 
		[column_id], 
		[key_ordinal], 
		[partition_ordinal], 
		[is_descending_key], 
		[is_included_column] 
	from 
		systems.[table_index_columns]
