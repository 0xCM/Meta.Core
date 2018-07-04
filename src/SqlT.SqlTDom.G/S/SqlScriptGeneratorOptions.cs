////This file was generated 6/24/2017 12:42:27 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class SqlScriptGeneratorOptions : ISqlTDomElement
    {
        public KeywordCasing KeywordCasing
        {
            get;
            set;
        }

        public SqlVersion SqlVersion
        {
            get;
            set;
        }

        public int IndentationSize
        {
            get;
            set;
        }

        public bool IncludeSemicolons
        {
            get;
            set;
        }

        public bool AlignColumnDefinitionFields
        {
            get;
            set;
        }

        public bool NewLineBeforeFromClause
        {
            get;
            set;
        }

        public bool NewLineBeforeWhereClause
        {
            get;
            set;
        }

        public bool NewLineBeforeGroupByClause
        {
            get;
            set;
        }

        public bool NewLineBeforeOrderByClause
        {
            get;
            set;
        }

        public bool NewLineBeforeHavingClause
        {
            get;
            set;
        }

        public bool NewLineBeforeJoinClause
        {
            get;
            set;
        }

        public bool NewLineBeforeOffsetClause
        {
            get;
            set;
        }

        public bool NewLineBeforeOutputClause
        {
            get;
            set;
        }

        public bool AlignClauseBodies
        {
            get;
            set;
        }

        public bool MultilineSelectElementsList
        {
            get;
            set;
        }

        public bool MultilineWherePredicatesList
        {
            get;
            set;
        }

        public bool IndentViewBody
        {
            get;
            set;
        }

        public bool MultilineViewColumnsList
        {
            get;
            set;
        }

        public bool AsKeywordOnOwnLine
        {
            get;
            set;
        }

        public bool IndentSetClause
        {
            get;
            set;
        }

        public bool AlignSetClauseItem
        {
            get;
            set;
        }

        public bool MultilineSetClauseItems
        {
            get;
            set;
        }

        public bool MultilineInsertTargetsList
        {
            get;
            set;
        }

        public bool MultilineInsertSourcesList
        {
            get;
            set;
        }

        public bool NewLineBeforeOpenParenthesisInMultilineList
        {
            get;
            set;
        }

        public bool NewLineBeforeCloseParenthesisInMultilineList
        {
            get;
            set;
        }
    }
}