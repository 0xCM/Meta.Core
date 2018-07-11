//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    /// <summary>
    /// Represents a boolean/logical value in SQL
    /// </summary>
    public enum SqlBooleanValue : int
    {
        False = -1,
        Unknown = 0,
        True = 1
    }

    public enum ConditionalCreateResult
    {
        None = 0,
        Created = 1,
        NotCreated = 2
    }

    /// <summary>
    /// Classfies the existence of a SQL element
    /// </summary>
    public enum SqlElementExists
    {
        /// <summary>
        /// No such element
        /// </summary>
        No = 0,
        
        /// <summary>
        /// Extant
        /// </summary>
        Yes = 1
    }

    /// <summary>
    /// Classifes data flow direction with respect to proxies
    /// </summary>
    public enum SqlConversionDirection : byte
    {
        /// <summary>
        /// Indicates that a converter produces a value that is compatible with
        /// the standard transport types supported by ADO.NET
        /// </summary>
        ToTransport = 1,
        /// <summary>
        /// Indicates that a converter produces a value that is compatible with
        /// a CLR runtime type
        /// </summary>
        ToProxy = 2
    }

    public enum MonadicFlavour
    {
        Unspecified = 0,
        Outcome = 1,
        Option = 2,

    }

}