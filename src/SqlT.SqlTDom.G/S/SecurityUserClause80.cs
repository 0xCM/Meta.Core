////This file was generated 6/24/2017 12:42:28 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class SecurityUserClause80 : TSqlFragment, ISqlTDomElement
    {
        public IList<Identifier> Users
        {
            get;
            set;
        }

        public UserType80 UserType80
        {
            get;
            set;
        }
    }
}