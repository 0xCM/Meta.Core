//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using static metacore;
    using Meta.Core;

    public class PackageDeploymentFailed : SqlErrorNotification
    {
        public PackageDeploymentFailed()
        {

        }

        public PackageDeploymentFailed(NodeFilePath PackagePath, NodeFilePath ProfilePath, string Reason)
        {
            this.PackagePath = PackagePath;
            this.ProfilePath = ProfilePath;
            this.Reason = Reason;
        }

        public PackageDeploymentFailed(NodeFilePath PackagePath, string TargetDatabase, string TargetServer, string Reason)
        {
            this.PackagePath = PackagePath;            
            this.TargetDatabase = TargetDatabase;
            this.TargetServer = TargetServer;
            this.Reason = Reason;
        }

        public NodeFilePath PackagePath { get; set; }

        public Option<NodeFilePath> ProfilePath { get; set; }

        public string TargetDatabase { get; set; }

        public string TargetServer { get; set; }


        public string Reason { get; set; }

        public override string MessageDetail
            => ProfilePath.Map(p => $"Failed to deploy {PackagePath} according to the profile {p}: {Reason}",
            () => $"Failed to deploy {PackagePath} to {TargetDatabase} on {TargetServer}: {Reason}");


        public override string ToString()
            => MessageDetail;
    }
}
