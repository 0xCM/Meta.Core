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

    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Syntax;
    using SqlT.SqlSystem;

    using static metacore;
    using static ClrStructureSpec;
    using ClrModel;
    
    /// <summary>
    /// Defines factory methods for <see cref="ConstructorSpec"/>
    /// </summary>
    public partial class SqlProxySpecifier
    {

        public static IEnumerable<ConstructorSpec> SpecifyConstructors<T>(this T subject, SqlProxyGenerationProfile gp)
            where T : vObject, IColumnProvider
        {
            var typeName = subject.SpecifyClassName();
            var properties = subject.Columns.SpecifyProperties(typeName, gp);
            return typeName.SpecifyStandardConstructors(properties);
        }

        public static IEnumerable<ConstructorSpec> SpecifyConstructors(this vIndex subject, SqlProxyGenerationProfile gp)
        {
            var typeName = subject.SpecifyClassName();
            var properties = subject.PrimaryColumns.SpecifyProperties(typeName, gp);
            return typeName.SpecifyStandardConstructors(properties);
        }

        public static IEnumerable<ConstructorSpec> SpecifyConstructors(this vTableFunction subject, SqlProxyGenerationProfile gp)
        {
            var typeName = subject.SpecifyClassName();
            var properties = subject.Parameters.SpecifyProperties(typeName, gp);
            return typeName.SpecifyStandardConstructors(properties);
        }

        public static IEnumerable<ConstructorSpec> SpecifyResultConstructors(this vTableFunction subject, SqlProxyGenerationProfile gp)
        {
            var typeName = subject.GetResultTypeName(gp);
            var properties = subject.Columns.SpecifyProperties(typeName, gp);
            return typeName.SpecifyStandardConstructors(properties);
        }

        public static IEnumerable<ConstructorSpec> SpecifyConstructors(this vProcedure subject, SqlProxyGenerationProfile gp)
        {
            var typeName = subject.SpecifyClassName();
            var properties = subject.Parameters.SpecifyProperties(typeName, gp);
            return typeName.SpecifyStandardConstructors(properties);
        }

        public static ConstructorSpec SpecifyNameConstructor(this vTable subject, SqlProxyGenerationProfile gp)
        {
            var typeName = new ClrClassName(ClrType.Get<SqlTableName>().TypeName.SimpleName);
            var constructor = new ConstructorSpec(
                DeclaringTypeName: typeName,
                AccessLevel: ClrAccessKind.Public,
                MethodParameters: stream
                (
                    new MethodParameterSpec("ServerNamePart", ClrType.Reference<string>(), 0),
                    new MethodParameterSpec("DatabaseNamePart", ClrType.Reference<string>(), 1),
                    new MethodParameterSpec("SchemaNamePart", ClrType.Reference<string>(), 2),
                    new MethodParameterSpec("UnqualifiedName", ClrType.Reference<string>(), 3)
                ));
            return constructor;
        }

        public static IEnumerable<ConstructorSpec> SpecifyConstructors(this vTableType subject, SqlProxyGenerationProfile gp)
        {
            var typeName = subject.SpecifyClassName();
            var properties = (subject as IColumnProvider).Columns.SpecifyProperties(typeName, gp);
            return typeName.SpecifyStandardConstructors(properties);
        }


    }
}