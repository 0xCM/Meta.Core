//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{

    public sealed class SqlReportServer : SqlServerNode<SqlReportServer>
    {
        public SqlReportServer(SystemNode Host, string InstanceName = null, int? Port = null, bool IsLocal = false)
            : base(Host, InstanceName, Port, IsLocal)
        {

        }

    }


}