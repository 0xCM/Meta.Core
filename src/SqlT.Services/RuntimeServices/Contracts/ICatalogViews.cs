//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;
    using SqlT.SqlSystem;

    public interface ICatalogViews 
    {

        IEnumerable<vSequence> SequenceCatalog { get; }

        IEnumerable<vIndex> IndexCatalog { get; }

        IEnumerable<vIndexColumn> IndexColumnCatalog { get; }

        IEnumerable<vTable> TableCatalog { get; }

        IEnumerable<vTableType> TableTypeCatalog { get; }

        IEnumerable<vView> ViewCatalog { get; }

        IEnumerable<vTableFunction> TableFunctionCatalog { get; }

        IEnumerable<vPrimaryKey> PrimaryKeyCatalog { get; }

        /// <summary>
        /// Specifies the names of the tables defined by the database
        /// </summary>
        IEnumerable<SqlTableName> TableNames { get; }

        /// <summary>
        /// Specifies the names of the views defined by the database
        /// </summary>
        IEnumerable<SqlViewName> ViewNames { get; }

        /// <summary>
        /// Specifies the names of the sequences defined by the database
        /// </summary>
        IEnumerable<SqlSequenceName> SequenceNames { get; }

    }

}