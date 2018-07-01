//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;

    using static metacore;
   
    partial class Distribution
    {        
        public sealed class AssemblyArtifact : DistributionArtifact<AssemblyArtifact>
        {
            public AssemblyArtifact(IDistributionSegment Segment, NodeFilePath ArtifactPath)
                : base(Segment, ArtifactPath)
            {
                Descriptor = from a in ClrAssembly.Get(ArtifactPath)
                             from d in a.Describe()
                             select d;
            }

            public Option<ComponentDescriptor> Descriptor { get; }

            /// <summary>
            /// Specifies the accompanying documentation file, if any
            /// </summary>
            public Option<NodeFilePath> DocumentationFile
                => from x in some(ArtifactPath.ChangeExtension(CommonFileExtensions.Xml))
                   where x.Exists()
                   select x;

            /// <summary>
            /// Specifies the accompanying configuration file, if any
            /// </summary>
            public Option<NodeFilePath> AppConfigFile
                => from x in some(ArtifactPath.AddExtension(CommonFileExtensions.AppConfig))
                   where x.Exists()
                   select x;

            /// <summary>
            /// Specifies the accompanying pdb file, if any
            /// </summary>
            public Option<NodeFilePath> PdbFile
                => from x in some(ArtifactPath.AddExtension(CommonFileExtensions.Pdb))
                   where x.Exists()
                   select x;
        }
    }
}