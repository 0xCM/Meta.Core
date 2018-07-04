//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem.SQL12.sys
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;




    public partial class extended_properties : IExtendedProperty
    {
        public override string ToString() 
            => $"{name} = {value}";
    }


    public partial class all_objects : ISystemObject
    {
        public bool is_user_defined => not(is_ms_shipped ?? false);

        bool ISystemObject.is_ms_shipped => is_ms_shipped ?? false;
        public override string ToString() => name;
    }

    public partial class objects : ISystemObject
    {
        public bool is_user_defined => not(is_ms_shipped);

        public override string ToString() => name;
    }

    public partial class all_views : IView
    {
        bool ISystemObject.is_user_defined => not(is_ms_shipped ?? false);
        bool IView.has_opaque_metadata => has_opaque_metadata ?? false;
        bool IView.has_unchecked_assembly_data => has_unchecked_assembly_data ?? false;
        bool IView.is_date_correlation_view => is_date_correlation_view ?? false;
        bool IView.with_check_option => with_check_option ?? false;
        bool ISystemObject.is_ms_shipped => is_ms_shipped ?? false;
    }

    public partial class views : IView
    {
        bool ISystemObject.is_user_defined => not(is_ms_shipped);
    }

    public partial class tables : ITable
    {
        bool ISystemObject.is_user_defined => not(is_ms_shipped);

        public override string ToString() => name;
    }

    public partial class all_columns : IColumn
    {
        public override string ToString() => name;

    }

    public partial class columns : IColumn
    {
        public override string ToString() => name;

    }

    public partial class types : IType
    {
        public override string ToString() 
            => name;

    }

    public partial class sequences : ISequence
    {
        public bool is_user_defined 
            => not(is_ms_shipped);

        public override string ToString() 
            => name;
    }

    public partial class procedures : IProcedure
    {
        public bool is_user_defined => not(is_ms_shipped);


        public procedures(ISystemObject o)
        {
            this.create_date = o.create_date;
            this.modify_date = o.modify_date;
            this.name = o.name;
            this.object_id = o.object_id;
            this.parent_object_id = o.parent_object_id;
            this.principal_id = o.principal_id;
            this.schema_id = o.schema_id;
            this.type = o.type;
            this.type_desc = o.type_desc;
            this.is_ms_shipped = o.is_ms_shipped;

        }

        public override string ToString() => name;
    }


    public partial class parameters : IParameter
    {
        public string column_encryption_key_database_name 
            => null;

        public int? column_encryption_key_id 
            => null;

        public string encryption_algorithm_name 
            => null;

        public int? encryption_type 
            => null;

        public string encryption_type_desc 
            => null;

        public override string ToString() 
            => name;
    }

    public partial class all_parameters : IParameter
    {
        public string column_encryption_key_database_name 
            => null;

        public int? column_encryption_key_id 
            => null;

        public string encryption_algorithm_name => null;

        public int? encryption_type => null;

        public string encryption_type_desc => null;

        public override string ToString() => name;
    }

    public partial class table_types : ITableType
    {
        public override string ToString() => name;

    }

    public partial class indexes : IIndex
    {

        public int? compression_delay 
            => null;


        public override string ToString() 
            => name;
    }


    public partial class index_columns : IIndexColumn
    {
        public string name => String.Empty;
    }

    public partial class master_files : IMasterFile
    {

        public override string ToString()
        {
            return name;
        }
    }

    public partial class service_message_types : IServiceMessageType
    {
        public override string ToString()
            => name;

            
        public bool is_user_defined
            => message_type_id >= 65000;

    }
}