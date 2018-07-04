////This file was generated 6/24/2017 12:42:31 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class ColumnDefinition : ColumnDefinitionBase, ISqlTDomElement
    {
        public ScalarExpression ComputedColumnExpression
        {
            get;
            set;
        }

        public bool IsPersisted
        {
            get;
            set;
        }

        public DefaultConstraintDefinition DefaultConstraint
        {
            get;
            set;
        }

        public IdentityOptions IdentityOptions
        {
            get;
            set;
        }

        public bool IsRowGuidCol
        {
            get;
            set;
        }

        public IList<ConstraintDefinition> Constraints
        {
            get;
            set;
        }

        public ColumnStorageOptions StorageOptions
        {
            get;
            set;
        }

        public IndexDefinition Index
        {
            get;
            set;
        }

        public Nullable<GeneratedAlwaysType> GeneratedAlways
        {
            get;
            set;
        }

        public bool IsHidden
        {
            get;
            set;
        }

        public ColumnEncryptionDefinition Encryption
        {
            get;
            set;
        }

        public bool IsMasked
        {
            get;
            set;
        }

        public StringLiteral MaskingFunction
        {
            get;
            set;
        }
    }
}