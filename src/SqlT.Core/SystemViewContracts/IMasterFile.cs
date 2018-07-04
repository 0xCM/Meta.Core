//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{
    using System;

    [SystemViewContract(SystemViewNames.master_files)]
    public interface IMasterFile : ISystemElement
    {
        decimal? backup_lsn {get;}

        decimal? create_lsn {get;}

        int? credential_id {get;}

        int database_id {get;}

        int data_space_id {get;}

        Guid? differential_base_guid {get;}

        decimal? differential_base_lsn {get;}

        DateTime? differential_base_time {get;}

        decimal? drop_lsn {get;}

        Guid? file_guid {get;}

        int file_id {get;}

        int growth {get;}

        bool is_media_read_only {get;}

        bool is_name_reserved {get;}

        bool is_percent_growth {get;}

        bool is_read_only {get;}

        bool is_sparse {get;}

        int max_size {get;}
       
        string physical_name {get;}

        decimal? read_only_lsn {get;}

        decimal? read_write_lsn {get;}

        Guid? redo_start_fork_guid {get;}

        decimal? redo_start_lsn {get;}

        Guid? redo_target_fork_guid {get;}

        decimal? redo_target_lsn {get;}

        int size {get;}

        byte? state {get;}

        string state_desc {get;}

        byte type {get;}

        string type_desc {get;}        
    }
}