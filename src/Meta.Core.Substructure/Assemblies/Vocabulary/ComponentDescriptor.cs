//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.IO;

    public class ComponentDescriptor
    {
        static DateTime ChangedTS(string FilePath)
            => File.GetLastWriteTime(FilePath);

        public static ComponentDescriptor FromAssembly(Assembly a)
            => new ComponentDescriptor(
                ComponentId: a.GetSimpleName(),
                ComponentTitle: a.Title().ValueOrDefault(string.Empty),
                AreaId: a.DefiningArea(),
                DefiningSystem: a.DefiningSystem(),
                Classification: a.Classification(), Version: a.GetName().Version,
                CreatedTS: ChangedTS(a.Location));

        public ComponentDescriptor(ComponentIdentifier ComponentId, String ComponentTitle,
                ModuleArea AreaId, SystemIdentifier DefiningSystem,
                ComponentClassification Classification, Version Version, DateTime CreatedTS)
        {
            this.ComponentId = ComponentId;
            this.SystemId = DefiningSystem;
            this.Classification = Classification;
            this.Version = Version;
            this.CreatedTS = CreatedTS;
        }

        public ComponentIdentifier ComponentId { get; }

        public string ComponentTitle { get; }

        public ModuleArea AreaId { get; }

        public SystemIdentifier SystemId { get; }

        public ComponentClassification Classification { get; }

        public Version Version { get; }

        public DateTime CreatedTS { get; }

        public override string ToString()
            => $"{SystemId}/{Classification}/{ComponentId}?{nameof(Version)}={Version}";


    }
}