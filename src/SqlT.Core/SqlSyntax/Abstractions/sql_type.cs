//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System.Collections.Generic;

    using Meta.Models;
    using SqlT.Core;
    using SqlT.Models;

    using sxc = contracts;

    public abstract class sql_type<t,n> : sql_object<t,n>, sxc.ISqlType
        where t : sql_type<t,n>
        where n : sxc.type_name, new()
    {
        public sql_type
        (
            n TypeName,
            bool IsNative = false,
            bool CanSpecifyLength = false,
            bool CanSpecifyPrecision = false,
            bool CanSpecifyScale = false,
            bool CanSpecifyNullability = true,
            bool IsTextType = false,
            bool IsAnsiTextType = false,
            bool IsUnicodeTextType = false
        ): base(TypeName)
        {
            this.CanSpecifyLength = CanSpecifyLength;
            this.CanSpecifyPrecision = CanSpecifyPrecision;
            this.CanSpecifyScale = CanSpecifyScale;
            this.CanSpecifyNullability = CanSpecifyNullability;
            this.IsUnicodeTextType = IsUnicodeTextType;
            this.IsAnsiTextType = IsAnsiTextType;
            this.IsTextType = IsTextType;
           
        }

        public virtual bool CanSpecifyLength { get; }

        public virtual bool CanSpecifyPrecision { get; }

        public virtual bool CanSpecifyScale { get; } 

        public virtual bool CanSpecifyNullability { get; }
        
        public virtual bool IsTextType { get; }

        public virtual bool IsAnsiTextType { get; }

        public virtual bool IsUnicodeTextType { get; }

        SqlTypeName IModel<SqlTypeName>.Name
            => this.Name.AsTypeName();

        public bool Equals(sxc.ISqlDataType other)
            => object.ReferenceEquals(this, other);

    }
}
