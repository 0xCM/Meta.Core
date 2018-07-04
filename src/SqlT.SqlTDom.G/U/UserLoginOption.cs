////This file was generated 6/24/2017 12:42:29 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class UserLoginOption : TSqlFragment, ISqlTDomOption
    {
        public UserLoginOptionType UserLoginOptionType
        {
            get;
            set;
        }

        public Identifier Identifier
        {
            get;
            set;
        }
    }
}