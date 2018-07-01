//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Models
{
    using System;
    

    public sealed class ModelTypeInfo : IModelType
    {
        public static ModelTypeInfo Get<T>(string ModelTypeId = null)
            where T : IModel 
                => new ModelTypeInfo(typeof(T), ModelTypeId);

        public ModelTypeInfo(Type SpecifyingType, string ModelTypeId = null)
        {
            this.SpecifyingType = SpecifyingType;
            this.ModelTypeId = ModelTypeId ?? string.Empty;
        }

        public Type SpecifyingType { get; }

        public string ModelTypeId { get; }

        public bool IsSameAs(IModelType candiate)
            => ModelTypeId == candiate.ModelTypeId;
    }
}