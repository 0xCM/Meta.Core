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
    using System.Resources;
    using System.Globalization;

    using static metacore;

    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.Formatting;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.CodeAnalysis.Scripting;
    using Microsoft.CodeAnalysis.CSharp.Scripting;

    public class CSharpScriptExecutor<TOut> : ApplicationComponent, ICSharpScriptExecutor<TOut>
    {
        public CSharpScriptExecutor(IApplicationContext C)
            : base(C)
        {

        }

        public Option<TOut> Execute(ICSharpScript input)
        {
            var options = ScriptOptions.Default;
            var script = CSharpScript.Create<TOut>(input.Body, options);
            var state = script.RunAsync().Result;

            return isNotNull(state.Exception)
                ? none<TOut>(state.Exception)
                : state.ReturnValue;

        }

        public Option<TOut> Execute(ICSharpScript input, ICSharpScriptGlobals globals)
        {
            var options = ScriptOptions.Default;
            var script = CSharpScript.Create<TOut>(input.Body, options, typeof(ICSharpScriptGlobals));
            var state = script.RunAsync(globals).Result;

            return isNotNull(state.Exception)
                ? none<TOut>(state.Exception)
                : state.ReturnValue;
        }
    }

}