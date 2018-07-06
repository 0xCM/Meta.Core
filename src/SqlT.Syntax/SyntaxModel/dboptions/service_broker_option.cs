//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using Meta.Models;
    using Meta.Syntax;

    using sxc = contracts;
    using kwt = SqlKeywordTypes;
    using sx = SqlSyntax;

    partial class SqlSyntax
    {
        public sealed class service_broker_option : 
            du< 
                kwt.ENABLE_BROKER, 
                kwt.DISABLE_BROKER, 
                kwt.NEW_BROKER,
                kwt.ERROR_BROKER_CONVERSATIONS
            >, sxc.dboption
        {
            public static implicit operator service_broker_option(kwt.ENABLE_BROKER x)
                => new service_broker_option(x);

            public static implicit operator service_broker_option(kwt.DISABLE_BROKER x)
                => new service_broker_option(x);

            public static implicit operator service_broker_option(kwt.NEW_BROKER x)
                => new service_broker_option(x);

            public static implicit operator service_broker_option(kwt.ERROR_BROKER_CONVERSATIONS x)
                => new service_broker_option(x);

            public service_broker_option(kwt.ENABLE_BROKER x)
                : base(x)
            { }

            public service_broker_option(kwt.DISABLE_BROKER x)
                : base(x)
            { }

            public service_broker_option(kwt.NEW_BROKER x)
                : base(x)
            { }

            public service_broker_option(kwt.ERROR_BROKER_CONVERSATIONS x)
                : base(x)
            { }
        }

        public sealed class service_broker_options : SyntaxList<service_broker_options, service_broker_option>
        {
            public static readonly service_broker_option ENABLE_BROKER = sx.ENABLE_BROKER;
            public static readonly service_broker_option DISABLE_BROKER = sx.DISABLE_BROKER;
            public static readonly service_broker_option NEW_BROKER = sx.NEW_BROKER;
            public static readonly service_broker_option ERROR_BROKER_CONVERSATION = sx.ERROR_BROKER_CONVERSATIONS;

        }

    }
}