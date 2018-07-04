////This file was generated 6/24/2017 12:42:31 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class DbccStatement : TSqlStatement, ISqlTDomStatement
    {
        public string DllName
        {
            get;
            set;
        }

        public DbccCommand Command
        {
            get;
            set;
        }

        public bool ParenthesisRequired
        {
            get;
            set;
        }

        public IList<DbccNamedLiteral> Literals
        {
            get;
            set;
        }

        public IList<DbccOption> Options
        {
            get;
            set;
        }

        public bool OptionsUseJoin
        {
            get;
            set;
        }
    }
}