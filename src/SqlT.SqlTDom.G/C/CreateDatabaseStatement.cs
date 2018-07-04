////This file was generated 6/24/2017 12:42:30 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    [Serializable()]
    public class CreateDatabaseStatement : TSqlStatement, ISqlTDomCreateStatement
    {
        public Identifier DatabaseName
        {
            get;
            set;
        }

        public ContainmentDatabaseOption Containment
        {
            get;
            set;
        }

        public IList<FileGroupDefinition> FileGroups
        {
            get;
            set;
        }

        public IList<FileDeclaration> LogOn
        {
            get;
            set;
        }

        public IList<DatabaseOption> Options
        {
            get;
            set;
        }

        public AttachMode AttachMode
        {
            get;
            set;
        }

        public Identifier DatabaseSnapshot
        {
            get;
            set;
        }

        public MultiPartIdentifier CopyOf
        {
            get;
            set;
        }

        public Identifier Collation
        {
            get;
            set;
        }
    }
}