////This file was generated 6/24/2017 12:42:27 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class FullTextPredicate : BooleanExpression, ISqlTDomElement
    {
        public FullTextFunctionType FullTextFunctionType
        {
            get;
            set;
        }

        public IList<ColumnReferenceExpression> Columns
        {
            get;
            set;
        }

        public ValueExpression Value
        {
            get;
            set;
        }

        public ValueExpression LanguageTerm
        {
            get;
            set;
        }

        public StringLiteral PropertyName
        {
            get;
            set;
        }
    }
}