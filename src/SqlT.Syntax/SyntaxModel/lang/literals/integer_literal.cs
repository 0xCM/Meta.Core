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
    using L = SqlSyntax.integer_literal;
    using V = System.Int64;

    partial class SqlSyntax
    {
        /// <summary>
        /// Defines the syntactic model for a SQL integer literal/constant
        /// </summary>
        [url("https://docs.microsoft.com/en-us/sql/t-sql/data-types/constants-transact-sql")]
        public struct integer_literal : sxc.literal_value<long>
        {
            public TypeCode type { get; }

            public long value { get; }

            static ModelTypeInfo model_type 
                = ModelTypeInfo.Get<L>();

            public static implicit operator L(byte value)
                => new L(value);

            public static implicit operator byte(L literal)
                => (byte)literal.value;

            public static implicit operator L(sbyte value)
                => new L(value);

            public static implicit operator sbyte(L literal)
                => (sbyte)literal.value;

            public static implicit operator L(short value)
                => new L(value);

            public static implicit operator short(L literal)
                => (short)literal.value;

            public static implicit operator L(ushort value)
                => new L(value);

            public static implicit operator ushort(L literal)
                => (ushort)literal.value;

            public static implicit operator L(int value)
                => new L(value);

            public static implicit operator int(L literal)
                => (int)literal.value;

            public static implicit operator L(uint value)
                => new L(value);

            public static implicit operator uint(L literal)
                => (uint)literal.value;

            public static implicit operator L(long value)
                => new L(value);

            public static implicit operator long(L literal)
                => literal.value;

            public static implicit operator L(ulong value)
                => new L((V)value);

            public static implicit operator ulong(L literal)
                => (ulong)literal.value;

            public integer_literal(byte value)
            {
                this.value = value;
                this.type = TypeCode.Byte;
            }

            public integer_literal(sbyte value)
            {
                this.value = value;
                this.type = TypeCode.SByte;
            }

            public integer_literal(short value)
            {
                this.value = value;
                this.type = TypeCode.Int16;
            }

            public integer_literal(ushort value)
            {
                this.value = value;
                this.type = TypeCode.UInt16;
            }

            public integer_literal(int value)
            {
                this.value = value;
                this.type = TypeCode.Int32;
            }

            public integer_literal(uint value)
            {
                this.value = value;
                this.type = TypeCode.UInt32;
            }

            public integer_literal(long value)
            {
                this.value = value;
                this.type = TypeCode.Int64;
            }

            public integer_literal(ulong value)
            {
                this.value = (long)value;
                this.type = TypeCode.UInt64;
            }


            IModelType IModel.ModelType
                => model_type;


            object sxc.literal_value.value
               => value;

            public override string ToString()
                => value.ToString();
        }
    }
}