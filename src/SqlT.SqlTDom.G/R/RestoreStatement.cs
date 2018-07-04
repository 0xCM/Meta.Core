////This file was generated 6/24/2017 12:42:31 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class RestoreStatement : TSqlStatement, ISqlTDomStatement
    {
        public IdentifierOrValueExpression DatabaseName
        {
            get;
            set;
        }

        public IList<DeviceInfo> Devices
        {
            get;
            set;
        }

        public IList<BackupRestoreFileInfo> Files
        {
            get;
            set;
        }

        public IList<RestoreOption> Options
        {
            get;
            set;
        }

        public RestoreStatementKind Kind
        {
            get;
            set;
        }
    }
}