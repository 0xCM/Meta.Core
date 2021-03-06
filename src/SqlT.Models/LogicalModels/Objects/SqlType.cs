﻿//-------------------------------------------------------------------------------------------
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



    public abstract class SqlType<T> : SqlObject<T>, sxc.ISqlType
        where T : SqlType<T>
    {
        public SqlType
        (
            SqlTypeName TypeName,
            IEnumerable<SqlPropertyAttachment> Properties = null,
            SqlElementDescription Documentation = null,
            bool IsNative = false,
            bool CanSpecifyLength = false,
            bool CanSpecifyPrecision = false,
            bool CanSpecifyScale = false,
            bool CanSpecifyNullability = true,
            bool IsTextType = false,
            bool IsAnsiTextType = false,
            bool IsUnicodeTextType = false
        ): base
            (
                TypeName, 
                Properties: Properties,
                Documentation : Documentation, 
                IsIntrinsic: IsNative
            )
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
        

        public SqlTypeName Name
            => (SqlTypeName)base.ObjectName;

        public virtual bool IsTextType { get; }

        public virtual bool IsAnsiTextType { get; }

        public virtual bool IsUnicodeTextType { get; }
            
        public bool Equals(sxc.ISqlDataType other)
            => object.ReferenceEquals(this, other);

    }



    public abstract class SqlType<T,N> : SqlObject<T,N>, sxc.ISqlType
        where T : SqlType<T,N>
        where N : SqlTypeName<N>, new()
    {
        protected SqlType(N Name)
            : base(Name)
        {

        }

        public SqlType
        (
            N TypeName,
            IEnumerable<SqlPropertyAttachment> Properties = null,
            SqlElementDescription Documentation = null,
            bool IsNative = false,
            bool CanSpecifyLength = false,
            bool CanSpecifyPrecision = false,
            bool CanSpecifyScale = false,
            bool CanSpecifyNullability = true,
            bool IsTextType = false,
            bool IsAnsiTextType = false,
            bool IsUnicodeTextType = false
        ) : base
            (
                TypeName,
                Properties: Properties,
                Documentation: Documentation            
            )
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
            => (SqlTypeName)base.ObjectName;




    }

}
