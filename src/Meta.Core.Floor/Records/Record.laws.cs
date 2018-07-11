//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    
    /// <summary>
    /// Defines type-neutral record operations
    /// </summary>
    public interface IRecord
    {
        
        /// <summary>
        /// Presents the encapsulated data as an array of objects
        /// </summary>
        Index<object> ItemArray { get; }


        /// <summary>
        /// Specifies whether the record is empty
        /// </summary>
        bool IsEmpty { get; }
    }

    public interface IRecordMeta : IRecord
    {
        /// <summary>
        /// Specifies the number and types of the records' attributes
        /// </summary>
        Lst<ClrType> AttributeTypes { get; }

    }

    public interface IRecordMeta<R> : IRecordMeta
        where R : IRecord<R>, new()
    {
        /// <summary>
        /// Gets the canonical empty record of like kind
        /// </summary>
        /// <returns></returns>
        R GetEmpty();

    }


    public interface IRecord<R> : IRecord, IEquatable<R>
        where R : IRecord<R>, new()
    {
    }

    public interface IRecord<R,F> : IRecord<R>
        where R : IRecord<R,F>, new()
        where F : Delegate
    {

    }

    public interface IRecordMeta<R, F> : IRecord<R,F>, IRecordMeta<R>
        where R : IRecord<R, F>, new()
        where F : Delegate
    {
        /// <summary>
        /// Gets the factory instance that can construct other records of like kind
        /// </summary>
        /// <returns></returns>
        F GetFactory();

    }

    

}