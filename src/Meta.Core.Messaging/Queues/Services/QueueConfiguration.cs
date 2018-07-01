//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Queues
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections.Concurrent;


    public class QueueConfiguration
    {
        public QueueConfiguration()
        {
            Transient = false;
            AutoAck = false;
        }

        public bool Transient { get; set; }

        public bool AutoAck { get; set; }

        public override string ToString()
            => string.Join(";",
                from p in GetType().GetDeclaredPublicProperties(MemberInstanceType.Instance)
                let value = p.GetValue(this)
                select $"{p.Name} = {value}");

    }


}