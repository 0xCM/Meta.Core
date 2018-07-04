//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Syntax;
    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Syntax;

    using static metacore;
    using sxc = contracts;
    using kwt = SqlKeywordTypes;

    partial class SqlSyntax
    {
        public sealed class create_schema : create_statement<create_schema, SqlSchemaName>
        {
            public create_schema(SqlSchemaName element_name)
                : base(SCHEMA, element_name)
            {

            }
    

            public override string ToString()
                => $"{CREATE} {SCHEMA} {element_name}";
        }

        public sealed class create_schemas : SyntaxList<create_schemas, create_schema>
        {

            public static implicit operator create_schemas(create_schema[] items)
                => new create_schemas(items);

            public create_schemas()
            { }

            public create_schemas(params create_schema[] items)
                : base(items)
            { }
        }
    }



}