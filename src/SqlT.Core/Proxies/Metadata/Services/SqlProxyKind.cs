//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    /// <summary>
    /// Specifies/classifies supported proxy types
    /// </summary>
    public enum SqlProxyKind
    {
        None,

        /// <summary>
        /// Identifies a column proxy
        /// </summary>
        Column,

        /// <summary>
        /// Identifies a parameter proxy
        /// </summary>
        Parameter,

        /// <summary>
        /// Identifies a table proxy
        /// </summary>
        Table,

        /// <summary>
        /// Identifies a view proxy
        /// </summary>
        View,

        /// <summary>
        /// Identifies a table type proxy
        /// </summary>
        TableType,

        /// <summary>
        /// Identifies a table-valued function proxy
        /// </summary>
        TableFuntion,

        /// <summary>
        /// Identifies a scalar function proxy
        /// </summary>
        ScalarFunction,

        /// <summary>
        /// Identifies a stored procedure proxy
        /// </summary>
        Procedure,

        /// <summary>
        /// Identifies a sequence proxy
        /// </summary>
        Sequence,

        /// <summary>
        /// Identifies a primary key proxy
        /// </summary>
        NamedResult,

        /// <summary>
        /// Identifies a primary key proxy
        /// </summary>
        PrimaryKey,

        /// <summary>
        /// Identifies a primary key column proxy
        /// </summary>
        PrimaryKeyColumn,

        /// <summary>
        /// Identifies a table-valued function result proxy
        /// </summary>
        TableFunctionResult,

        /// <summary>
        /// Identifies an interface that defines methods whose signatures are 
        /// derived from database routines
        /// </summary>
        OperationContract,

        /// <summary>
        /// Identifies an index proxy
        /// </summary>
        Index,

        /// <summary>
        /// Identifies an index column proxy
        /// </summary>
        IndexColumn,

        /// <summary>
        /// Identifies an index include column proxy
        /// </summary>
        IndexIncludeColumn,

        /// <summary>
        /// Identifies an interface that defines properties that correspond a the columns
        /// on a tabular object or a subset thereof
        /// </summary>
        DataContract

    }
}