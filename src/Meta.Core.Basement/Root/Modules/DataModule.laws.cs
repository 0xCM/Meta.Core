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
    /// Identifies a data module
    /// </summary>
    public interface IDataModule : ICodeModule
    {
        
    }

    /// <summary>
    /// Identifies a 1-parameter data module
    /// </summary>
    public interface IDataModule<M,D> : IDataModule
    {

    }

    /// <summary>
    /// Identifies a 2-parameter data module
    /// </summary>
    public interface IFactoredDataModule<M,D> : IDataModule
    {

    }


}