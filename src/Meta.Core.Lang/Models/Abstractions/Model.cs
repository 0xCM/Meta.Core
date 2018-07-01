//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Models
{
    using System;

   
    public abstract class Model<m> : IModel
        where m : Model<m>
    {
        public static readonly IModel empty
            = empty_model<m>.empty;

        static ModelTypeInfo ModelType 
            = new ModelTypeInfo(typeof(m));

        IModelType IModel.ModelType
            => ModelType;

        protected Model()
        { }

        public virtual bool IsEmpty
            => object.ReferenceEquals(this, empty);
    }

}
