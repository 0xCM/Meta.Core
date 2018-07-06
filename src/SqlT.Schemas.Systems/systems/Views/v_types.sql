CREATE VIEW [systems].[v_types]
	AS SELECT [systems_server_name], [systems_database_name], [systems_schema_name], [name], [system_type_id], [user_type_id], [schema_id], [principal_id], [max_length], [precision], [scale], [collation_name], [is_nullable], [is_user_defined], [is_assembly_type], [default_object_id], [rule_object_id], [is_table_type] FROM systems.types
