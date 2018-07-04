//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System.Collections.Generic;

    using sxc = contracts;
    using Meta.Models;
    using SqlT.Core;
    using System;
    using static metacore;

    public sealed class server_qualified_name : Model<server_qualified_name>, sxc.ISqlObjectName
    {
        public server_qualified_name
        (
            simple_server_name server_name,
            simple_database_name database_name,
            simple_schema_name schema_name,
            simple_object_name object_name,
            bool quoted = true
        )
        {
            this.database_name = database_name;
            this.schema_name = schema_name;
            this.object_name = object_name;
            this.quoted = quoted;
            
        }

        public simple_server_name server_name { get; }

        public simple_database_name database_name { get; }

        public simple_schema_name schema_name { get; }

        public simple_object_name object_name { get; }

        public bool quoted { get; }

        public override bool IsEmpty
            => server_name.IsEmpty 
            && database_name.IsEmpty 
            && schema_name.IsEmpty 
            && object_name.IsEmpty;

        public IReadOnlyList<string> NameComponents
            => new string[] {server_name, database_name, schema_name, object_name };

        public string text
            => concat(
                server_name.IsEmpty ? string.Empty : toString(server_name) + dot(),
                database_name.IsEmpty ? string.Empty : toString(database_name) + dot(),
                schema_name.IsEmpty ? string.Empty : toString(schema_name) + dot(),
                object_name.IsEmpty ? string.Empty : toString(object_name)
                );


        bool sxc.ISqlObjectName.IsSystemObject
            => false;

        string sxc.ISqlObjectName.ServerNamePart
            => server_name.text;

        string sxc.ISqlObjectName.DatabaseNamePart
            => database_name.text;

        string sxc.ISqlObjectName.SchemaNamePart
            => schema_name.text;

        string sxc.ISqlObjectName.UnqualifiedName
            => object_name.text;


        public override string ToString()
            => text;

    }

}