//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License:MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;

    using static metacore;

    using Meta.Core;

    using MetaFlow.XE;
    public static class PlatformNotificationExtensions
    {
        public static string Format(this PlatformNotification message)
        {
            var timestamp = message.timestamp.FormatTimestamp();
            var text = concat(timestamp, " ", message.client_hostname, "> ", message.message);
            return text;
        }

    }
}
