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

    using SqlT.Models;
    using SqlT.Core;

    using static metacore;
    using static SqlSyntax;

    using sxc = contracts;
    using kwt = SqlKeywordTypes;


    partial class SqlSyntax
    {

        public sealed class create_synonym : create_statement<create_synonym, SqlSynonymName>
        {
            public create_synonym(SqlSynonymName element_name, object_name referent_name)
                : base(SYNONYM, element_name)
            {
                this.referent_name = referent_name;
            }

            public object_name referent_name { get; }

            public override string ToString()
                => $"{CREATE} {SYNONYM} {element_name} {FOR} {referent_name}";
        }


        public sealed class create_synonyms : SyntaxList<create_synonyms, create_synonym>
        {

            public static implicit operator create_synonyms(create_synonym[] items)
                => new create_synonyms(items);

            public create_synonyms()
            { }

            public create_synonyms(params create_synonym[] items)
                : base(items)
            { }
        }
    }


}