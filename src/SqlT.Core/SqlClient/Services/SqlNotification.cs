//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Transactions;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Collections.Generic;


    public delegate void SqlNotificationObserver(SqlNotification notification);


    public class SqlNotification : ISqlNotification
    {
        public SqlNotification(string Source, string Detail, IEnumerable<SqlNotificationMessage> Parts)
        {
            this.Source = Source;
            this.Detail = Detail;
            this.Parts = Parts.ToList();
        }

        public IReadOnlyList<SqlNotificationMessage> Parts { get; }

        public string Detail { get; }

        public string Source { get; }

        public override string ToString()
            => Detail;
    }



}
