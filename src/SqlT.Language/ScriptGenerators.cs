//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
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
    

    using static metacore;
    using sxc = Syntax.contracts;
    using GC = ISqlGenerationContext;
    using sx = SqlT.Syntax.SqlSyntax;
    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    public static class ScriptGenerators
    {
        static Option<SqlElementSpecScript> DefineModelScript(this GC context, SqlSynonym model)
            => from m in some(model.TSqlCreate())
               let script = SqlElementSpecScript.Create(model.ObjectName, context.FindElementType(SqlElementTypeNames.Synonym), m.GenerateScript())
               select script;

        /// <summary>
        /// Produces <see cref="TSql.SqlScriptGenerator"/> that aligns with a specified SQL version
        /// </summary>
        /// <param name="version">The SQL version</param>
        /// <returns></returns>
        static TSql.SqlScriptGenerator ScriptGenerator(this TSql.SqlVersion version)
        {

            var g = none<TSql.SqlScriptGenerator>();
            var options = new TSql.SqlScriptGeneratorOptions { KeywordCasing = TSql.KeywordCasing.Lowercase };
            switch (version)
            {
                case TSql.SqlVersion.Sql140:
                    g = new TSql.Sql140ScriptGenerator(options);
                    break;
                case TSql.SqlVersion.Sql130:
                    g = new TSql.Sql130ScriptGenerator(options);
                    break;
                case TSql.SqlVersion.Sql120:
                    g = new TSql.Sql120ScriptGenerator(options);
                    break;
                case TSql.SqlVersion.Sql110:
                    g = new TSql.Sql110ScriptGenerator(options);
                    break;
            }
            return g.OnNone(() => throw new NotSupportedException()).ValueOrDefault();
        }

        /// <summary>
        /// Generates the script implied by the fragment
        /// </summary>
        /// <param name="src">The source script</param>
        /// <param name="sqlVersion">The source script SQL version</param>
        /// <returns></returns>
        public static SqlScript GenerateScript(this TSql.TSqlFragment src, TSql.SqlVersion? sqlVersion = null)
        {
            var generator = (sqlVersion ?? TSql.SqlVersion.Sql130).ScriptGenerator();
            var sql = String.Empty;
            generator.GenerateScript(src, out sql);
            return sql;
        }

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
        public static ISqlModelScript Generate(this GC context, IReadOnlyList<SqlColumnProxySelection> src)
            => new SqlQueryScript(context.FindElementType(SqlElementTypeNames.Unknown), src.TSqlSelectStatement().GenerateScript());

        [SqlG]
        public static ISqlModelScript Generate(this GC context, SqlModelScript src)
            => src;

        [SqlG]
        public static ISqlModelScript Generate(this GC context, SqlTableType src)
            => SqlElementSpecScript.Create(src.ObjectName, 
                    context.FindElementType(SqlElementTypeNames.TableType), 
                    src.TSqlCreate().GenerateScript());

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