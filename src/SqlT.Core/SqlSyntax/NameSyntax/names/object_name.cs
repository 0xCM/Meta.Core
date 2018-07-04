//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections.Generic;

    using Meta.Models;
    using Meta.Syntax;
    using SqlT.Core;

    using sxc = contracts;

    public sealed class object_name : cdu
        <
            sxc.ISqlObjectName, 
            simple_object_name, 
            schema_qualified_name, 
            database_qualified_name, 
            server_qualified_name
        >, IName
    {
        bool IName.IsEmpty
            => (selected_value as IName).IsEmpty;

        public static implicit operator object_name(simple_object_name name)
            => new object_name(name);

        public static implicit operator object_name(schema_qualified_name name)
            => new object_name(name);

        public static implicit operator object_name(database_qualified_name name)
            => new object_name(name);

        public static implicit operator object_name(server_qualified_name name)
            => new object_name(name);

        public object_name(simple_object_name name)
            : base(name)
        {
            
               
        }

        public object_name(schema_qualified_name name)
            : base(name)
        {
            
        }

        public object_name(database_qualified_name name)
            : base(name)
        {
            
        }

        public object_name(server_qualified_name name)
            : base(name)
        {
            
        }      
    }
}