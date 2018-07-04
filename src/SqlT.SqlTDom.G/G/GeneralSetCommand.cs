////This file was generated 6/24/2017 12:42:30 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class GeneralSetCommand : SetCommand, ISqlTDomElement
    {
        public GeneralSetCommandType CommandType
        {
            get;
            set;
        }

        public ScalarExpression Parameter
        {
            get;
            set;
        }
    }
}