//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Runtime.CompilerServices;

    using static metacore;
    using static ClrStructureSpec;

    using SqlT.Models;
    using SqlT.Core;
    using SqlT.CSharp;
    using SqlT.Syntax;
    using SqlT.Services;

    using Meta.Core;
    using Meta.Core.Workflow;
    

    [WorkflowNode]
    public class SyntaxGenerators : WorkflowNode<int>
    {
        
        public SyntaxGenerators(IWorkflowContext C)
            : base(C)
        {


        }

        ISqlProxyBroker SyntaxBroker
            => SqlTSyntaxProxies.Instance.DefaultBroker().Require();

     
        public WorkFlowed<int> DefineFunctionTypes()
        {
            var typeTemplate = ScriptTemplate.Define("public sealed class @FunctionIdentifier : native_scalar_function<@FunctionIdentifier> { @FunctionIdentifier() : base(\"@FunctionName\") { } }");
            var valueTemplate = ScriptTemplate.Define("public static readonly T.@FunctionIdentifier @FunctionIdentifier = T.@FunctionIdentifier.get();");
            var sb = new StringBuilder();
            var functions = SyntaxBroker.Select(new NativeFunctions()).OnNone(Notify).Items();
            var typeClassName = "SqlFunctionTypes";

            string identifier(NativeFunction f)
                => f.FunctionName.Replace(" ", "_").Replace("@@", "@").Replace("$", string.Empty).Replace("sys.",string.Empty).ToUpper();

            sb.AppendLine($"//Generated @ {now()}");
            sb.AppendLine($"namespace SqlT.Syntax");
            sb.AppendLine(lbrace());
            sb.AppendLine($"{tab()}using Meta.Syntax;");
            sb.AppendLine($"{tab()}using T = {typeClassName};");
            sb.AppendLine($"{tab()}using sxc = {nameof(contracts)};");
            sb.AppendLine();

            sb.AppendLine($"{tab()}public static class {typeClassName}");
            sb.AppendLine($"{tab()}{lbrace()}");
            iter(functions, f =>
                sb.AppendLine($"{tab(2)}{typeTemplate.Expand(new { f.FunctionName, FunctionIdentifier = identifier(f)})}"));
            sb.AppendLine($"{tab()}{rbrace()}");
            sb.AppendLine();

            sb.AppendLine($"{tab()}public class SqlFunctions : TypedItemList<SqlFunctions, sxc.native_function>");
            sb.AppendLine($"{tab()}{lbrace()}");
            iter(functions, f =>
                sb.AppendLine($"{tab(2)}{valueTemplate.Expand(new { FunctionIdentifier = identifier(f) })}"));
            sb.AppendLine($"{tab()}{rbrace()}");
            sb.AppendLine();

            sb.AppendLine(rbrace());
            var outFolder = CommonFolders.DevArea(nameof(SqlT)).GetCombinedFolderPath("src\\SqlT.Syntax\\Generated");
            var outPath = outFolder + FileName.Parse($"{typeClassName}.cs");
            outPath.Write(sb.ToString());

            return 0;
        }

        public WorkFlowed<int> DefineKeywordTypes()
        {
            var kwTypeTemplate = ScriptTemplate.Define("public sealed class @KeywordName: keyword<@KeywordName> { @KeywordName() { } }");
            var kwValueTemplate = ScriptTemplate.Define("public static readonly kwt.@KeywordName @KeywordName = kwt.@KeywordName.get();");
            var sb = new StringBuilder();
            var keywords = list(SyntaxBroker.Select(new Keywords()).OnNone(Notify).Items().Select(x => x.KeywordName));

            var typeClassName = "SqlKeywordTypes";
            sb.AppendLine($"//Generated @ {now()}");
            sb.AppendLine($"namespace SqlT.Syntax");
            sb.AppendLine(lbrace());
            sb.AppendLine($"{tab()}using Meta.Syntax;");
            sb.AppendLine($"{tab()}using kwt = {typeClassName};");
            sb.AppendLine();

            sb.AppendLine($"{tab()}public static class {typeClassName}");
            sb.AppendLine($"{tab()}{lbrace()}");            
            iter(keywords, KeywordName =>
                sb.AppendLine($"{tab(2)}{kwTypeTemplate.Expand(new {KeywordName})}"));
            sb.AppendLine($"{tab()}{rbrace()}");
            sb.AppendLine();

            sb.AppendLine($"{tab()}partial class SqlSyntax");
            sb.AppendLine($"{tab()}{lbrace()}");
            iter(keywords, KeywordName =>
                sb.AppendLine($"{tab(2)}{kwValueTemplate.Expand(new {KeywordName})}"));
            sb.AppendLine($"{tab()}{rbrace()}");
            sb.AppendLine();

            sb.AppendLine(rbrace());

            var outFolder = CommonFolders.DevArea(nameof(SqlT)).GetCombinedFolderPath("src\\SqlT.Syntax\\Generated");
            var outPath = outFolder + FileName.Parse("SqlKeywordTypes.cs");
            outPath.Write(sb.ToString());

            return keywords.Count;
            
        }


    }

}

