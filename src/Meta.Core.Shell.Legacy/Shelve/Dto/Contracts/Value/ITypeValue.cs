//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.DTO
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public interface ITypeValue 
    {
        /// <summary>
        /// The name of the type for which a value is being respresented
        /// and must uniquely resolve within the context of the model
        /// </summary>
        string TypeName { get; set; }

        /// <summary>
        /// The underlying value that can be converted to/from a value of the associated model type
        /// </summary>
        object ModeledValue { get; set; }
    }


    public interface ITypeValue<T> : ITypeValue
        where T : IDtoType
    {

    }


}
