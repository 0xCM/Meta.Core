create view [systems].[v_extended_properties] as
	select 
		systems_server_name, 
		systems_database_name, 
		class, 
		class_desc, 
		major_id, 
		minor_id, 
		[name], 
		[value] 		
	from
		[systems].[extended_properties]
