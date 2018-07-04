//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{

    public class SqlNotificationMessage
    {
        public string Provider { get; set; }

        public int MessageId { get; set; }

        public byte State { get; set; }

        public byte MessageSeverity { get; set; }

        public string Server { get; set; }

        public string MessageContent { get; set; }

        public string Procedure { get; set; }

        public int LineNumber { get; set; }

    }




}