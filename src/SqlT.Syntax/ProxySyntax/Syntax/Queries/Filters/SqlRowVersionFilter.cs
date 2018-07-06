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

    using SqlT.Types;
    using SqlT.Core;

    public sealed class SqlRowVersionFilter<T> : ISqlFilter<T>
       where T : class, ISqlTabularProxy, ISystemRowVersion, new()
    {

        public SqlRowVersionFilter(SqlRowVersion RowVersion, IComparisonOperator Comparer)
        {
            this.RowVersion = RowVersion;
            this.Comparer = Comparer;
        }


        public SqlRowVersion RowVersion { get; }

        public IComparisonOperator Comparer { get; }

        public string FormatSyntax()
              => $"{nameof(ISystemRowVersion.SystemRV)} {Comparer} 0x{RowVersion.ToString()}";
    }

}