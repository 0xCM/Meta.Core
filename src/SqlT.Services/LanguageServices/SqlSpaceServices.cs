//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Collections.Generic;
    
    using Meta.Core;
    using Meta.Models;
    using SqlT.Core;
    using SqlT.Services;

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
