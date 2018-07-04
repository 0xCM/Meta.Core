//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dac
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DacM = Microsoft.SqlServer.Dac.Model;

    using Meta.Models;
    using SqlT.Core;
    using SqlT.Models;

    using static SqlT.Syntax.SqlSyntax;
    using kwt = SqlT.Syntax.SqlKeywordTypes;

    using static metacore;

    static class DatabaseOptions
    {
        public static DacM.Containment ToDac(this containment_type model)
            => ((model as IDiscriminatedUnion).selected_value) == NONE
                            ? DacM.Containment.None
                            : DacM.Containment.Partial;

        public static DacM.RecoveryMode ToDac(this recovery_model model)
            => (model == recovery_models.SIMPLE
                             ? DacM.RecoveryMode.Simple
                             : (model == recovery_models.BULK_LOGGED
                                             ? DacM.RecoveryMode.BulkLogged
                                             : DacM.RecoveryMode.Full)
                                             );

        public static DacM.ServiceBrokerOption ToDac(this service_broker_option model)
        {
            switch ((model as IDiscriminatedUnion).selected_value)
            {
                case kwt.ENABLE_BROKER x:
                    return DacM.ServiceBrokerOption.EnableBroker;
                case kwt.DISABLE_BROKER x:
                    return DacM.ServiceBrokerOption.DisableBroker;
                case kwt.NEW_BROKER x:
                    return DacM.ServiceBrokerOption.NewBroker;
                case kwt.ERROR_BROKER_CONVERSATIONS x:
                    return DacM.ServiceBrokerOption.ErrorBrokerConversations;
                default:
                    return DacM.ServiceBrokerOption.Unknown;
            }
        }

        public static DacM.SqlServerVersion ToDac(this SqlVersion v)
        {
            switch (v.Name)
            {
                case SqlVersionNames.Sql2005:
                    return DacM.SqlServerVersion.Sql90;
                case SqlVersionNames.Sql2008:
                case SqlVersionNames.Sql2008R2:
                    return DacM.SqlServerVersion.Sql100;
                case SqlVersionNames.Sql2012:
                    return DacM.SqlServerVersion.Sql110;
                case SqlVersionNames.Sql2014:
                    return DacM.SqlServerVersion.Sql120;
                case SqlVersionNames.Sql2016:
                    return DacM.SqlServerVersion.Sql130;
                case SqlVersionNames.Sql2017:
                    return DacM.SqlServerVersion.Sql140;
                default:
                    return DacM.SqlServerVersion.Sql140;

            }
        }


    }

}
