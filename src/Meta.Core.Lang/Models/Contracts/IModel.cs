//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Models
{
   
    public interface IModel
    {
        IModelType ModelType { get; }

    }


    /// <summary>
    /// Represents a named model
    /// </summary>                            
    public interface IModel<n> : IModel
        where n : IName, new()
    {
        n Name { get; }
    }


}