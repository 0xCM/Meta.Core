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

    using static metacore;

    using sxc = SqlT.Syntax.contracts;

    public abstract class vObject : vSystemElement, ISystemObject
    {

        static IReadOnlyDictionary<string, IExtendedProperty> Index(ISystemObject subject, IEnumerable<IExtendedProperty> properties)
            => properties.Where(x => x.major_id == subject.object_id && x.minor_id == 0).ToDictionary(x => x.name);

        protected vObject(ISchema schema, ISystemObject sysobject, IEnumerable<IExtendedProperty> properties) 
            : base(sysobject.name, Index(sysobject,properties), sysobject.is_user_defined)
        {
            this._schema = schema;
            this._object = sysobject;
        }

        ISystemObject _object { get; }

        ISchema _schema { get; }

        public string SchemaName 
            => _schema.name;

        public DateTime CreatedDate 
            => _object.create_date;

        public DateTime ModifiedDate 
            => _object.modify_date;

        public string ObjectType 
            => _object.type;

        public string ObjectTypeDescription 
            => _object.type_desc;

        public abstract sxc.ISqlObjectName ObjectName { get; }
            

        public override string ToString() 
            => $"{new SqlObjectName(SchemaName, Name)} {Documentation}";

        protected Option<SqlObjectName> GetResultContractName() 
            => Properties.ContainsKey(SqlPropertyNames.RecordContractType)
                ? SqlObjectName.Parse(((string)Properties[SqlPropertyNames.RecordContractType].value))
                : none<SqlObjectName>();

        #region ISystemObject
        string ISystemElement.name 
            => _object.name;

        int ISystemObject.object_id 
                => _object.object_id;

        int ISystemObject.schema_id 
            => _object.schema_id;

        DateTime ISystemObject.create_date 
            => _object.create_date;

        DateTime ISystemObject.modify_date 
            => _object.modify_date;

        int ISystemObject.parent_object_id 
            => _object.parent_object_id;

        int? ISystemObject.principal_id 
            => _object.principal_id;

        string ISystemObject.type 
            => _object.type;

        string ISystemObject.type_desc 
            => _object.type_desc;

        bool ISystemObject.is_user_defined 
            => _object.is_user_defined;

        bool ISystemObject.is_ms_shipped 
            => _object.is_ms_shipped;
        
        #endregion ISystemObject

    }

}
