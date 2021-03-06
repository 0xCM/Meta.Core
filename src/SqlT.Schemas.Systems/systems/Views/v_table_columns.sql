﻿create view [systems].v_table_columns
	as select 
		systems_server_name, 
		systems_database_name, 
		systems_schema_name, 
		systems_parent_name, 
		systems_parent_type, 
		[object_id], 
		[name], 
		column_id, 
		system_type_id, 
		user_type_id, 
		max_length, 
		[precision], 
		[scale], 
		[collation_name], 
		[is_nullable], 
		[is_ansi_padded], 
		[is_rowguidcol], 
		[is_identity], 
		[is_computed], 
		[is_filestream], 
		[is_replicated], 
		[is_non_sql_subscribed], 
		[is_merge_published], 
		[is_dts_replicated], 
		[is_xml_document], 
		[xml_collection_id], 
		[default_object_id], 
		[rule_object_id], 
		[is_sparse], 
		[is_column_set] 
from 
	systems.[table_columns]
