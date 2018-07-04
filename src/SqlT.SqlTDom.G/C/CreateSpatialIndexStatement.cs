////This file was generated 6/24/2017 12:42:35 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class CreateSpatialIndexStatement : TSqlStatement, ISqlTDomCreateStatement
    {
        public Identifier Name
        {
            get;
            set;
        }

        public SchemaObjectName Object
        {
            get;
            set;
        }

        public Identifier SpatialColumnName
        {
            get;
            set;
        }

        public SpatialIndexingSchemeType SpatialIndexingScheme
        {
            get;
            set;
        }

        public IList<SpatialIndexOption> SpatialIndexOptions
        {
            get;
            set;
        }

        public IdentifierOrValueExpression OnFileGroup
        {
            get;
            set;
        }
    }
}