//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System.Collections.Generic;

    using SqlT.Core;
    using SqlT.Syntax;


    public abstract class SqlSchema<M> : SqlElement<M, SqlSchemaName>
        where M : SqlSchema<M>
    {

        protected SqlSchema()
            : this(typeof(M).Name)
        {

        }

        protected SqlSchema(SqlSchemaName Name,
            IEnumerable<SqlPropertyAttachment> Properties = null,
            SqlElementDescription Documentation = null            
            ) : base(Name, Documentation, Properties)
        {

        }
    }


    [SqlElementType(SqlElementTypeNames.Schema)]
    public sealed class SqlSchema : SqlSchema<SqlSchema>
    {

        public SqlSchema(SqlSchemaName Name, SqlElementDescription Documentation
            ) : this(Name, null, Documentation)
        {

        }

        public SqlSchema(SqlSchemaName SchemaName, 
            IEnumerable<SqlPropertyAttachment> Properties = null,  
            SqlElementDescription Documentation = null
            ) : base(SchemaName, Properties, Documentation)
        {

        }

    }
}
