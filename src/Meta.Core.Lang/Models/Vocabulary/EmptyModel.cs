//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Models
{
    using System;

    public sealed class empty_model<m> : IModel
       where m : IModel

    {
        static ModelTypeInfo ModelType
            = new ModelTypeInfo(typeof(empty_model<m>));

        static readonly empty_model<m>
            _instance = new empty_model<m>();

        empty_model() { }

        public static readonly IModel empty
            = _instance;

        IModelType IModel.ModelType
            => ModelType;

    }


}