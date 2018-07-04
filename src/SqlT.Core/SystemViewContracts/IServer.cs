//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{
    using System;

    [SystemViewContract(SystemViewNames.servers)]
    public interface IServer : ISystemElement
    {
        string catalog {get;}
        string collation_name {get;}
        int? connect_timeout {get;}
        string data_source {get;}
        bool is_collation_compatible {get;}
        bool is_data_access_enabled {get;}
        bool? is_distributor {get;}
        bool is_linked {get;}
        bool? is_nonsql_subscriber {get;}
        bool is_publisher {get;}
        bool? is_rda_server {get;}
        bool is_remote_login_enabled {get;}
        bool? is_remote_proc_transaction_promotion_enabled {get;}
        bool is_rpc_out_enabled {get;}
        bool? is_subscriber {get;}
        bool is_system {get;}
        bool lazy_schema_validation {get;}
        string location {get;}
        DateTime modify_date {get;}
        string product {get;}
        string provider {get;}
        string provider_string {get;}
        int? query_timeout {get;}
        int server_id {get;}
        bool uses_remote_collation {get;}
    }
}