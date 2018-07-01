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

    public abstract class CorrelatedMessage<M> : ICorrelated
        where M : CorrelatedMessage<M>, new()
    {

        protected CorrelatedMessage(CorrelationToken C)
        {
            this.CT = CT;
        }

        protected CorrelatedMessage()
        {
            this.CT = CorrelationToken.Create();
        }


        public CorrelationToken CT { get; set; }

        CorrelationToken? ICorrelated.CT
            => CT;
    }


    public sealed class CorrelatedTextMessage : CorrelatedMessage<CorrelatedTextMessage>
    {

        public CorrelatedTextMessage()
        {

        }

        public CorrelatedTextMessage(string Text, CorrelationToken? CT = null)
            : base(CT ?? CorrelationToken.Create())
        {
            this.Text = Text;

        }

        public string Text { get; set; }

        public override string ToString()
            => Text;

    }

}
