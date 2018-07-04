//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using SqlT.Core;

    public class SqlErrorNotification 
    {
        public SqlErrorNotification()
        {

        }


        public SqlErrorNotification(Exception e, SqlConnectionString Connector = null)
        {
            this.Exception = e;
            this.Connector = Connector;

        }

        public SqlConnectionString Connector { get; set; }

        public Exception Exception { get; set; }

        public string ErrorMessage { get; set; }

        public virtual string MessageDetail
            => ErrorMessage;

        public override string ToString()
            => MessageDetail;

        public IApplicationMessage ToAppMessage()
            => ApplicationMessage.Error(ToString());

    }




}