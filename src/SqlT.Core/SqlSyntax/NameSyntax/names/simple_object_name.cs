//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System.Collections.Generic;

    using sxc = contracts;
    using SqlT.Core;
    using System;
    using static metacore;

    /// <summary>
    /// Specifies a (schema-relative) identifer for a schema-scoped database object
    /// </summary>
    public sealed class simple_object_name : simple_name<simple_object_name>,  sxc.ISqlObjectName
    {

        public static implicit operator simple_object_name(string text)
            => new simple_object_name(text);

        public static implicit operator string(simple_object_name name)
            => name.ToString();

        public simple_object_name(string identifier, bool quoted = true)
            : base(identifier,quoted)
        {
        }

        bool sxc.ISqlObjectName.IsSystemObject
            => false;

        string sxc.ISqlObjectName.ServerNamePart
            => string.Empty;

        string sxc.ISqlObjectName.DatabaseNamePart
            => string.Empty;

        string sxc.ISqlObjectName.SchemaNamePart
            => string.Empty;

        string sxc.ISqlObjectName.UnqualifiedName
            => text;
        
        public IReadOnlyList<string> NameComponents 
            => new string[] { text };

    }



}