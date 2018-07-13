//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using static minicore;


    public abstract class DataModule : CodeModule, IDataModule
    {

        protected DataModule(Type GenericTypeDefinition)
            : base(GenericTypeDefinition)
        {

        }


    }

    /// <summary>
    /// Base class for 1-parameter data type modules
    /// </summary>
    /// <typeparam name="M">The derived subypte</typeparam>
    /// <typeparam name="D">The data type</typeparam>
    public abstract class DataModule<M, D> : DataModule, IDataModule<M,D>        
        where M : DataModule<M, D>, new()

    {
        protected static readonly M ModuleInstance
            = new M();

        protected DataModule(Type GenericTypeDefinition)
            : base(GenericTypeDefinition)
        {

        }

    }

    /// <summary>
    /// Base class for 2-parameter data type modules
    /// </summary>
    /// <typeparam name="M">The derived subypte</typeparam>
    /// <typeparam name="D">The data type</typeparam>
    public abstract class FactoredDataModule<M, D> : DataModule, IFactoredDataModule<M,D>
        where M : FactoredDataModule<M, D>, new()

    {
        protected static readonly M ModuleInstance
            = new M();

        protected FactoredDataModule(Type GenericTypeDefinition)
            : base(GenericTypeDefinition)
        {

        }
    }

}