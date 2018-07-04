//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.ComponentModel;
    using System.Collections.Generic;

    using System;
    using Meta.Core;
    using Meta.Models;
    using SqlT.Core;
    using SqlT.Services;
    using SqlT.Syntax;

    using static metacore;
    using static SqlT.Bindings.TypeStructures;

    using SqlT.Models;

    class SqlSpaceServices : ApplicationService<SqlSpaceServices, ISqlSpaceServices>, ISqlSpaceServices
    {

        public SqlSpaceServices(IApplicationContext C)
            : base(C)
        {


        }

        ISqlPackageManager PacMan
            => C.SqlPackageManager();

        ISqlGenerator SqlGenerator
            => C.SqlGenerator();

        ISqlModelScript ScriptModel(IModel model)
           => SqlGenerator.GenerateScript(model);


        IEnumerable<Type> MetaTypes(Assembly a)
            => from t in a.GetTypes()
               where t.Realizes<IElement>() && not(t.IsAbstract)
               select t;

        IEnumerable<IModel> MetaModels(Assembly a)
            => from t in MetaTypes(a)
               let factory = (IElement)Activator.CreateInstance(t)
               let model = factory.CreateModel()
               select model;

        Option<NodeFilePath> SaveToPackage(IEnumerable<ISqlScript> scripts, NodeFilePath DacPath)
            => PacMan.SaveToPackage(scripts, DacPath);

        public Option<NodeFilePath> ReifyModel(Assembly ModelProvider, NodeFilePath DacPath)
        {
            var modelScripts = MutableList.Create<ISqlScript>();
            var schemas = new MutableSet<SqlSchemaName>();
            foreach(var t in MetaTypes(ModelProvider))
            {
                var factory = (IElement)Activator.CreateInstance(t);
                if (factory is IObject)
                    schemas.Add((factory as IObject).Name.SchemaNamePart);

                modelScripts.Add(ScriptModel(factory.CreateModel()));
                
            }

            var schemaScripts = schemas.Select(s => ScriptModel(new SqlSchema(s)));
            var packageScripts = rolist(schemaScripts.Concat(modelScripts));
            return SaveToPackage(packageScripts, DacPath);
        }
    }
}
