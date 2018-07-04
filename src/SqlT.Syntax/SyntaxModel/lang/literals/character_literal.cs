//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using SqlT.Core;
    using V = System.Char;
    using L = SqlSyntax.character_literal;

    using sxc = contracts;

    using Meta.Models;

    partial class SqlSyntax
    {
        public struct character_literal : sxc.literal_value<V>
        {
            public character_literal(V value)
            {
                this.value = value;
            }

            static ModelTypeInfo model_type = ModelTypeInfo.Get<L>();

            public static implicit operator L(V value)
                => new L(value);

            public static implicit operator V(L literal)
                => literal.value;

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