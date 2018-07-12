//This file was generated at 4/23/2018 10:03:19 PM using version 1.2018.3.36060 the SqT data access toolset.
namespace MetaFlow.Proxies.XE
{
    using MetaFlow.XE;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using SqlT.Core;

    public sealed class XEProcedureNames
    {
        public readonly static SqlProcedureName StorePlatformNotifications = "[XE].[StorePlatformNotifications]";
    }

    [SqlProcedure("XE", "StorePlatformNotifications")]
    public partial class StorePlatformNotifications : SqlProcedureProxy
    {
        [SqlParameter("@Notifications", 0, true, false), SqlTypeFacets("[XE].[PlatformNotification]", true)]
        public IEnumerable<PlatformNotification> Notifications
        {
            get;
            set;
        }

        public StorePlatformNotifications()
        {
        }

        public StorePlatformNotifications(object[] items)
        {
            Notifications = (IEnumerable<PlatformNotification>)items[0];
        }

        public StorePlatformNotifications(IEnumerable<PlatformNotification> Notifications)
        {
            this.Notifications = Notifications;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Notifications };
        }

        public override void SetItemArray(object[] items)
        {
            Notifications = (IEnumerable<PlatformNotification>)items[0];
        }
    }
}