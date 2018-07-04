//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{
    using System.Collections.Generic;

    using SqlT.Core;
    using SqlT.Syntax;

    using sxc = SqlT.Syntax.contracts;

    public class vSystemPrimitive : vType
    {
        public vSystemPrimitive(ISchema schema, IType type)
            : base(schema, type, new Dictionary<string, IExtendedProperty>())
        {
        }


        public override sxc.type_name TypeName
            => new SqlDataTypeName(SchemaName, Name);

        public override bool IsPrimitive 
            => true;

        public override bool IsSystemPrimitive 
            => true;


    }
}
