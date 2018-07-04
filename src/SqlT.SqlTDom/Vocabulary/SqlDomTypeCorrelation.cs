//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dom
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;
    using static metacore;

    /// <summary>
    /// Correlates a Microsoft TSql Dom type with its Model type
    /// </summary>
    public class SqlDomTypeCorrelation
    {
        public static implicit operator SqlDomTypeCorrelation((ClrType TSqlType, ClrType SqlTType) c)
            => new SqlDomTypeCorrelation(c.TSqlType, c.SqlTType);

        public SqlDomTypeCorrelation((ClrType TSqlType, ClrType SqlTType) c)
            => new SqlDomTypeCorrelation(c.TSqlType, c.SqlTType);

        public SqlDomTypeCorrelation(ClrType TSqlType, ClrType SqlTType)
        {
            this.TSqlType = TSqlType;
            this.SqlTType = SqlTType;
        }

        public ClrType TSqlType { get; }
        public ClrType SqlTType { get; }

        public override string ToString()
            => $"TSql({TSqlType}) <--> SqlT({SqlTType})";
    }

}
