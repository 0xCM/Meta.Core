////This file was generated 6/24/2017 12:42:27 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public abstract class TriggerStatementBody : TSqlStatement, ISqlTDomStatement
    {
        public SchemaObjectName Name
        {
            get;
            set;
        }

        public TriggerObject TriggerObject
        {
            get;
            set;
        }

        public IList<TriggerOption> Options
        {
            get;
            set;
        }

        public TriggerType TriggerType
        {
            get;
            set;
        }

        public IList<TriggerAction> TriggerActions
        {
            get;
            set;
        }

        public bool WithAppend
        {
            get;
            set;
        }

        public bool IsNotForReplication
        {
            get;
            set;
        }

        public StatementList StatementList
        {
            get;
            set;
        }

        public MethodSpecifier MethodSpecifier
        {
            get;
            set;
        }
    }
}