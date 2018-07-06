create procedure [systems].[p_host_servers_merge](@Records [systems].[host_servers_record] readonly) as
	merge into [systems].[host_servers] as Dst using @Records as Src
	on Dst.systems_server_name  = Src.systems_server_name
when not matched then insert(systems_server_name) values(Src.systems_server_name);
 
