////This file was generated 6/24/2017 12:42:31 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class ForeignKeyConstraintDefinition : ConstraintDefinition, ISqlTDomElement
    {
        public IList<Identifier> Columns
        {
            get;
            set;
        }

        public SchemaObjectName ReferenceTableName
        {
            get;
            set;
        }

        public IList<Identifier> ReferencedTableColumns
        {
            get;
            set;
        }

        public DeleteUpdateAction DeleteAction
        {
            get;
            set;
        }

        public DeleteUpdateAction UpdateAction
        {
            get;
            set;
        }

        public bool NotForReplication
        {
            get;
            set;
        }
    }
}