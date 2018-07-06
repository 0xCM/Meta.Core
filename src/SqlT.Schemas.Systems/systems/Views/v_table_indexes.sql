CREATE VIEW [systems].[v_table_indexes]
	AS SELECT 
		[systems_server_name], 
		[systems_database_name], 
		[systems_schema_name], 
		[systems_parent_name], 
		[systems_parent_type], 
		[object_id], 
		[name], 
		[index_id], 
		[type], 
		[type_desc], 
		[is_unique], 
		[data_space_id], 
		[ignore_dup_key], 
		[is_primary_key], 
		[is_unique_constraint], 
		[fill_factor], 
		[is_padded], 
		[is_disabled], 
		[is_hypothetical], 
		[allow_row_locks], 
		[allow_page_locks], 
		[has_filter], 
		[filter_definition] 
	from 
		systems.table_indexes
