//This file was generated at 5/27/2018 10:01:44 AM using version 1.2018.3.11161 the SqT data access toolset.
namespace SqlT.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using SqlT.Core;

    public class SqlObjectTypeCodes : TypedItemList<SqlObjectTypeCodes, ObjectType>
    {
        public readonly static ObjectType AF = new ObjectType("AF", "Aggregate function(CLR)");
        public readonly static ObjectType C = new ObjectType("C", "CHECK constraint");
        public readonly static ObjectType D = new ObjectType("D", "DEFAULT(constraint or stand-alone)");
        public readonly static ObjectType ET = new ObjectType("ET", "External Table");
        public readonly static ObjectType F = new ObjectType("F", "FOREIGN KEY constraint");
        public readonly static ObjectType FN = new ObjectType("FN", "SQL scalar function");
        public readonly static ObjectType FS = new ObjectType("FS", "Assembly(CLR) scalar-function");
        public readonly static ObjectType FT = new ObjectType("FT", "Assembly(CLR) table-valued function");
        public readonly static ObjectType IF = new ObjectType("IF", "SQL inline table-valued function");
        public readonly static ObjectType IT = new ObjectType("IT", "Internal table");
        public readonly static ObjectType P = new ObjectType("P", "SQL Stored Procedure");
        public readonly static ObjectType PC = new ObjectType("PC", "Assembly(CLR) stored-procedure");
        public readonly static ObjectType PG = new ObjectType("PG", "");
        public readonly static ObjectType PK = new ObjectType("PK", "PRIMARY KEY constraint");
        public readonly static ObjectType R = new ObjectType("R", "Rule(old-style, stand-alone)");
        public readonly static ObjectType RF = new ObjectType("RF", "Replication-filter-procedure");
        public readonly static ObjectType S = new ObjectType("S", "System base table");
        public readonly static ObjectType SN = new ObjectType("SN", "Synonym");
        public readonly static ObjectType SO = new ObjectType("SO", "Sequence object");
        public readonly static ObjectType SQ = new ObjectType("SQ", "Service queue");
        public readonly static ObjectType TA = new ObjectType("TA", "Assembly(CLR) DML trigger");
        public readonly static ObjectType TF = new ObjectType("TF", "SQL table-valued-function");
        public readonly static ObjectType TR = new ObjectType("TR", "SQL DML trigger");
        public readonly static ObjectType TT = new ObjectType("TT", "Table type");
        public readonly static ObjectType U = new ObjectType("U", "Table(user-defined)");
        public readonly static ObjectType UQ = new ObjectType("UQ", "UNIQUE constraint");
        public readonly static ObjectType V = new ObjectType("V", "View");
        public readonly static ObjectType X = new ObjectType("X", "Extended stored procedure");
    }

    public class SqlTypeDescriptions : TypedItemList<SqlTypeDescriptions, DataType>
    {
        public readonly static DataType NTEXT = new DataType("NTEXT", null);
        public readonly static DataType NUMERIC = new DataType("NUMERIC", null);
        public readonly static DataType NVARCHAR = new DataType("NVARCHAR", null);
    }
}
// Emission concluded at 5/27/2018 10:01:44 AM
