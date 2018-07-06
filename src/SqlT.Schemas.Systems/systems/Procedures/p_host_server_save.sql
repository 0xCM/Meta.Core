create procedure [systems].[p_host_server_save](@systems_server_name sysname) as
	if not exists(select count(*) from systems.host_servers x where x.systems_server_name = @systems_server_name)
		insert systems.host_servers(systems_server_name)
		values(@systems_server_name);
