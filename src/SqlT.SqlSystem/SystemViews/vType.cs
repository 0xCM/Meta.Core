//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using SqlT.Core;

    using sxc = SqlT.Syntax.contracts;

    public abstract class vType : vSystemElement, IType
    {

        protected vType(ISchema schema, IType type, IReadOnlyDictionary<string, IExtendedProperty> properties)
            : base(type.name, properties, type.is_user_defined)
        {
            this._type = type;
            this._schema = schema;
        }

        protected ISchema _schema { get; }

        protected IType _type { get; }

        public int SchemaId
            => _schema.schema_id;

        public int SystemTypeId
            => _type.system_type_id;

        public int UserTypeId
            => _type.user_type_id;

        public string SchemaName 
            => _schema.name;

        public byte Precision 
            => _type.precision;

        public byte Scale 
            => _type.scale;

        public short MaxLength 
            => _type.max_length;

        public abstract sxc.type_name TypeName { get; }

        public override string ToString() 
            => IsUserDefined ? $"{new SqlTypeName(SchemaName, Name)} {Documentation}" : Name;

        public virtual bool IsPrimitive 
            => false;

        public virtual bool IsTableType 
            => false;

        public virtual bool IsSystemPrimitive 
            => false;

        public virtual bool IsUserPrimitive 
            => false;

        public virtual bool IsAssemblyType 
            => false;

        string IType.collation_name
            => _type.collation_name;

        bool IType.is_assembly_type
            => _type.is_assembly_type;

        bool? IType.is_nullable
            => _type.is_nullable;

        bool IType.is_table_type
            => _type.is_table_type;

        short IType.max_length
            => _type.max_length;

        byte IType.precision
        {
            get
            {
                return _type.precision;
            }
        }

        byte IType.scale
        {
            get
            {
                return _type.scale;
            }
        }

        byte IType.system_type_id
        {
            get
            {
                return _type.system_type_id;
            }
        }

        int IType.user_type_id
        {
            get
            {
                return _type.user_type_id;
            }
        }

        bool IType.is_user_defined
        {
            get
            {
                return _type.is_user_defined;
            }
        }

        int IType.schema_id
        {
            get
            {
                return _type.schema_id;
            }
        }
    }

}