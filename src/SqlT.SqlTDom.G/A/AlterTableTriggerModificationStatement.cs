////This file was generated 6/24/2017 12:42:29 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class AlterTableTriggerModificationStatement : AlterTableStatement, ISqlTDomAlterStatement
    {
        public TriggerEnforcement TriggerEnforcement
        {
            get;
            set;
        }

        public bool All
        {
            get;
            set;
        }

        public IList<Identifier> TriggerNames
        {
            get;
            set;
        }
    }
}