//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{

    using System;
    using System.Collections.Generic;
    using static metacore;

    using Meta.Models;
    using sxc = contracts;
    using SqlT.Core;
    
    public sealed class schema_qualified_name : Model<schema_qualified_name>, sxc.ISqlObjectName 
    {
        public schema_qualified_name(simple_schema_name schema_name, simple_object_name object_name, bool quoted = true)
        {
            this.schema_name = schema_name;
            this.object_name = object_name;
            this.quoted = quoted;
            this.referent_type = string.Empty;
        }

        public simple_schema_name schema_name { get; }

        public simple_object_name object_name { get; }

        public bool quoted { get; }

        public override bool IsEmpty
            => schema_name.IsEmpty 
            && object_name.IsEmpty;

        public string referent_type { get; }

        public IReadOnlyList<string> NameComponents
            => new string[] { schema_name, object_name };

        public string text
            => concat(
                schema_name.IsEmpty ? string.Empty : toString(schema_name) + dot(),
                object_name.IsEmpty ? string.Empty : toString(object_name)
                );

        bool sxc.ISqlObjectName.IsSystemObject
            => false;

        string sxc.ISqlObjectName.ServerNamePart
            => string.Empty;

        string sxc.ISqlObjectName.DatabaseNamePart
            => string.Empty;

        string sxc.ISqlObjectName.SchemaNamePart
            => schema_name.text;

        string sxc.ISqlObjectName.UnqualifiedName
            => object_name.text;


        public override string ToString()
            => text;
        

    }


}