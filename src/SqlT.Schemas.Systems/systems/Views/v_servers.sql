﻿CREATE VIEW [systems].[v_servers]
	AS SELECT 
		[systems_server_name], 
		[server_id], 
		[name], 
		[product], 
		[provider], 
		[data_source], 
		[location], 
		[provider_string], 
		[catalog], 
		[connect_timeout], 
		[query_timeout], 
		[is_linked], 
		[is_remote_login_enabled], 
		[is_rpc_out_enabled], 
		[is_data_access_enabled], 
		[is_collation_compatible], 
		[uses_remote_collation], 
		[collation_name], 
		[lazy_schema_validation], 
		[is_system], 
		[is_publisher], 
		[is_subscriber], 
		[is_distributor], 
		[is_nonsql_subscriber], 
		[is_remote_proc_transaction_promotion_enabled], 
		[modify_date] 
	FROM 
		systems.servers
