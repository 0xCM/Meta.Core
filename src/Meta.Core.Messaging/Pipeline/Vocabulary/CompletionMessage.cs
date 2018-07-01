//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Messaging
{
    using System;
    using System.Reflection;

    using System.Linq;
    using System.Collections.Generic;

    using static metacore;



    public sealed class CompletionMessage : Message<CompletionMessage, CorrelationToken>
    {

        public static CompletionMessage Create(CorrelationToken CT)
            => new CompletionMessage(CorrelationToken.Create($"echo completion:{CT.Text}"));

        public CompletionMessage()
            : base(CorrelationToken.Empty)
        { }

        CompletionMessage(CorrelationToken content)
            : base(content)
        {

        }

        protected override CorrelationToken ParseContent(string content)
            => CorrelationToken.Create(content.RightOf("echo completion:"));

        protected override CompletionMessage CreateMessage(CorrelationToken content)
            => Create(content);


    }

}