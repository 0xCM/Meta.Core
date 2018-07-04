//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Syntax;
    using SqlT.Core;
    using SqlT.Models;

    using sxc = contracts;
    using sx = SqlSyntax;
    using ops = SqlSyntax.sqlops;

    using static metacore;

    partial class SqlSyntax
    {
        public sealed class scalar_value : SyntaxExpression<scalar_value>, sxc.literal_value
        {
            

            public static implicit operator scalar_value(byte x)
                => new scalar_value(x);

            public static implicit operator scalar_value(byte? x)
                => new scalar_value(x);

            public static implicit operator scalar_value(short x)
                => new scalar_value(x);

            public static implicit operator scalar_value(short? x)
                => new scalar_value(x);

            public static implicit operator scalar_value(int x)
                => new scalar_value(x);

            public static implicit operator scalar_value(int? x)
                => new scalar_value(x);

            public static implicit operator scalar_value(long x)
                => new scalar_value(x);

            public static implicit operator scalar_value(long? x)
                => new scalar_value(x);

            public static implicit operator scalar_value(Date x)
                => new scalar_value(x);

            public static implicit operator scalar_value(Date? x)
                => new scalar_value(x);

            public static implicit operator scalar_value(DateTime x)
                => new scalar_value(x);

            public static implicit operator scalar_value(DateTime? x)
                => new scalar_value(x);

            public static implicit operator scalar_value(decimal x)
                => new scalar_value(x);

            public static implicit operator scalar_value(decimal? x)
                => new scalar_value(x);

            public static implicit operator scalar_value(bool x)
                => new scalar_value(x);

            public static implicit operator scalar_value(bool? x)
                => new scalar_value(x);

            public static implicit operator scalar_value(string x)
                => new scalar_value(x);

            public static implicit operator scalar_value(CoreDataValue x)
                => new scalar_value(x);

            public static implicit operator scalar_value(SqlVariant x)
                => new scalar_value(x);


            public scalar_value(CoreDataValue LiteralValue)
            {
                this.Value = LiteralValue;
            }

            public scalar_value(SqlVariant LiteralValue)
            {
                this.Value = LiteralValue;
            }

            public scalar_value(DBNull _)
            {
                this.Value = CoreDataValue.Empty;
            }

            public CoreDataValue Value { get; }


            object sxc.literal_value.value
                => Value.ToClrValue();

            public override string ToString()
            {
                if (Value.IsEmpty)
                    return "null";

                var quote = Value.DataType.ReferencedType.IsText
                             || Value.DataType.ReferencedType.IsTemporal
                             || Value.DataType.ReferencedType.DataTypeName == CoreDataTypes.Guid.DataTypeName;
                var format = quote ? enclose(Value.ToString(), "'") : Value.ToString();
                return format;
            }

        }
    }



}
