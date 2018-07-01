//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Shell
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;

    public class PromptInputParser<C>
        where C : ProcessCommand<C>, new()
    {
        readonly PromptInputSyntax syntax;

        public PromptInputParser()
        {

            syntax = (PromptInputSyntax)typeof(C).GetField(nameof(syntax)).GetValue(null);
        }

        public C Parse(string input)
        {
            var instance = (C)Activator.CreateInstance(typeof(C), input);
            return instance;
        }


    }


}