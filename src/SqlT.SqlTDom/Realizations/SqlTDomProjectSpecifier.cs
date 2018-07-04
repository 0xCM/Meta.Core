//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dom
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;

    using static ClrStructureSpec;
    using MCP = Meta.Core.Project;

    using Meta.Core;

    using SqlT.Core;
    using SqlT.Models;
    using SqlT.CSharp;
    using SqlT.Services;


    using static metacore;


    class SqlTDomProjectSpecifier : ApplicationService<SqlTDomProjectSpecifier, ISqlTDomProjectSpecifier>, ISqlTDomProjectSpecifier
    {

        public static readonly ClrNamespaceName TopNamespace = "SqlT.SqlTDom";

        public static readonly IReadOnlyList<UsingSpec> Usings
            = rolist(
                new UsingSpec(nameof(System)),
                new UsingSpec("System.Collections.Generic")
                );


        public SqlTDomProjectSpecifier(IApplicationContext C)
            : base(C)
        {
            this.SpecifiedTypeNames = roset<string>();

        }
        
        CodeFileSpec DefineInFile(MCP.ProjectEmissionOptions ProjectOptions, RelativePath subfolder, FileName file, IEnumerable<IClrElementSpec> elements)
            => new CodeFileSpec
                (
                    ProjectOptions.ResolveFilePath(subfolder, file),
                    Preamble: new CodeFilePreamble($"//This file was generated {now()}"),
                    Usings: Usings,
                    ElementDefinitions: stream(TopNamespace.Include(elements))

                );



        IReadOnlySet<string> SpecifiedTypeNames { get; }


        bool IsSpecified(ClrType t)
            => SpecifiedTypeNames.Exists(s => s == t.Name);



        SqlTDomTypeDescriptor DescribeDomType(SqlTDomInfo SourceModel, ClrClass type)
            => new SqlTDomTypeDescriptor(SourceModel.DescribeEnclosedType(type))
            {
                TypeIsModeled = SourceModel.Classes.Any(c => c.Name == type.Name),
                TypeIsSpecified = IsSpecified(type),
                BaseTypeIsModeled = isNotNull(type.BaseType)
                    ? SourceModel.Classes.Any(c => c.Name == type.BaseType.Name) : false,
                BaseTypeIsSpecified = isNotNull(type.BaseType) && IsSpecified(type.BaseType)

            };


        IEnumerable<ClassSpec> SpecifyModelType(SqlTDomInfo SourceModel, ClrClass type)
        {

            var profile = DescribeDomType(SourceModel, type);

            if (not(profile.TypeIsSpecified) && profile.TypeIsModeled)
            {

                if (profile.ShouldSpecifyBaseType)
                    foreach (var b in SpecifyModelType(SourceModel, profile.BaseType))
                        yield return b;

                yield return new ClassSpec
                    (
                        Name: type.Name,
                        AccessLevel: ClrAccessKind.Public,
                        BaseTypes: profile.BaseTypeIsModeled
                            ? array(profile.BaseType.ClassName.ReferenceTypeClosure()) : null,
                        IsAbstract: type.IsAbstract,
                        Attributions: array(AttributionSpec.Specify<SerializableAttribute>()),
                        ImplicitRealizations: map(profile.ClassifyingInterfaces, i => i.InterfaceName),
                        Members: type.SpecifyProperties(true)
                    );
            }

        }

        IEnumerable<ClassSpec> SpecifyModelTypes(SqlTDomInfo SourceModel)
        {

            foreach (var c in SourceModel.Classes)
            {
                foreach (var t in SpecifyModelType(SourceModel,c))
                    yield return t;
            }
        }


        IEnumerable<CodeFileSpec> SpecifyEnums(SqlTDomInfo SourceModel, MCP.ProjectEmissionOptions ProjectOptions)
        {

            var specs = map(SourceModel.Enums, e => e.SpecifyStructure());
            foreach (var spec in specs)
                yield return DefineInFile(ProjectOptions, $"Enums\\{spec.Name.SimpleName.Value[0]}", $"{spec.Name}.cs", stream(spec));
        }


        IEnumerable<CodeFileSpec> SpecifyCodeFiles(SqlTDomInfo SourceModel, MCP.ProjectEmissionOptions ProjectOptions)
        {

            foreach (var spec in SpecifyEnums(SourceModel,ProjectOptions))
                yield return spec;

            foreach (var spec in SpecifyModelTypes(SourceModel))
                yield return DefineInFile(ProjectOptions, $"{spec.Name.SimpleName.Value[0]}", $"{spec.Name}.cs", stream(spec));
        }


        public Option<MCP.CSharpProject> SpecifyTSqlDomProject(SqlTDomInfo SourceModel, MCP.ProjectEmissionOptions ProjectOptions)
        {
            var code = SpecifyCodeFiles(SourceModel,ProjectOptions).ToList();
            return new MCP.CSharpProject(new DevProjectName("SqlT.Models.TSqlDom.csproj"), code, stream<MCP.DistributedArtifact>());                                 
        }
    }



}
