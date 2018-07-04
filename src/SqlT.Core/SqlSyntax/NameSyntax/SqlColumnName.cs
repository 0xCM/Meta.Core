//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;    
    using System.Linq;


    using sxc = SqlT.Syntax.contracts;

    using SqlT.Syntax;

   
    public class SqlColumnName : SqlName<SqlColumnName>, sxc.column_name
    {
        public static readonly new SqlColumnName Empty = new SqlColumnName();
        public static readonly string UriPartIdentifier = "column";

        protected override string UriComponentName
            => UriPartIdentifier;

        public static SqlColumnName Random
            => new SqlColumnName(Guid.NewGuid().ToString("N"));   

        public static new SqlColumnName Parse(string x) 
            => new SqlColumnName(x);


        public static implicit operator SqlColumnName(string x)
            =>new SqlColumnName(x);

        public static implicit operator SqlAliasName(SqlColumnName x)
            => new SqlAliasName(x.UnqualifiedName, x.Quoted);

        public SqlColumnName()
        { }

        public SqlColumnName(sxc.tabular_name TabularName, string Value)
            : base(TabularName.NameComponents.Union(new[] { Value }).ToArray())
        {

        }

        public SqlColumnName(sxc.column_name name)
            : base(name)
        { }

        public SqlColumnName(string value, bool quoted = false)
            : base(quoted, value)
        {

        }

        public override string FullName
            => CreateFullName(false);


    }
}
