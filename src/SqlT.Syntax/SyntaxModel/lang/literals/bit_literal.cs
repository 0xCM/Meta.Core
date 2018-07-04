//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using Meta.Models;
    using SqlT.Core;

    using V = System.Boolean;
    using L = SqlSyntax.bit_literal;
    using sxc = contracts;


    partial class SqlSyntax
    {
        public struct bit_literal : sxc.literal_value<V>
        {
            static ModelTypeInfo model_type = ModelTypeInfo.Get<L>();

            public static implicit operator L(V value)
                => new L(value);

            public static implicit operator V(L literal)
                => literal.value;

            public bit_literal(V value)
            {
                this.value = value;
            }

            public V value { get; }

            IModelType IModel.ModelType
                => model_type;


            object sxc.literal_value.value
               => value;

            public override string ToString()
                => value.ToString();

        }



    }
}