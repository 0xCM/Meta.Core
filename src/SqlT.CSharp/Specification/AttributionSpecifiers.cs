//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ComponentModel;

    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Syntax;
    using SqlT.SqlSystem;
    using SqlT.Services;
    using sxc = SqlT.Syntax.contracts;
    
    using static metacore;
    using static ClrStructureSpec;
    
    static class AttributionSpecifiers
    {
        public static AttributionSpec SpecifyFacetsAttribute(this TypeReference subject)
        {            
            if (isNull(subject.TypeName))
                throw new NullReferenceException(concat("The ", nameof(subject.TypeName), " property of ", toString(subject), " is null"));

            var intrinsic = SqlNativeTypes.TryFind(p => p.Name == subject.UnderlyingPrimitiveName);
            var datalen = intrinsic.Map(x => x.IsUnicodeTextType ?  (short)( subject.MaxDataLength / 2) : subject.MaxDataLength).ValueOrDefault();

            int? maxlen = intrinsic.Map(
                x => x.CanSpecifyLength
                   ? datalen
                   : (int?)null,
                   () => null
                   );

            byte? precision = intrinsic.Map(x
                => x.CanSpecifyPrecision
                    ? subject.Precision
                    : (byte?)null,
                    () => null
                    );

            byte? scale = intrinsic.Map(x
                => x.CanSpecifyScale
                    ? subject.Scale
                    : (byte?)null,
                    () => null
                    );

            var typeName = 
                  subject.IsUserDefined 
                  ? subject.TypeName.AsTypeName().FullName 
                  : subject.TypeName.UnqualifiedName;

            var idx = 0;
            var parameters = new List<AttributeParameterSpec>();
            parameters.Add(new AttributeParameterSpec(nameof(SqlTypeFacetsAttribute.TypeName), typeName, idx++));

            var udtUnderlyingType 
                    = subject.IsUserDefined 
                    ? subject.UnderlyingPrimitive 
                    : none<vSystemPrimitive>();

            udtUnderlyingType.OnSome(v =>
               parameters.Add(new AttributeParameterSpec(nameof(SqlTypeFacetsAttribute.UnderlyingTypeName), v.Name, idx++)));

            parameters.Add(new AttributeParameterSpec(nameof(SqlTypeFacetsAttribute.IsNullable), subject.IsNullable, idx++));

            if (maxlen != null)
                parameters.Add(new AttributeParameterSpec(nameof(SqlTypeFacetsAttribute.MaxLength), maxlen.Value, idx++));
            else if (scale != null || scale != null)
            {
                parameters.Add(new AttributeParameterSpec(nameof(SqlTypeFacetsAttribute.Precision), precision ?? -1, idx++));
                parameters.Add(new AttributeParameterSpec(nameof(SqlTypeFacetsAttribute.Scale), scale ?? -1, idx++));
            }

            return new AttributionSpec(nameof(SqlTypeFacetsAttribute), parameters.ToArray());
        }

        public static IReadOnlyList<AttributionSpec> SpecifyAttributions(this vColumn subject, int position)
            => array(
                new AttributionSpec(nameof(SqlColumnAttribute),
                    new AttributeParameterSpec(nameof(SqlColumnAttribute.ColumnName), subject.Name, 0),
                    new AttributeParameterSpec(nameof(SqlColumnAttribute.Position), position, 1)),
                    subject.DataType.SpecifyFacetsAttribute()
                );

        public static IReadOnlyList<AttributionSpec> SpecifyAttributions(this vPrimaryKeyColumn subject, int position)
            => array(
                new AttributionSpec(nameof(SqlPrimaryKeyColumnAttribute),
                    new AttributeParameterSpec(nameof(SqlPrimaryKeyColumnAttribute.ReferencedColumnName), subject.Name, 0),
                    new AttributeParameterSpec(nameof(SqlPrimaryKeyColumnAttribute.ReferencedColumnPosition), position, 1),
                    new AttributeParameterSpec(nameof(SqlPrimaryKeyColumnAttribute.KeyColumnPosition), subject.KeyColumnPosition - 1, 2)
                ));

        public static IReadOnlyList<AttributionSpec> SpecifyAttributions(this vIndexColumn subject, int position)
            => array(
                new AttributionSpec(nameof(SqlIndexColumnAttribute),
                    new AttributeParameterSpec(nameof(SqlIndexColumnAttribute.ReferencedColumnName), subject.Name, 0),
                    new AttributeParameterSpec(nameof(SqlIndexColumnAttribute.ReferencedColumnPosition), position, 1),
                    new AttributeParameterSpec(nameof(SqlIndexColumnAttribute.IndexColumnPosition), subject.IndexColumnPosition - 1, 2)
                ));

        public static IReadOnlyList<AttributionSpec> SpecifyAttributions(this vParameter subject )
            => array(
                new AttributionSpec(nameof(SqlParameterAttribute),
                    new AttributeParameterSpec(nameof(SqlParameterAttribute.ParameterName), subject.Name, 0),
                    new AttributeParameterSpec(nameof(SqlParameterAttribute.Position), subject.Position - 1, 1),
                    new AttributeParameterSpec(nameof(SqlParameterAttribute.IsStructured), subject.ParameterType.IsRecord, 2),
                    new AttributeParameterSpec(nameof(SqlParameterAttribute.IsOutput), subject.IsOutput, 3)),
                    subject.ParameterType.SpecifyFacetsAttribute()
                );

        public static IReadOnlyList<AttributionSpec> SpecifyAttributions(this vTable subject)
            => array(
                new AttributionSpec(nameof(SqlTableAttribute),
                    new AttributeParameterSpec(nameof(SqlTableAttribute.SchemaName), subject.SchemaName, 0),
                    new AttributeParameterSpec(nameof(SqlTableAttribute.ObjectName), subject.Name, 1)
                    ));

        public static IEnumerable<AttributionSpec> SpecifyAttributions(this vView subject)
            => array(
                new AttributionSpec(nameof(SqlViewAttribute),
                    new AttributeParameterSpec(nameof(SqlViewAttribute.SchemaName), subject.SchemaName, 0),
                    new AttributeParameterSpec(nameof(SqlViewAttribute.ObjectName), subject.Name, 1)
                    ));

        public static IEnumerable<AttributionSpec> SpecifyAttributions(this vTableType subject)
            => array(
                new AttributionSpec(nameof(SqlRecordAttribute),
                    new AttributeParameterSpec(nameof(SqlRecordAttribute.SchemaName), subject.SchemaName, 0),
                    new AttributeParameterSpec(nameof(SqlRecordAttribute.ObjectName), subject.Name, 1)
                    ));

        public static IEnumerable<AttributionSpec> SpecifyAttributions(this vPrimaryKey subject)
            => array(
                new AttributionSpec(nameof(SqlPrimaryKeyAttribute),
                    new AttributeParameterSpec(nameof(SqlPrimaryKeyAttribute.SchemaName), subject.SchemaName, 0),
                    new AttributeParameterSpec(nameof(SqlPrimaryKeyAttribute.ObjectName), subject.Name, 1),
                    new AttributeParameterSpec(nameof(SqlPrimaryKeyAttribute.TableName), subject.TableName.UnqualifiedName, 2)
                    ));

        public static IEnumerable<AttributionSpec> SpecifyAttributions(this vIndex subject)
            => array(
                new AttributionSpec(nameof(SqlIndexAttribute),
                    new AttributeParameterSpec(nameof(SqlIndexAttribute.ParentSchema), subject.ParentName.SchemaNamePart, 0),
                    new AttributeParameterSpec(nameof(SqlIndexAttribute.ParentName), subject.ParentName.UnqualifiedName, 1),
                    new AttributeParameterSpec(nameof(SqlIndexAttribute.IndexName), subject.Name, 2),
                    new AttributeParameterSpec(nameof(SqlIndexAttribute.IsUnique), subject.IsUniqueIndex, 3)
                    ));

        public static IEnumerable<AttributionSpec> SpecifyAttributions(this vProcedure subject)
            => array(
                new AttributionSpec(nameof(SqlProcedureAttribute),
                    new AttributeParameterSpec(nameof(SqlProcedureAttribute.SchemaName), subject.SchemaName, 0),
                    new AttributeParameterSpec(nameof(SqlProcedureAttribute.ObjectName), subject.Name, 1)
                    ));

        public  static IEnumerable<AttributionSpec> SpecifyAttributions(this vTableFunction subject)
            => array(
                new AttributionSpec(nameof(SqlTableFunctionAttribute),
                    new AttributeParameterSpec(nameof(SqlTableFunctionAttribute.SchemaName), subject.SchemaName, 0),
                    new AttributeParameterSpec(nameof(SqlTableFunctionAttribute.ObjectName), subject.Name, 1)
                    ));

        public static IEnumerable<AttributionSpec> SpecifyAttributions(this ElementDescription content, SqlProxyGenerationProfile gp)
            => array(new AttributionSpec(
                ClrClass.Get<DescriptionAttribute>().ClassName, 
                    new AttributeParameterSpec(nameof(DescriptionAttribute.Description), content.Text, 0)
                    ));

        public static IEnumerable<AttributionSpec> SpecifyResultAttributions(this vTableFunction subject, SqlProxyGenerationProfile gp)
            => array(
                new AttributionSpec(nameof(SqlTableFunctionResultAttribute),
                    new AttributeParameterSpec(nameof(SqlTableFunctionAttribute.SchemaName), subject.SchemaName, 0),
                    new AttributeParameterSpec(nameof(SqlTableFunctionAttribute.ObjectName), subject.Name, 1)
                    ));
    }

}