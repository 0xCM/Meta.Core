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
    using SqlT.Syntax;

    using sxc = SqlT.Syntax.contracts;

    public class vUserPrimitive : vType
    {

        static IReadOnlyDictionary<string, IExtendedProperty> Index(IType subject, IEnumerable<IExtendedProperty> properties)
            => properties.Where(x => x.major_id == subject.user_type_id).ToDictionary(x => x.name);

        public vUserPrimitive(ISchema schema, IType type,  IEnumerable<IExtendedProperty> properties, vSystemPrimitive baseType)
            : base(schema, type, Index(type,properties))
        {
            this._baseType = baseType;
        }

        vSystemPrimitive _baseType { get; }

        public vSystemPrimitive BaseType 
            => _baseType;

        public override sxc.type_name TypeName
            => new SqlDataTypeName(SchemaName, Name);


        public override bool IsPrimitive 
            => true;

        public override bool IsUserPrimitive 
            => true;

        public override string ToString() 
            => $"{Name}({BaseType.Name})({MaxLength},{Precision},{Scale})";

    }


}