//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;

    using SqlT.Syntax;
    using sxc = Syntax.contracts;

    using SqlT.Core;
    /// <summary>
    /// Specifies a query that is parametrized by an paritally or fully-qualified object name
    /// </summary>
    public sealed class SqlObjectScript : SqlScript<SqlObjectScript>, ISqlObjectQueryScript
    {
        public const string ServerParameterName = SqlDatabaseQueryScript.ServerParameterName;
        public const string DatabaseParameterName = SqlDatabaseQueryScript.DatabaseParameterName;
        public const string SchemaParameterName = "@SchemaName";
        public const string ObjectParameterName = "@ObjectName";


        public SqlObjectScript(SqlScript Script, sxc.ISqlObjectName SourceObject)
            : base(Script.ScriptName, Script.ScriptText)
        {
            this.ObjectName = SourceObject;
            this.SourceDatabase = SourceObject.GetDatabaseName();

        }

        public SqlObjectScript(SqlScript Script, SqlDatabaseName SourceDatabase)
            : base(Script.ScriptName, Script.ScriptText)
        {
            this.SourceDatabase = SourceDatabase;

        }

        public SqlDatabaseName SourceDatabase { get; }

        /// <summary>
        /// The name of the object by which the script is parametrized
        /// </summary>
        public sxc.ISqlObjectName ObjectName { get; }
            

        public IEnumerable<SqlParameterValue> ParameterValues
        {
            get
            {
                if (!ObjectName.IsEmpty())
                    yield return new SqlParameterValue(ObjectParameterName, ObjectName.UnqualifiedName);
                if (ObjectName.IsSchemaQualified())
                    yield return new SqlParameterValue(SchemaParameterName, ObjectName.SchemaNamePart);
                if (ObjectName.IsDatabaseQualified())
                    yield return new SqlParameterValue(DatabaseParameterName, ObjectName.DatabaseNamePart);
                if (ObjectName.IsServerQualified())
                    yield return new SqlParameterValue(ServerParameterName, ObjectName.ServerNamePart);
            }
        }


        Option<sxc.ISqlObjectName> ISqlObjectQueryScript.SourceObject            
            => some(ObjectName);

        Option<SqlDatabaseName> ISqlObjectQueryScript.SourceDatabase
            => SourceDatabase;

        public sxc.ISqlObjectName SourceObject
            => ObjectName;
    }

}
