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

    static class PropertySpecifiers
    {
        static IEnumerable<vColumn> Filter(this IEnumerable<vColumn> columns, SqlProxyGenerationProfile gp)
            => from c in columns
               where not(gp.ExcludedColumns.Contains(c.Name, StringComparer.InvariantCultureIgnoreCase))
               select c;

        public static IReadOnlyList<PropertySpec> SpecifyProperties(this IEnumerable<vColumn> subjects, 
            ClrClassName DeclaringTypeName, SqlProxyGenerationProfile gp)
                => mapi(subjects.Filter(gp), (i,c) => c.SpecifyProperty(DeclaringTypeName, i, gp));

        public static IReadOnlyList<PropertySpec> SpecifyProperties(this IReadOnlyList<vParameter> subjects,
            IClrTypeName DeclaringTypeName, SqlProxyGenerationProfile gp)
                => mapi(subjects, (i,p) => p.SpecifyProperty(DeclaringTypeName, gp));

        public static IReadOnlyList<PropertySpec> SpecifyProperties(this IEnumerable<vPrimaryKeyColumn> subjects, 
            ClrClassName DeclaringTypeName, SqlProxyGenerationProfile gp)
                => mapi(subjects, (i,c) => c.SpecifyProperty(DeclaringTypeName, i, gp));

        public static IReadOnlyList<PropertySpec> SpecifyProperties(this IEnumerable<vIndexColumn> subjects, 
            ClrClassName DeclaringTypeName, SqlProxyGenerationProfile gp)
                => mapi(subjects, (i,c) => c.SpecifyProperty(DeclaringTypeName, i, gp));

        public static PropertySpec SpecifyProperty(this vIndexColumn subject,  ClrClassName DeclaringTypeName, int position, CodeGenerationProfile gp)
                => new AutoPropertySpec
                (

                    DeclaringTypeName,
                    Name: subject.SpecifyPropertyName(),
                    PropertyType: subject.SpecifyTypeReference(gp),
                    Documentation: subject.Documentation,
                    Attributions: subject.SpecifyAttributions(position),
                    AccessLevel: ClrAccessKind.Public
                );


        public static PropertySpec SpecifyProperty(this vPrimaryKeyColumn subject, ClrClassName DeclaringTypeName, int position, CodeGenerationProfile gp)
                => new AutoPropertySpec
                (
                    DeclaringTypeName,
                    Name: subject.SpecifyPropertyName(),
                    PropertyType: subject.SpecifyTypeReference(gp),
                    Documentation: subject.Documentation,
                    Attributions: subject.SpecifyAttributions(position),
                    AccessLevel: ClrAccessKind.Public
                );


        public static PropertySpec SpecifyProperty(this vColumn subject, ClrClassName DeclaringTypeName, int position,  CodeGenerationProfile gp)
                => new AutoPropertySpec
                (
                    DeclaringTypeName,
                    Name: subject.SpecifyPropertyName(),
                    PropertyType: subject.SpecifyTypeReference(gp),
                    Documentation: subject.Documentation,
                    Attributions: subject.SpecifyAttributions(position),
                    AccessLevel: ClrAccessKind.Public
                );

        public static PropertySpec SpecifyProperty(this vColumn subject, ClrInterfaceName DeclaringTypeName, int position, CodeGenerationProfile gp)
                => new AutoPropertySpec
                (
                    DeclaringTypeName,
                    Name: subject.SpecifyPropertyName(),
                    PropertyType: subject.SpecifyTypeReference(gp),
                    Documentation: subject.Documentation,
                    Attributions: subject.SpecifyAttributions(position),
                    AccessLevel: ClrAccessKind.Default
                );

        public static PropertySpec SpecifyProperty(this vParameter subject, IClrTypeName DeclaringTypeName, CodeGenerationProfile gp)
            => new AutoPropertySpec
                (
                   DeclaringTypeName,
                   Name: subject.SpecifyPropertyName(),
                   PropertyType: subject.SpecifyTypeReference(gp),
                   Documentation: subject.Documentation,
                   Attributions: subject.SpecifyAttributions(),
                   AccessLevel: ClrAccessKind.Public
                );




    }
}