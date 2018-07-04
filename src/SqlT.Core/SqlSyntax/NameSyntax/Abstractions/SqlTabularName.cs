//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;

namespace SqlT.Core
{

    using sxc = Syntax.contracts;
    using SqlT.Syntax;



    public abstract class SqlTabularName<N> : SqlObjectName<N>, sxc.tabular_name
        where N : SqlTabularName<N>, new()
    {
        protected SqlTabularName()
        { }

        protected SqlTabularName(bool quoted, params string[] parts)
            : base(quoted, parts)
        {

        }


        public SqlTabularName(SqlIdentifier LocalName)
            : base(LocalName)
        {
            
        }

        public SqlTabularName(SqlIdentifier SchemaName, SqlIdentifier LocalName)
            : base(SchemaName, LocalName)
        {

        }

        public SqlTabularName(SqlSchemaName SchemaName, string LocalName, bool quoted = true)
            : base(quoted, SchemaName, LocalName)
        { }

        public SqlTabularName(SqlDatabaseName DatabaseName, SqlSchemaName SchemaName, string LocalName, bool quoted = true)
            : base(quoted, DatabaseName, SchemaName, LocalName)
        { }

        public SqlTabularName(SqlServerName ServerName, SqlDatabaseName DatabaseName, SqlSchemaName SchemaName, string LocalName, bool quoted = true)
            : base(quoted, ServerName, DatabaseName, SchemaName, LocalName)
        { }


        public SqlTabularName(ICompositeSqlName SqlName, bool quoted =true)
            : base(SqlName,quoted)
        {

        }
        
    }


    public sealed class SqlTabularName : SqlTabularName<SqlTabularName>
    {
        public SqlTabularName()
        {

        }

        public SqlTabularName(sxc.tabular_name TabularName)
            : base(TabularName)
        {

        }
        
    }

}
