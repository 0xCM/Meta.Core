////This file was generated 6/24/2017 12:42:27 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class OpenJsonTableReference : TableReferenceWithAlias, ISqlTDomElement
    {
        public ValueExpression Variable
        {
            get;
            set;
        }

        public StringLiteral RowPattern
        {
            get;
            set;
        }

        public IList<SchemaDeclarationItemOpenjson> SchemaDeclarationItems
        {
            get;
            set;
        }
    }
}