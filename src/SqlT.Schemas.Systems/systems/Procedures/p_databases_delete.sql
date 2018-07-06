create procedure [systems].[p_databases_delete](@systems_server_name sysname, @database_name sysname)
as
	delete [systems].[databases] 
		where systems_server_name = @systems_server_name 
	and name = @database_name
