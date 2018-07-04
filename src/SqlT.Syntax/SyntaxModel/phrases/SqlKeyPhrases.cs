//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{

    using Meta.Syntax;

    using sx = SqlSyntax;
    using kp = SqlKeyPhraseTypes;
    using kwt = SqlKeywordTypes;
   
    
    using static SqlSyntax;

    public static class SqlKeyPhrases
    {
        public static SyntaxRule not_for_replication()
            => NOT + FOR + REPLICATION;

        public static SyntaxRule generated_always_at_row_start()
            => GENERATED + ALWAYS + AT + ROW + START;

        public static SyntaxRule generated_always_at_row_end()
            => GENERATED + ALWAYS + AT + ROW + END;

        public static SyntaxRule period_for_system_time()
            => PERIOD + FOR + SYSTEM + sx.TIME;

        public static SyntaxRule sent_by_initiator()
            => SENT + BY + INITIATOR;

        public static SyntaxRule execute_as()
            => EXECUTE + AS;

        public static SyntaxRule application_role()
            => APPLICATION + ROLE;

        public static SyntaxRule partition_function()
            => PARTITION + FUNCTION;

        public static SyntaxRule order_by()
            => ORDER + BY;

        public static SyntaxRule plan_guide()
            => PLAN + GUIDE;

        public static SyntaxRule event_notification()
            => EVENT + NOTIFICATION;

        public static SyntaxRule next_value_for()
            => NEXT + VALUE + FOR;

        public static SyntaxRule remote_service_binding()
            => REMOTE + SERVICE + BINDING;

        public static SyntaxRule at_time_zone()
            => AT + sx.TIME + ZONE;

        public static SyntaxRule xml_schema_collection()
            => sx.XML + SCHEMA + COLLECTION;

        public static SyntaxRule message_type()
            => MESSAGE + TYPE;

        public static SyntaxRule with_ties()
            => WITH + TIES;

        public static SyntaxRule not_null()
            => NOT + NULL;
    }

    partial class SqlSyntax
    {
        
        
        public static readonly kp.MESSAGETYPE MESSAGETYPE = new kp.MESSAGETYPE();
        public static readonly kp.PARTITIONSCHEME PARTITIONSCHEME = new kp.PARTITIONSCHEME();
        public static readonly kp.NOTNULL NOTNULL = new kp.NOTNULL();
        public static readonly kp.TABLETYPE TABLETYPE = new kp.TABLETYPE();
        public static readonly kp.REMOTESERVICEBINDING REMOTESERVICEBINDING = new kp.REMOTESERVICEBINDING();
        public static readonly kp.XMLSCHEMACOLLECTION XMLSCHEMACOLLECTION = new kp.XMLSCHEMACOLLECTION();
        public static readonly kp.PLANGUIDE PLANGUIDE = new kp.PLANGUIDE();
        public static readonly kp.EVENTNOTIFICATION EVENTNOTIFICATION = new kp.EVENTNOTIFICATION();
        public static readonly kp.PARTITIONFUNCTION PARTITIONFUNCTION = new kp.PARTITIONFUNCTION();



    }

    public static partial class SqlKeyPhraseTypes
    {


        public sealed class MESSAGETYPE : keyphrase<kwt.MESSAGE, kwt.TYPE>
        {
            public MESSAGETYPE()
                : base(sx.MESSAGE, sx.TYPE)
            { }
        }

        public sealed class TABLETYPE : keyphrase<kwt.TABLE, kwt.TYPE>
        {
            public TABLETYPE()
                : base(sx.TABLE, sx.TYPE)
            { }
        }


        public sealed class VALUEFOR : keyphrase<kwt.VALUE, kwt.FOR>
        {
            public VALUEFOR()
                : base(sx.VALUE, sx.FOR)
            { }
        }



        public sealed class PLANGUIDE : keyphrase<kwt.PLAN, kwt.GUIDE>
        {
            public PLANGUIDE()
                : base(sx.PLAN, sx.GUIDE)
            { }
        }

        public sealed class REMOTESERVICEBINDING : keyphrase<kwt.REMOTE, kwt.SERVICE, kwt.BINDING>
        {
            public REMOTESERVICEBINDING()
                : base(sx.REMOTE, sx.SERVICE, sx.BINDING)
            { }
        }


        public sealed class XMLSCHEMACOLLECTION : keyphrase<kwt.XML, kwt.SCHEMA, kwt.COLLECTION>
        {
            public XMLSCHEMACOLLECTION()
                : base(sx.XML, sx.SCHEMA, sx.COLLECTION)
            { }
        }

        public sealed class PARTITIONSCHEME : keyphrase<kwt.PARTITION, kwt.SCHEME>
        {
            public PARTITIONSCHEME()
                : base(sx.PARTITION, sx.SCHEME)
            { }
        }


        public sealed class PARTITIONFUNCTION : keyphrase<kwt.PARTITION, kwt.FUNCTION>
        {
            public PARTITIONFUNCTION()
                : base(sx.PARTITION, sx.FUNCTION)
            { }
        }

        public sealed class EVENTNOTIFICATION : keyphrase<kwt.EVENT, kwt.NOTIFICATION>
        {
            public EVENTNOTIFICATION()
                : base(sx.EVENT, sx.NOTIFICATION)
            { }
        }


        public sealed class NOTNULL : keyphrase<kwt.NOT, kwt.NULL>
        {
            public static kwt.NULL operator !(NOTNULL n)
                => sx.NULL;

            internal NOTNULL()
                : base(sx.NOT, sx.NULL)
            { }
        }

    }
}
