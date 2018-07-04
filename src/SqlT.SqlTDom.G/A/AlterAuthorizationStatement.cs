////This file was generated 6/24/2017 12:42:28 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class AlterAuthorizationStatement : TSqlStatement, ISqlTDomAlterStatement
    {
        public SecurityTargetObject SecurityTargetObject
        {
            get;
            set;
        }

        public bool ToSchemaOwner
        {
            get;
            set;
        }

        public Identifier PrincipalName
        {
            get;
            set;
        }
    }
}