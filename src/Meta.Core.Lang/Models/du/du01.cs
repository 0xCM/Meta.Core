//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Models
{

    using System;
    using System.Linq;
    
    public interface IDiscriminatedUnion : IModel
    {

        IModel selected_value { get; }
    }

    /// <summary>
    /// Single case discriminated union
    /// </summary>
    public class du<k1> : IDiscriminatedUnion
        where k1 : IModel
    {
        public static implicit operator du<k1>(k1 v1)
            => new du<k1>(v1);

        protected virtual IModel selected_value
            => v1.value;

        readonly IModelType model_type;

        protected du()
        {
            model_type = new ModelTypeInfo(GetType());
        }

        public du(k1 v1)
            :this()
        {
            this.v1 = v1;
        }
                

        public ModelOption<k1> v1 { get; }

        IModel IDiscriminatedUnion.selected_value
            => selected_value;

        IModelType IModel.ModelType
            => model_type;

        public override string ToString()
            => selected_value?.ToString() ?? String.Empty;
    }

    /// <summary>
    /// Single case conformed discriminated union
    /// </summary>
    public class cdu<k, k1> : du<k1>
        where k : IModel
        where k1 : IModel, k
    {
        protected cdu()
        {

        }

        public cdu(k1 v1)
            : base(v1)
        {

        }

        protected new k selected_value
            => (k)base.selected_value;
    }
}

