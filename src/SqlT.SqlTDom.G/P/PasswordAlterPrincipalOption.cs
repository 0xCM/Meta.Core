////This file was generated 6/24/2017 12:42:33 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class PasswordAlterPrincipalOption : PrincipalOption, ISqlTDomOption
    {
        public Literal Password
        {
            get;
            set;
        }

        public Literal OldPassword
        {
            get;
            set;
        }

        public bool MustChange
        {
            get;
            set;
        }

        public bool Unlock
        {
            get;
            set;
        }

        public bool Hashed
        {
            get;
            set;
        }
    }
}