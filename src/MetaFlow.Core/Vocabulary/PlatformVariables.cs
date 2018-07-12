//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License:MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using Meta.Core;
    using SqlT.Core;

    public class PlatformVariables : TypedItemList<PlatformVariables, ISymbolicVariable>
    {
        public static readonly EnvironmentVariable SystemNode = new EnvironmentVariable("SystemNode");
        public static readonly EnvironmentVariable OperatorName = new EnvironmentVariable("MetaFlowOperatorName");
        public static readonly EnvironmentVariable OperatorPass = new EnvironmentVariable("MetaFlowOperatorPass");
        public static readonly FolderPathVariable OpsRoot = new FolderPathVariable("OpsRoot");
        public static readonly FolderPathVariable DevRoot = new FolderPathVariable("DevRoot");
        public static readonly FolderPathVariable DistRootDir = new FolderPathVariable("DistRootDir");
        public static readonly FolderPathVariable DevAreaRootDir = new FolderPathVariable("DevAreaRoot");
        public static readonly FolderPathVariable DevOpsDir = new FolderPathVariable("DevOps");
       
        public static SqlUserCredentials PdmsOperatorCredentials
            => new SqlUserCredentials(new SqlUserName(OperatorName.ResolveValue().ValueOrDefault()), 
                        OperatorPass.ResolveValue().ValueOrDefault());

        public static FolderPath DistArchiveDir
            => DistRootDir.ResolveValue()
                              .MapValueOrDefault(distRoot 
                                => distRoot.Append(".a"),FolderPath.Empty);

        public static FolderPath DevAreaDir
            => DevAreaRootDir.ResolveValue()
                             .MapValueOrDefault(areaDir 
                                => areaDir + FolderName.Parse(nameof(MetaFlow)), FolderPath.Empty);

        public static FolderPath BuildLogDir
            => DevOpsDir.ResolveValue() .MapValueOrDefault(devDir 
                => devDir + RelativePath.Parse("build\\logs"), FolderPath.Empty);
    }

}