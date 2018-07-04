//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Meta.Core;
    using Meta.Models;

    using SqlT.Models;
    using SqlT.Core;
    using SqlT.Syntax;
    using SqlT.Language;

    using static metacore;
    
    [Service(typeof(ISqlGenerator))]
    class SqlGenerationService : Service<ISqlGenerator>, ISqlGenerator
    {
        static SqlGeneratorFunction Create(MethodInfo method)
            => new SqlGeneratorFunction(
                (context, spec) => (ISqlModelScript)method.Invoke(null, new object[] { context, spec }));

        static ReadOnlyList<MethodInfo> GetCandidateGenerators()
            => new ReadOnlyList<MethodInfo>
            (
                from t in unionize(SqlTServices.Assembly.GetStaticTypes(),SqlTLanguage.Assembly.GetStaticTypes())
                from m in t.GetStaticMethods()
                where Attribute.IsDefined(m, typeof(SqlGAttribute))
                let parameters = m.GetParameters()
                where parameters.Length == 2
                select m
            );

        static string GetModelTypeIdentifier(Type ConcreteModelType)
        {
            var et = ConcreteModelType.GetCustomAttribute<SqlElementTypeAttribute>();
            return et != null
                    ? et.ModelTypeId
                    : ConcreteModelType.Name;
        }

        public static IReadOnlyDictionary<string, SqlGeneratorFunction> IdentifyGenerators()
        {
            var candidates = GetCandidateGenerators();
            var methods = (from m in candidates
                           let modelType = m.GetParameters()[1].ParameterType
                           where not(modelType.IsAbstract) && modelType.Realizes<IModel>()
                           select new
                           {
                               SpecificationType = GetModelTypeIdentifier(modelType),
                               GeneratorMethod = m
                           }).ToDictionary(x => x.SpecificationType, x => x.GeneratorMethod);
            return (methods.Map(kvp => (kvp.Key, Create(kvp.Value)))).ToReadOnlyDictionary();
        }

        static IReadOnlyDictionary<string, SqlGeneratorFunction> generators;

        static ISqlElementTypeLookup ElementTypes { get; }
        
        static SqlGenerationService()
        {
            generators = IdentifyGenerators();
            ElementTypes = SqlElementTypes.GetLookup();
        }

        ISqlGenerator Self { get; }

        ISqlGenerationContext GC { get; }

        public SqlGenerationService(IApplicationContext C)
            : base(C)
        {           

            Self = this;
            GC = C.SqlGenerationContext();
        }

        public SqlModelScript GenerateScript(IModel model)
        {

            var generator = generators.TryFind(model.ModelType.ModelTypeId);           

            if (generator)
                return generator.MapValueOrDefault(g => new SqlModelScript(g(GC, model)));
             else
                return new SqlModelScript(SqlName.Empty, model.ModelType, model.FormatSyntax());            
        }

        public SqlModelScript GenerateModelScript(IModel model)
            => GenerateScript(model);
    }
}
