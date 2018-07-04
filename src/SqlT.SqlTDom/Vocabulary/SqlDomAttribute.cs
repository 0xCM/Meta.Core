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

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    public sealed class SqlDomAttribute : SqlDomElementMember
    {
        public static SqlDomAttribute FromProperty(ClrProperty DefiningProperty)
            => new SqlDomAttribute(DefiningProperty);

        public SqlDomAttribute(ClrProperty DefiningProperty)
            : base(DefiningProperty, DefiningProperty.PropertyType, SqlDomPropertyKind.Attribute)
        {
        }

        static IReadOnlySet<string> InfrastructureMembers
            = roset(nameof(TSql.TSqlFragment.FirstTokenIndex),
                  nameof(TSql.TSqlFragment.FragmentLength),
                  nameof(TSql.TSqlFragment.LastTokenIndex),
                  nameof(TSql.TSqlFragment.StartColumn),
                  nameof(TSql.TSqlFragment.StartLine),
                  nameof(TSql.TSqlFragment.StartOffset));

        public bool SupportsInfrastructure
            => InfrastructureMembers.Contains(MemberName);

        public override string ToString()
            => $"{MemberName}: {MemberType.Name}";


    }



}