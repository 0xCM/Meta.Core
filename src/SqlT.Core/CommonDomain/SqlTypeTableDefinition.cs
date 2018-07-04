//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class SqlTypeTableDefinition 
    {

        public SqlTypeTableDefinition(
            SqlTableName TableName, 
            SqlTypeName TypeCodeType, 
            string Description, 
            IEnumerable<SqlTypeTableEntry> Entries

            )
        {
            this.TableName = TableName;
            this.TypeCodeType = TypeCodeType;
            this.Description = Description;
            this.Entries = Entries.ToList();
            this.Identifier = TableName.UnqualifiedName;
        }

        public string Identifier { get; }

        public SqlTypeName TypeCodeType { get; }

        public SqlTableName TableName { get; }

        public string Description { get; }

        public IReadOnlyList<SqlTypeTableEntry> Entries { get; }

        public override string ToString()
            => $"{Identifier} : {TypeCodeType}";

    }
}
