////This file was generated 6/24/2017 12:42:31 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public abstract class BackupStatement : TSqlStatement, ISqlTDomStatement
    {
        public IdentifierOrValueExpression DatabaseName
        {
            get;
            set;
        }

        public IList<BackupOption> Options
        {
            get;
            set;
        }

        public IList<MirrorToClause> MirrorToClauses
        {
            get;
            set;
        }

        public IList<DeviceInfo> Devices
        {
            get;
            set;
        }
    }
}