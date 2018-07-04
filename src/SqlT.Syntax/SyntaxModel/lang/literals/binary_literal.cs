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

    using L = SqlSyntax.binary_literal;

    using sxc = contracts;
    
    partial class SqlSyntax
    {
        public struct binary_literal :  sxc.literal_value<byte[]>
        {
            static ModelTypeInfo model_type = ModelTypeInfo.Get<L>();

            public static implicit operator L(byte[] value)
                => new L(value);
            
            public static implicit operator byte[](L literal)
                => literal.value;


            public binary_literal(byte[] value)
            {
                this.value = value;
            }

            public byte[] value { get; }

            IModelType IModel.ModelType
                 => model_type;


            object sxc.literal_value.value
                => value;
        }
    }
}