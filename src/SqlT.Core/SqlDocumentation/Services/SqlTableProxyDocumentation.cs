//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Encapsulates a table documentation set, typically constructed via the <see cref="SqlDocumentationBuilder"/>
    /// </summary>
    public class SqlTableProxyDocumentation
    {

        public SqlTableProxyDocumentation(SqlTableProxyInfo TableProxy, SqlTableDocumentation Documentation)
        {
            this.TableProxy = TableProxy;
            this.Documentation = Documentation;
        }

        public SqlTableProxyInfo TableProxy { get; }

        public SqlTableDocumentation Documentation { get; }

        public bool IsReferenceTable
            => Documentation.IsReferenceTable;

        public bool ReferenceDataInModel
            => Documentation.ReferenceDataInModel;

        public IEnumerable<SqlColumnRole> ColumnRoles
            => Documentation.ColumnRoles;

        public bool IsEmpty
            => Documentation.IsEmpty;

        public string Label
            => Documentation.Label;

        public string Description
            => Documentation.Description;

        public string Identifier
            => Documentation.Identifier;

        public SqlTableName TableName
            => TableProxy.ObjectName;

        public SqlTableName IdentifiedTableName
            => Documentation.IdentifiedTableName;

        public override string ToString()
            => $"{TableProxy.ObjectName} {Documentation}";
    }
}
