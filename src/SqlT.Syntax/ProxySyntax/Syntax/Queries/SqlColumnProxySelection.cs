//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Linq;

    using Meta.Syntax;
    using SqlT.Core;

    using static metacore;

    /// <summary>
    /// Designates a column from a tabular object that is to be included in some set
    /// </summary>
    public class SqlColumnProxySelection : SyntaxExpression<SqlColumnProxySelection>
    {

        public SqlColumnProxySelection(SqlColumnProxyInfo Proxy)
        {
            this.Proxy = Proxy;
            this.SourceAlias = String.Empty;
            this.ColumnAlias = String.Empty;
        }

        public SqlColumnProxySelection(SqlColumnProxyInfo Proxy, string SourceAlias, string ColumnAlias, int? Position = null)
        {
            this.Proxy = Proxy;
            this.SourceAlias = SourceAlias;
            this.ColumnAlias = ColumnAlias ?? String.Empty;
            this.Position = Position;
        }

        public SqlColumnProxySelection(SqlColumnProxyInfo Proxy, int? Position = null)
        {
            this.Proxy = Proxy;
            this.SourceAlias = String.Empty;
            this.Position = Position;
            this.ColumnAlias = String.Empty;
        }

        /// <summary>
        /// The representing proxy
        /// </summary>
        public SqlColumnProxyInfo Proxy { get; }

        /// <summary>
        /// Alias from the column source, if any
        /// </summary>
        public string SourceAlias { get; }

        /// <summary>
        /// An alias for the column
        /// </summary>
        public string ColumnAlias { get; }

        /// <summary>
        /// The selection position
        /// </summary>
        public int? Position { get; }

        /// <summary>
        /// The name of the column
        /// </summary>
        public SqlColumnName ColumnName
            => new SqlColumnName(Proxy.ColumnName);

        public ClrClassName RuntimeName
            => Proxy.RuntimeName;

        public override string ToString()
            => (isBlank(ColumnAlias) 
            ? ColumnName.UnqualifiedName 
            : $"{ColumnName} as {ColumnAlias}");

        public bool HasColumnAlias
            => isNotBlank(ColumnAlias);

        public bool HasSourceAlias
            => isNotBlank(SourceAlias);

        public SqlColumnProxySelection WithSourceAlias(string SourceAlias)
            => new SqlColumnProxySelection(this.Proxy, SourceAlias, this.ColumnAlias, this.Position);        
    }
}
