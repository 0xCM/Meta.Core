CREATE PROCEDURE [systems].[p_host_server_delete](@systems_server_name sysname) as
	delete systems.host_servers where systems_server_name = @systems_server_name
