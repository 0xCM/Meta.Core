create view [systems].[v_host_servers] as 
	select 
		x.systems_server_name 
	from 
		systems.host_servers x
