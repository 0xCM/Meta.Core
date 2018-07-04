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

    public class vSchema : vSystemElement, ISchema
    {
        static IReadOnlyDictionary<string, IExtendedProperty> Index(ISchema subject, IEnumerable<IExtendedProperty> properties)
            => properties.Where(x => x.major_id == subject.schema_id).ToDictionary(x => x.name);

        public vSchema(ISchema schema, IEnumerable<IExtendedProperty> properties)
            : base(schema.name, Index(schema, properties), schema.is_user_defined)
        {
            this._schema = schema;
        }

        ISchema _schema { get; }

        int ISchema.schema_id
            => _schema.schema_id;

        int? ISchema.principal_id
            => _schema.principal_id;

        bool ISchema.is_user_defined =>
                _schema.is_user_defined;


        public SqlSchemaName SchemaName
            => new SqlSchemaName(_schema.name);

    }

}
