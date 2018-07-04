//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Data.SqlClient;

    using static metacore;

    using SqlT.Core;


    public struct SqlMessageNumber : IConvertible
    {

        public int Value { get; }

        public static implicit operator int(SqlMessageNumber x)
            => x.Value;

        public static implicit operator SqlMessageNumber(int Value)
            => new SqlMessageNumber(Value);

        public SqlMessageNumber(int Value)
            => this.Value = Value;

        public override string ToString()
            => Value.ToString();

        IConvertible Convertible
            => (Value as IConvertible);


        TypeCode IConvertible.GetTypeCode()
            => Convertible.GetTypeCode();

        bool IConvertible.ToBoolean(IFormatProvider provider)
            => Convertible.ToBoolean(provider);

        char IConvertible.ToChar(IFormatProvider provider)
            => Convertible.ToChar(provider);

        sbyte IConvertible.ToSByte(IFormatProvider provider)
            => Convertible.ToSByte(provider);


        byte IConvertible.ToByte(IFormatProvider provider)
            => Convertible.ToByte(provider);

        short IConvertible.ToInt16(IFormatProvider provider)
            => Convertible.ToInt16(provider);

        ushort IConvertible.ToUInt16(IFormatProvider provider)
            => Convertible.ToUInt16(provider);

        int IConvertible.ToInt32(IFormatProvider provider)
            => Convertible.ToInt32(provider);

        uint IConvertible.ToUInt32(IFormatProvider provider)
            => Convertible.ToUInt32(provider);

        long IConvertible.ToInt64(IFormatProvider provider)
            => Convertible.ToInt64(provider);

        ulong IConvertible.ToUInt64(IFormatProvider provider)
            => Convertible.ToUInt64(provider);

        float IConvertible.ToSingle(IFormatProvider provider)
            => Convertible.ToSingle(provider);

        double IConvertible.ToDouble(IFormatProvider provider)
            => Convertible.ToDouble(provider);

        decimal IConvertible.ToDecimal(IFormatProvider provider)
            => Convertible.ToDecimal(provider);

        DateTime IConvertible.ToDateTime(IFormatProvider provider)
            => Convertible.ToDateTime(provider);

        string IConvertible.ToString(IFormatProvider provider)
            => Convertible.ToString(provider);

        object IConvertible.ToType(Type conversionType, IFormatProvider provider)
            => Convertible.ToType(conversionType, provider);


    }





}