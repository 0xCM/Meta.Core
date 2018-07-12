//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;


    public interface IClassModule
    {
        /// <summary>
        /// Constructs the type implemented by the module
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        Option<ConstructedType> ConsructType(params Type[] args);

        /// <summary>
        /// Specifies the module's corresponding open generic type
        /// </summary>
        Type GenericTypeDefinition { get; }

    }

    public interface IClassModule<M> : IClassModule
        where M : IClassModule<M>, new()
    {


    }


}