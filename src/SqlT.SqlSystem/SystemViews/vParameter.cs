//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{
    using System.Collections.Generic;

    using SqlT.Core;

    public class vParameter : vSystemElement, IParameter
    {
        readonly ISchema _Schema;
        readonly ISystemObject _Parent;
        readonly IParameter _Parameter;
        readonly vType _ParameterType;


        public vParameter
            (
                ISchema schema, 
                ISystemObject parent, 
                IParameter parameter, 
                vType type,  
                IEnumerable<IExtendedProperty> properties
            )
            : base(parameter.name, parent.is_user_defined)
        {
            this._Schema = schema;
            this._Parent = parent;
            this._Parameter = parameter;
            this._ParameterType = type;
        }

        public int ParentId
            => _Parent.object_id;

        public override string ToString() 
            => $"{Name} {_ParameterType}";

        public TypeReference ParameterType 
            => new TypeReference
        (
            ReferencedType: _ParameterType,
            IsNullable: _Parameter.is_nullable ?? true,
            MaxDataLength: _Parameter.max_length,
            Precision: _Parameter.precision,
            Scale: _Parameter.scale
        );

        public int Position 
            => _Parameter.parameter_id;

        public bool IsNullable 
            => _Parameter.is_nullable ?? true;

        public short MaxLength 
            => _Parameter.max_length;

        public byte Precision 
            => _Parameter.precision;

        public byte Scale 
            => _Parameter.scale;

        public bool IsOutput 
            => _Parameter.is_output;

        public bool IsReadOnly 
            => _Parameter.is_readonly;

        public SqlParameterName ParameterName
            => new SqlParameterName(Name);

        #region IParameter

        int IParameter.object_id
               => _Parameter.object_id;

        int IParameter.parameter_id
             => _Parameter.parameter_id;

        byte IParameter.system_type_id
             => _Parameter.system_type_id;

        int IParameter.user_type_id
            => _Parameter.user_type_id;

        short IParameter.max_length
        {
            get
            {
                return _Parameter.max_length;
            }
        }

        byte IParameter.precision
        {
            get
            {
                return _Parameter.precision;
            }
        }

        byte IParameter.scale
        {
            get
            {
                return _Parameter.scale;
            }
        }

        bool IParameter.is_output
        {
            get
            {
                return _Parameter.is_output;
            }
        }

        bool IParameter.is_cursor_ref
        {
            get
            {
                return _Parameter.is_cursor_ref;
            }
        }

        bool IParameter.has_default_value
        {
            get
            {
                return _Parameter.has_default_value;
            }
        }

        bool IParameter.is_xml_document
        {
            get
            {
                return _Parameter.is_xml_document;
            }
        }

        object IParameter.default_value
        {
            get
            {
                return _Parameter.default_value;
            }
        }

        int IParameter.xml_collection_id
        {
            get
            {
                return _Parameter.xml_collection_id;
            }
        }

        bool IParameter.is_readonly
            => _Parameter.is_readonly;

        bool? IParameter.is_nullable
            => _Parameter.is_nullable;

        int? IParameter.encryption_type
            => _Parameter.encryption_type;

        string IParameter.encryption_type_desc
        {
            get
            {
                return _Parameter.encryption_type_desc;
            }
        }

        string IParameter.encryption_algorithm_name
        {
            get
            {
                return _Parameter.encryption_algorithm_name;
            }
        }

        int? IParameter.column_encryption_key_id
        {
            get
            {
                return _Parameter.column_encryption_key_id;
            }
        }

        string IParameter.column_encryption_key_database_name
            => _Parameter.column_encryption_key_database_name;

        #endregion
    }


}