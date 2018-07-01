//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
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