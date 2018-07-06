create view [systems].[v_schemas]
	AS SELECT 
		[systems_server_name], 
		[systems_database_name], 
		[name], 
		[schema_id], 
		[principal_id] 
	FROM 
		systems.schemas
