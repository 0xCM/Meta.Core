////This file was generated 6/24/2017 12:42:27 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class WithCtesAndXmlNamespaces : TSqlFragment, ISqlTDomElement
    {
        public XmlNamespaces XmlNamespaces
        {
            get;
            set;
        }

        public IList<CommonTableExpression> CommonTableExpressions
        {
            get;
            set;
        }

        public ValueExpression ChangeTrackingContext
        {
            get;
            set;
        }
    }
}