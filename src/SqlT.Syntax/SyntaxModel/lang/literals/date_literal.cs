//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;

    using Meta.Models;
    using SqlT.Core;

    using sxc = contracts;
    using L = SqlSyntax.date_literal;
    using V = System.Date;


    partial class SqlSyntax
    {
        public struct date_literal : sxc.literal_value<V>
        {
            static ModelTypeInfo model_type 
                = ModelTypeInfo.Get<L>();
    
            public static implicit operator L(V value)
                => new L(value);

            public static implicit operator V(L literal)
                => literal.value;

            public date_literal(V value)
            {
                this.value = value;
            }

            public V value { get; }

            public override string ToString()
                => value.ToIsoString();

            IModelType IModel.ModelType
                => model_type;


            object sxc.literal_value.value
               => value;
        }
    }
}