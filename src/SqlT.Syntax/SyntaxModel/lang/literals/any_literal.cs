//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using SqlT.Core;

    using Meta.Models;

    using static SqlSyntax;

    using sxc = contracts;    

    using L = SqlSyntax.any_literal;
    using V = 
        Meta.Models.du<
            SqlSyntax.binary_literal,
            SqlSyntax.bit_literal,
            SqlSyntax.character_literal,
            SqlSyntax.date_literal,
            SqlSyntax.datetime_literal,
            SqlSyntax.decimal_literal,
            SqlSyntax.float_literal,
            SqlSyntax.integer_literal,
            SqlSyntax.money_literal,
            SqlSyntax.string_literal,
            SqlSyntax.time_literal,
            SqlSyntax.symbolic_literal,
            SqlSyntax.uniqueidentifier_literal            
            >;

    partial class SqlSyntax
    {
        public struct any_literal : sxc.literal_value<V>
        {
            static ModelTypeInfo model_type
                = ModelTypeInfo.Get<L>();

            public static implicit operator L(V value)
                => new L(value);

            public static implicit operator V(L literal)
                => literal.value;

            public any_literal(V value)
            {
                this.value = value;
            }

            public V value { get; }

            public override string ToString()
                => value.ToString();

            IModelType IModel.ModelType
                => model_type;

            object sxc.literal_value.value
               => value;
        }
    }
}