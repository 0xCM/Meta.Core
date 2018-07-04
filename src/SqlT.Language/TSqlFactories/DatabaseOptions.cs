//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Models;
    using SqlT.Core;
    using SqlT.Syntax;
    using SqlT.Models;
    using SqlT.Services;

    using static metacore;

    using static SqlT.Syntax.SqlSyntax;
    using sxc = SqlT.Syntax.SqlKeywordTypes;
    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    public static partial class TSqlFactory
    {

        public static TSql.ContainmentDatabaseOption OnKeywords(sxc.CONTAINMENT containment, sxc.NONE none)
            => new TSql.ContainmentDatabaseOption
            {
                OptionKind = TSql.DatabaseOptionKind.Containment,
                Value = TSql.ContainmentOptionKind.None
            };

        public static TSql.ContainmentDatabaseOption OnKeywords(sxc.CONTAINMENT containment, sxc.PARTIAL partial)
            => new TSql.ContainmentDatabaseOption
            {
                OptionKind = TSql.DatabaseOptionKind.Containment,
                Value = TSql.ContainmentOptionKind.Partial
            };

        public static TSql.RecoveryDatabaseOption OnKeywords(sxc.RECOVERY recovery, sxc.SIMPLE simple)
           => new TSql.RecoveryDatabaseOption
           {
               OptionKind = TSql.DatabaseOptionKind.Recovery,
               Value = TSql.RecoveryDatabaseOptionKind.Simple
           };

        public static TSql.RecoveryDatabaseOption OnKeywords(sxc.RECOVERY recovery, sxc.FULL simple)
           => new TSql.RecoveryDatabaseOption
           {
               OptionKind = TSql.DatabaseOptionKind.Recovery,
               Value = TSql.RecoveryDatabaseOptionKind.Full
           };

        public static TSql.RecoveryDatabaseOption OnKeywords(sxc.RECOVERY recovery, sxc.BULK_LOGGED simple)
           => new TSql.RecoveryDatabaseOption
           {
               OptionKind = TSql.DatabaseOptionKind.Recovery,
               Value = TSql.RecoveryDatabaseOptionKind.BulkLogged
           };

        [TSqlBuilder]
        public static TSql.ContainmentDatabaseOption TSqlOption(this containment_type model)
        {
            switch (model.selected_value)
            {
                case sxc.PARTIAL selected:
                    return OnKeywords(CONTAINMENT, selected);
                case sxc.NONE selected:
                    return OnKeywords(CONTAINMENT, selected);
            }
            throw new NotSupportedException();
        }

        [TSqlBuilder]
        public static TSql.RecoveryDatabaseOption TSqlOption(this recovery_model model)
        {
            switch (model.selected_value)
            {
                case sxc.FULL selected:
                    return OnKeywords(RECOVERY, selected);
                case sxc.SIMPLE selected:
                    return OnKeywords(RECOVERY, selected);
                case sxc.BULK_LOGGED selected:
                    return OnKeywords(RECOVERY, selected);

            }
            throw new NotSupportedException();
        }

    }

}