////This file was generated 6/24/2017 12:42:29 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class AlterTableChangeTrackingModificationStatement : AlterTableStatement, ISqlTDomAlterStatement
    {
        public bool IsEnable
        {
            get;
            set;
        }

        public OptionState TrackColumnsUpdated
        {
            get;
            set;
        }
    }
}