//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dac
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SqlT.Language;
    using SqlT.Core;
    using SqlT.Services;
    using SqlT.Syntax;
    using SqlT.Models;

    using DacM = Microsoft.SqlServer.Dac.Model;
    using DacX = Microsoft.SqlServer.Dac.Extensions.Prototype;



    public static class SqlScriptTranslation
    {

        static ISqlElementTypeLookup ElementTypeLookup { get; }
            = SqlElementTypes.GetLookup();

        public static IEnumerable<Option<SqlParameterizedScript>> SpecifyScripts(this DacX.TSqlTypedModel model)
        {
            var functions = model.GetDacObjects<DacX.TSqlTableValuedFunction>();
            foreach (var function in functions)
            {
                var script = function.GetScript();
                var parsed = SqlScript.FromText(script).ParseRoutineBody();
                yield return parsed;

            }
            var procs = model.GetDacObjects<DacX.TSqlProcedure>();
            foreach (var proc in procs)
            {
                var script = proc.GetScript();
                var parsed = SqlScript.FromText(script).ParseRoutineBody();
                yield return parsed;
            }
        }

        public static IEnumerable<ISqlElementSpecScript> SpecifyScripts(this DacM.TSqlModel dsql)
        {
            foreach (var o in dsql.GetObjects(DacM.DacQueryScopes.UserDefined))
            {
                if (o.TryGetScript(out string script))
                {

                    var type = ElementTypeLookup.Find(o.ObjectType.Name);
                    yield return SqlElementSpecScript.Create(o.Name.SpecifyElementName(), type, script);
                }
            }
        }

        public static Option<SqlScript> TrySpecifyScript(this DacM.TSqlObject dsql)
        {
            if (dsql.TryGetScript(out string script))
                return new SqlScript(script);
            else
                return null;

        }


        public static SqlScriptIndex SpecifyScriptIndex(this DacM.TSqlModel dsql)
            => new SqlScriptIndex(dsql.SpecifyScripts());


    }
}