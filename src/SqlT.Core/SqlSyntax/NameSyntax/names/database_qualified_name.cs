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
    using sxc = contracts;
    using SqlT.Core;
    
    using static metacore;


    public sealed class database_qualified_name : Model<database_qualified_name>, sxc.ISqlObjectName
    {
        public database_qualified_name
            (
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

        public simple_database_name database_name { get; }

        public simple_schema_name schema_name { get; }

        public simple_object_name object_name { get; }

        public bool quoted { get; }

        public override bool IsEmpty
            => database_name.IsEmpty 
            && schema_name.IsEmpty 
            && object_name.IsEmpty;

        public IReadOnlyList<string> NameComponents
            => new string[] { database_name, schema_name, object_name };

        public string text
            => concat(
                database_name.IsEmpty ? string.Empty : toString(database_name) + dot(),
                schema_name.IsEmpty ? string.Empty : toString(schema_name) + dot(),
                object_name.IsEmpty ? string.Empty : toString(object_name) + dot()
                );


        bool sxc.ISqlObjectName.IsSystemObject
            => false;

        string sxc.ISqlObjectName.ServerNamePart
            => string.Empty;

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