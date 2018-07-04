namespace SqlT.Types
{
    using System;
    using System.Collections.Generic;
    using SqlT.Core;


    [SqlDataContract]
    public interface ISystemRowVersion
    {
        SqlRowVersion SystemRV { get; }
    }

    [SqlDataContract]
    public interface ILogTable : ISystemRowVersion
    {
        long EntryId { get; }

        DateTime LoggedTS { get; }
    }


    /// <summary>
    /// Declares the columns defined by the SqlT schema
    /// </summary>
    [SqlDataContract()]
    public interface ITypeTable
    {
        [SqlColumn("Identifier", 0), SqlTypeFacets("nvarchar", false, 150)]
        string Identifier
        {
            get;
            set;
        }

        [SqlColumn("Label", 1), SqlTypeFacets("nvarchar", true, 150)]
        string Label
        {
            get;
            set;
        }

        [SqlColumn("Description", 2), SqlTypeFacets("nvarchar", true, 500)]
        string Description
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the SqlT schema
    /// </summary>
    [SqlDataContract()]
    public interface ITinyTypeTable
    {
        [SqlColumn("TypeCode", 0), SqlTypeFacets("tinyint", false)]
        byte TypeCode
        {
            get;
            set;
        }

        [SqlColumn("Identifier", 1), SqlTypeFacets("nvarchar", false, 150)]
        string Identifier
        {
            get;
            set;
        }

        [SqlColumn("Label", 2), SqlTypeFacets("nvarchar", true, 150)]
        string Label
        {
            get;
            set;
        }

        [SqlColumn("Description", 3), SqlTypeFacets("nvarchar", true, 500)]
        string Description
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the SqlT schema
    /// </summary>
    [SqlDataContract()]
    public interface ISmallTypeTable
    {
        [SqlColumn("TypeCode", 0), SqlTypeFacets("smallint", false)]
        short TypeCode
        {
            get;
            set;
        }

        [SqlColumn("Identifier", 1), SqlTypeFacets("nvarchar", false, 150)]
        string Identifier
        {
            get;
            set;
        }

        [SqlColumn("Label", 2), SqlTypeFacets("nvarchar", true, 150)]
        string Label
        {
            get;
            set;
        }

        [SqlColumn("Description", 3), SqlTypeFacets("nvarchar", true, 500)]
        string Description
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the SqlT schema
    /// </summary>
    [SqlDataContract()]
    public interface ILargeTypeTable
    {
        [SqlColumn("TypeCode", 0), SqlTypeFacets("int", false)]
        int TypeCode
        {
            get;
            set;
        }

        [SqlColumn("Identifier", 1), SqlTypeFacets("nvarchar", false, 150)]
        string Identifier
        {
            get;
            set;
        }

        [SqlColumn("Label", 2), SqlTypeFacets("nvarchar", true, 150)]
        string Label
        {
            get;
            set;
        }

        [SqlColumn("Description", 3), SqlTypeFacets("nvarchar", true, 500)]
        string Description
        {
            get;
            set;
        }
    }

}
// Emission concluded at 6/14/2017 11:27:52 AM
