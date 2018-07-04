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
    using System.IO;

    using Meta.Core;
    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Services;
    using SqlT.SqlSystem;

    using static metacore;
    using static ClrStructureSpec;
    using static GenerationMessages;

    /// <summary>
    /// Primary instrument for processing commands related to proxy generation
    /// </summary>
    [Service(typeof(ISqlProxyGenerator))]
    class SqlProxyGenerator : Service<ISqlProxyGenerator>, ISqlProxyGenerator
    {
        public SqlProxyGenerator(IApplicationContext C)
            : base(C)
        {

        }

        IJsonSerializer JsonSerializer
            => Service<IJsonSerializer>();

        static IEnumerable<IClrTypeSpec> SpecifyObjectProxies<V>(ISystemViewProvider svp, SqlProxyGenerationProfile gp, SqlProxySchemaSelection schema)
            where V : vObject
        {
            foreach (var o in svp.GetSchemaObjects<V>(schema.SchemaName))
            {
                foreach (var p in o.SpecifyProxyTypes(gp))
                {
                    yield return p;
                }
            }
        }

        static IEnumerable<vServiceMessageType> ServiceMessageTypes(ISystemViewProvider svp, SqlProxyGenerationProfile gp)
            => svp.GetVirtualView<vServiceMessageType>();
               
        static IEnumerable<vIndex> SelectDeclaredIndexes(ISystemViewProvider svp, SqlProxySchemaSelection schema)
            => from index in svp.GetVirtualView<vIndex>()
                   where 
                        index.ParentName.SchemaNamePart == schema.SchemaName
                     && not(index.IsPrimaryKey) 
                     && not(index.IsUniqueConstraint)
               select index;

        static IEnumerable<IClrTypeSpec> SpecifyIndexProxies(ISystemViewProvider svp, SqlProxyGenerationProfile gp, SqlProxySchemaSelection schema)
        {
            foreach (var ix in SelectDeclaredIndexes(svp, schema))
            {
                foreach (var p in ix.SpecifyProxyTypes(gp))
                {
                    yield return p;
                }
            }
        }

        static IEnumerable<ClassSpec> SpecifyServiceMessageTypeNameList(ISystemViewProvider svp, SqlProxyGenerationProfile gp)
        {
            var types = svp.GetVirtualView<vServiceMessageType>();
            if (types.Count != 0)
                yield return types[0].SpecifySqlNameList(gp, types);
        }


        static IEnumerable<ClassSpec> SpecifyIndexNameList(ISystemViewProvider svp, SqlProxyGenerationProfile gp, SqlProxySchemaSelection schema)
        {
            var indexes = SelectDeclaredIndexes(svp, schema).ToList();
            if (indexes.Count != 0)
                yield return indexes[0].SpecifySqlNameList(gp, indexes);
        }

        static IEnumerable<EnumSpec> SpecifyEnums(ISystemViewProvider svp, SqlProxyGenerationProfile gp, SqlProxySchemaSelection schema)
           =>   svp.GetSchemaObjects<vTable>(schema.SchemaName).SpecifyEnums(gp);


        static IEnumerable<ClassSpec> SpecifyObjectNameList<V>(ISystemViewProvider svp, SqlProxyGenerationProfile gp, SqlProxySchemaSelection schema)
            where V : vObject
        {
            var objects = svp.GetSchemaObjects<V>(schema.SchemaName);
            if (objects.Count != 0)
                yield return objects[0].SpecifySqlNameList(gp, objects);
        }

        static IEnumerable<ClassSpec> SpecifyTypeNameList<V>(ISystemViewProvider svp, SqlProxyGenerationProfile gp, SqlProxySchemaSelection schema)
            where V : vType
        {
            var types = svp.GetSchemaTypes<V>(schema.SchemaName);
            if (types.Count != 0)
                yield return types[0].SpecifySqlNameList(gp, map(types, o => o.TypeName));
        }

        static IEnumerable<IClrTypeSpec> SpecifyTableTypeProxies(ISystemViewProvider svp, SqlProxyGenerationProfile gp, SqlProxySchemaSelection schema)
        {
            var types = svp.GetSchemaTypes<vTableType>(schema.SchemaName);
            foreach (var type in types)
                foreach (var p in type.SpecifyProxyTypes(gp))
                    yield return p;
        }

        static IEnumerable<IClrTypeSpec> SpecifyOperationImplementations(IEnumerable<InterfaceSpec> contracts, SqlProxyGenerationProfile gp)
            => contracts.SpecifyContractImplementations(gp);
               
        static IEnumerable<IClrTypeSpec> SpecifyDataContracts(ISystemViewProvider svp, SqlProxyGenerationProfile gp, SqlProxySchemaSelection schema)
        {
            var types = MutableList.Create<vTableType>();
            if (gp.EmitTypeContracts)
                types.AddRange(svp.GetSchemaTypes<vTableType>(schema.SchemaName));
            return types.SpecifyDataContracts(gp);
        }

        static IEnumerable<IClrTypeSpec> SpecifyOperationContracts(ISystemViewProvider svp, SqlProxyGenerationProfile gp, SqlProxySchemaSelection schema)
        {
            var routines = MutableList.Create<vRoutine>();
            if (gp.EmitStoredProcedures)
                routines.AddRange(svp.GetSchemaObjects<vProcedure>(schema.SchemaName));
            if (gp.EmitTableFunctions)
                routines.AddRange(svp.GetSchemaObjects<vTableFunction>(schema.SchemaName));            
            return routines.SpecifyOperationContracts(gp);
        }

        static IEnumerable<Func<IEnumerable<IClrTypeSpec>>> SpecifyTypeFactories(ISystemViewProvider svp, SqlProxyGenerationProfile gp, SqlProxySchemaSelection schema)
        {
            var nep = new SqlNameEmissionProfile(gp);

            if (nep.EmitTableNames)
                yield return (() => SpecifyObjectNameList<vTable>(svp, gp, schema));

            if (nep.EmitTableTypeNames)
                yield return (() => SpecifyTypeNameList<vTableType>(svp, gp, schema));

            if (nep.EmitIndexNames)
                yield return (() => SpecifyIndexNameList(svp, gp, schema));

            if (nep.EmitPrimaryKeyNames)
                yield return (() => SpecifyObjectNameList<vPrimaryKey>(svp, gp, schema));

            if (nep.EmitViewNames)
                yield return (() => SpecifyObjectNameList<vView>(svp, gp, schema));

            if (nep.EmitSequenceNames)
                yield return (() => SpecifyObjectNameList<vSequence>(svp, gp, schema));

            if (nep.EmitServiceBrokerTypeNames)
                yield return (() => SpecifyServiceMessageTypeNameList(svp, gp));

            if (nep.EmitStoredProcedureNames)
                yield return (() => SpecifyObjectNameList<vProcedure>(svp, gp, schema));

            if (nep.EmitTableFunctionNames)
                yield return (() => SpecifyObjectNameList<vTableFunction>(svp, gp, schema));

            if (gp.EmitTableTypes)
                yield return (() => SpecifyTableTypeProxies(svp, gp, schema));
            
            if (gp.EmitTypeContracts)
                yield return (() => SpecifyDataContracts(svp, gp, schema));

            if (gp.EmitTables)
            {
                yield return (() => SpecifyObjectProxies<vTable>(svp, gp, schema));

                if (gp.EmitPrimaryKeys)
                    yield return (() => SpecifyObjectProxies<vPrimaryKey>(svp, gp, schema));

                if (gp.EmitIndexes)
                    yield return (() => SpecifyIndexProxies(svp, gp, schema));
            }

            if(gp.EmitEnums)
                yield return (() => SpecifyEnums(svp, gp, schema));

            if (gp.EmitViews)
                yield return (() => SpecifyObjectProxies<vView>(svp, gp, schema));

            if (gp.EmitStoredProcedures)
                yield return (() => SpecifyObjectProxies<vProcedure>(svp, gp, schema));

            if (gp.EmitTableFunctions)
                yield return (() => SpecifyObjectProxies<vTableFunction>(svp, gp, schema));

            if (gp.EmitOperationContracts)
            {
                var contracts = SpecifyOperationContracts(svp, gp, schema);
                yield return (() => contracts);

                if (gp.EmitOperationImplementations)
                    yield return (() => SpecifyOperationImplementations(contracts.OfType<InterfaceSpec>(), gp));
            }
        }

        static IReadOnlyList<IClrTypeSpec> SpecifyProxies(ISystemViewProvider svp, SqlProxyGenerationProfile gp,
            SqlProxySchemaSelection schema)
            => rolist(from f in SpecifyTypeFactories(svp, gp, schema)
                      from s in f()
                      select s);

        static CodeFileSpec SpecifyFile(ISystemViewProvider svp, SqlProxyGenerationProfile gp, vSchema schema, bool includePreamble)
        {
            var usings = gp.SpecifyUsings();
            var gpSchema = gp.Schemas.Single(y => y.SchemaName == schema.Name);
            var proxies = SpecifyProxies(svp, gp, gpSchema).ToList();
            var nsname = gp.SpecifyNamespaceName(gpSchema.SpecializeNamespace ? gpSchema.SchemaName : String.Empty);
            var ns = new NamespaceSpec(nsname, proxies, usings);
            return gp.SpecifyCodeFile(schema.Name, ns, includePreamble);
        }

        static CodeFileSpec SpecifyBrokerFactory(SqlProxyGenerationProfile gp)
        {
            var template = new TypeTemplateSpec
                (
                    TypeName: new ClrClassName(gp.BrokerFactoryName),
                    TemplateText: AssemblyResourceProvider.Get().FindTextResource("BrokerFactory.cs"),
                    Parameters: new[]{
                        new NamedValue("BROKER_FACTORY_NAME", gp.BrokerFactoryName),
                        new NamedValue("SOURCE_CATALOG", SqlConnectionString.Parse(gp.ConnectionString).DatabaseName)
                    }
                );
            var ns = new NamespaceSpec(gp.RootNamespace, array(template), gp.SpecifyUsings());
            var filename = ifBlank(gp.BrokerFactoryFileName, gp.BrokerFactoryName + ".cs");
            return new CodeFileSpec(filename, array<UsingSpec>(), ns);
        }

        public IReadOnlyList<FilePath> GenerateProxies(FilePath profilePath)
            => GenerateProxies(C.ObjectFromJson<SqlProxyGenerationProfile>(profilePath.ReadAllText()));

        public IReadOnlyList<FilePath> GenerateFieldLists(SqlFieldListGenerationProfile gp)
            => C.CSharpFieldListGenerator().GenerateFieldLists(gp);

        public IReadOnlyList<FilePath> GenerateProxies(SqlProxyGenerationProfile gp)
        {
            var svp = SqlSystemViews.Create(new SystemViewsSettings
                (
                    gp.ConnectionString,                
                    Filter: new SystemViewFilter
                    {
                        ExcludeSystemObjects = gp.ExcludeSystemObjects
                    }                    
                ));
           
            var schemaViews = svp.GetVirtualView<vSchema>()
                                 .Where(s => gp.SchemaIndex().ContainsKey(s.Name)).ToList();
            if (schemaViews.Count == 0)
                return rolist<FilePath>();

            var preamble = defer(() => gp.SpecifyFilePreamble());
            var files = MutableList.Create<CodeFileSpec>();

            for(int i=0; i< schemaViews.Count; i++)
            {
                var schema = schemaViews[i];
                Notify(DefiningProxies(schema.Name));
                files.Add(SpecifyFile(svp, gp, schema, true));
            }

            if (gp.EmitBrokerFactory)
                files.Add(SpecifyBrokerFactory(gp));

            if (gp.EmitGenerationSpec)
                gp.GetProfileOutPath().Write(JsonSerializer.ObjectToJson(gp));
                
            Notify(InitiatingProxyEmission());

            return gp.Emit(files, Notify);
        }
    }
}
