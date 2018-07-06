//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License:MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow.WF
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.SqlServer.XEvent.Linq;


    using SqlT.Core;
    using SqlT.Models;
    using MetaFlow.Core;
    using MetaFlow.XE;

    using static metacore;
    using N = SystemNode;


    static class ObserverX
    {
        public static SqlXEventDataset ToDataset(this PublishedEvent e)
            => new SqlXEventDataset(e.Name, e.UUID, e.Timestamp,
                e.Fields.Cast<PublishedEventField>().Select(f => new NamedValue(f.Name, f.Value)),
                e.Actions.Cast<PublishedAction>().Select(a => new NamedValue(a.Name, a.Value))
                );


        public static PlatformNotification ToPlatformNotification(this PublishedEvent e)
            => e.ToDataset().ToPlatformNotification();

    }

}