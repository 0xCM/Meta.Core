//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{

    using SqlT.Core;
    using static metacore;
    using sxc = SqlT.Syntax.contracts;

    public class TypeReference
    {
        public TypeReference(vType ReferencedType, bool IsNullable, short MaxDataLength, byte Precision, byte Scale)
        {
            this.ReferencedType = ReferencedType;
            this.IsNullable = IsNullable;
            this.MaxDataLength = MaxDataLength;
            this.Precision = Precision;
            this.Scale = Scale;
        }

        public vType ReferencedType { get; }

        public bool IsNullable { get; }

        public short MaxDataLength { get; }

        public byte Precision { get; }

        public byte Scale { get; }

        public bool IsUserDefined
            => ReferencedType.IsUserDefined;

        public bool IsPrimitive
            => ReferencedType.IsPrimitive;

        public bool IsAssemblyType
            => ReferencedType.IsAssemblyType;
        
        public Option<SqlTypeName> UnderlyingPrimitiveName
            => IsPrimitive
            ? some(IsUserDefined
                    ? (ReferencedType as vUserPrimitive).BaseType.TypeName as SqlTypeName
                    : (ReferencedType as vSystemPrimitive).TypeName as SqlTypeName
               )
            : none<SqlTypeName>();
            
        public Option<vSystemPrimitive> UnderlyingPrimitive
            => IsPrimitive
            ? (IsUserDefined
                    ? (ReferencedType as vUserPrimitive).BaseType
                    : (ReferencedType as vSystemPrimitive))
            : null;

        public bool IsRecord 
            => ReferencedType.IsTableType;

        public sxc.type_name TypeName
            => ReferencedType.IsTableType ?
                ReferencedType.TypeName
            : new SqlTypeName(SimpleTypeName);            

        public string SimpleTypeName
            => ReferencedType.TypeName.UnqualifiedName;

        public override string ToString()
            => toString(TypeName);
    }


}