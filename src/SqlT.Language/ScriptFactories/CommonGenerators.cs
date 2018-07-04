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
    using System.Text;

    using Meta.Syntax;
    using Meta.Models;

    using SqlT.Models;
    using SqlT.Core;
    using SqlT.Language;
    using SqlT.Syntax;
    using SqlT.Templates;

    using static metacore;
    using sxc = Syntax.contracts;
    using GC = ISqlGenerationContext;
    using sx = SqlT.Syntax.SqlSyntax;

    public static class CommonGenerators
    {
        static Option<SqlElementSpecScript> DefineModelScript(this GC context, SqlSynonym model)
            => from m in some(model.TSqlCreate())
               let script = SqlElementSpecScript.Create(model.ObjectName, context.FindElementType(SqlElementTypeNames.Synonym), m.GenerateScript())
               select script;

        public static string Render(this SqlParameterizedScript script, 
            IReadOnlyDictionary<SqlParameterName, object> parameterValues)
        {
            var formatted = new Dictionary<string, string>();
            foreach (var kvp in parameterValues)
            {
                if (!script.ParameterNames.Contains(kvp.Key))
                    throw new ArgumentException($"The {script.ScriptName} supports no parameter named {kvp.Key}");
                formatted[kvp.Key] = SqlScript.FormatScriptValue(kvp.Value);
            }
            return script.Body.SpecifyParameters(formatted, false);
        }

        public static string Render(this SqlParameterizedScript script, 
            IEnumerable<SqlParameterValue> parameterValues)
        {
            var formatted = new Dictionary<string, string>();
            foreach (var parameterValue in parameterValues)
                formatted[parameterValue.ParameterName] = SqlScript.FormatScriptValue(parameterValue.AssignedValue);
            return script.Body.SpecifyParameters(formatted, false);
        }

        [SqlG]
        public static ISqlModelScript Generate(this GC context, SqlTruncateTable src)
            => new SqlQueryScript(src.Name, src.ModelType, src.TSqlStatement().GenerateScript());

        [SqlG]
        public static ISqlModelScript Generate(this GC context, SqlAlterIndex src)
            => new SqlQueryScript(src.ModelType, src.TSqlStatement().GenerateScript());

        [SqlG]
        public static ISqlModelScript Generate(this GC context, SqlVariableDeclaration src)
            => new SqlQueryScript(src.ModelType, src.TSqlStatement().GenerateScript());

        [SqlG]
        public static ISqlModelScript Generate(this GC context, SqlColumnStoreIndex src)
            => SqlElementSpecScript.Create(src.IndexName, 
                    context.FindElementType(SqlElementTypeNames.ColumnStoreIndex), 
                        src.TSqlCreate().GenerateScript());

        [SqlG]
        public static ISqlModelScript Generate(this GC context, SqlIndex src)
            => SqlElementSpecScript.Create(src.IndexName, 
                    context.FindElementType(SqlElementTypeNames.Index), 
                        src.TSqlCreate().GenerateScript());

        [SqlG]
        public static ISqlModelScript Generate(this GC context, sx.table_value_constructor src)
            => new SqlQueryScript((src as IModel).ModelType, src.TSqlCreate().GenerateScript());

        [SqlG]
        public static ISqlModelScript Generate(this GC context, SqlFileGroup src)
            => SqlElementSpecScript.Create(src.ElementName, 
                    context.FindElementType(SqlElementTypeNames.Filegroup), 
                        src.TSqlAddFileGroup().GenerateScript());

        [SqlG]
        public static ISqlModelScript Generate(this GC context, SqlSchema src)
            => SqlElementSpecScript.Create(src.Name, 
                    context.FindElementType(SqlElementTypeNames.Schema), 
                        src.TSqlCreate().GenerateScript());

        [SqlG]
        public static ISqlModelScript Generate(this GC context, SqlSynonym model)
              => context.DefineModelScript(model).ValueOrDefault();

        [SqlG]
        public static ISqlModelScript Generate(this GC context, SqlSequence src)
            => SqlElementSpecScript.Create(src.ObjectName, 
                    context.FindElementType(SqlElementTypeNames.Sequence), 
                        src.TSqlCreate().GenerateScript());

        [SqlG]
        public static ISqlModelScript Generate(this GC context, SqlProcedure model)
            => SqlElementSpecScript.Create(model.ObjectName,
                    context.FindElementType(SqlElementTypeNames.Procedure),
                    model.TSqlCreate().GenerateScript());

        [SqlG]
        public static ISqlModelScript Generate(this GC context, SqlMergeStatement src)
            => new SqlQueryScript(src.ModelType, src.TSqlStatement().GenerateScript());

        [SqlG]
        public static ISqlModelScript Generate(this GC context, SqlDropTable src)
            => new SqlQueryScript(src.ModelType, src.TSqlStatement().GenerateScript());

        [SqlG]
        public static ISqlModelScript Generate(this GC context, SqlRestoreDatabase src)
            => new SqlCommandScript(src, src.TSqlStatement().GenerateScript());

        [SqlG]
        public static ISqlModelScript Generate(this GC context, SqlDropSequence src)
            => new SqlQueryScript(src.ModelType, src.TSqlStatement().GenerateScript());

        [SqlG]
        public static ISqlModelScript Generate(this GC context, SqlDropIndex src)
            => new SqlQueryScript(src.ModelType, src.TSqlStatement().GenerateScript());
        

        [SqlG]
        public static ISqlModelScript Generate(this GC context, SqlDbBackupTemplate src)
         => new SqlCommandScript(src, src.TSqlStatement().GenerateScript());

        [SqlG]
        public static ISqlModelScript Generate(this GC context, SqlTable src)
            => SqlElementSpecScript.Create(src.ObjectName,
                    context.FindElementType(SqlElementTypeNames.Table),
                    src.TSqlCreate().GenerateScript());

        [SqlG]
        public static ISqlModelScript Generate(this GC context, SqlColumnProxyList src)
            => new SqlQueryScript(src.ModelType, src.TSqlSelectStatement().GenerateScript());

        [SqlG]
        public static ISqlModelScript Generate(this GC context, SqlModelScript src)
            => src;

        [SqlG]
        public static ISqlModelScript Generate(this GC context, SqlTableType src)
            => SqlElementSpecScript.Create(src.ObjectName, 
                    context.FindElementType(SqlElementTypeNames.TableType), 
                    src.TSqlCreate().GenerateScript());

        [SqlG]
        public static ISqlModelScript Generate(this GC context, SqlObjectExists model)
        {
            var parameters = context.ParameterAttributions<SqlObjectExists>();
            var script = context.ScriptProvider.FindScript(model.ActionName);
            var argidx = model.GetTemplateArgIdx(parameters);
            var invocation = SqlActionInvocation.CreateInvocation(model, argidx);
            return (new SqlModelScript(new SqlName(model.ActionName), model.ModelType, script.Render(invocation.Arguments)));
        }

        [SqlG]
        public static ISqlModelScript Generate(this GC context, SqlCmdShell model)
        {
            var parameters = context.ParameterAttributions<SqlCmdShell>();
            return new SqlCommandScript(model, model.CreateInvocation(
                model.GetTemplateArgIdx(parameters)).TSqlExecuteStatement().GenerateScript());
        }

        [SqlG]
        public static ISqlModelScript Generate(this GC context, SqlView src)
        {
            var script = new SqlScript($"create view {src.ObjectName} as {src.DefiningQuery.ScriptText}");
            return SqlElementSpecScript.Create(src.ObjectName, context.FindElementType(SqlElementTypeNames.View), script);
        }

        [SqlG]
        public static ISqlModelScript Generate(this GC context, SqlDatabase model)
        {
            var tsql = model.TSqlCreate();
            var script = new StringBuilder();

            script.AppendLine(model.TSqlCreate().GenerateScript());
            script.AppendLine("GO");
            script.AppendLine(model.TSqlAlterDatabseSet().GenerateScript());
            
            return new SqlModelScript(model.ElementName, model.ModelType, script.ToString());
                        
            
        }
    }

}