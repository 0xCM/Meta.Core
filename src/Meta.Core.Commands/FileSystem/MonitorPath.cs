//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Commands
{
    [CommandSpec]
    public class MonitorPath : CommandSpec<MonitorPath, CorrelationToken>
    {
        public MonitorPath()
        {

        }

        public MonitorPath(FolderPath Path, ServiceIdentifier Receiver)
        {
            this.Path = Path;
            this.Receiver = Receiver;

        }

        [CommandParameter]
        public FolderPath Path { get; set; }

        [CommandParameter]
        public ServiceIdentifier Receiver { get; set; }


    }
}
