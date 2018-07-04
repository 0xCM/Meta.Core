//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;

    /// <summary>
    /// Describes either a type or type reference depending on the context
    /// </summary>
    public class SqlTypeInfo
    {
        public SqlTypeInfo()
        {

        }


        public SqlTypeInfo(SqlTypeName TypeName, SqlTypeName BaseTypeName = null, bool? IsNullable = null, int? Length = null, byte? precision = null, byte? scale = null)
        {
            this.TypeName = TypeName;
            this.BaseTypeName = BaseTypeName ?? TypeName;
            this.IsNullable = IsNullable;
            this.Length = Length;
            this.Precision = Precision;
            this.Scale = Scale;
        }

        public SqlTypeName TypeName { get; set; }

        public SqlTypeName BaseTypeName { get; set; }

        public bool? IsNullable { get; set; }

        public byte? Precision { get; set; }

        public byte? Scale { get; set; }

        public int? Length { get; set; }
    }

}