//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;

    using Meta.Core;
    using SqlT.Core;
    using SqlT.Models;
    
    public class PlatformDac  
    {
        SqlPackageDescription PackageDescription { get; }

        public PlatformDac(SystemIdentifier DefiningSystem, SqlPackageDescription PackageDescription, 
            ComponentIdentifier ComponentId, Version ComponentVersion, DateTime ComponentTS)
        {
            this.DefiningSystem = DefiningSystem;
            this.PackageDescription = PackageDescription;
            this.ComponentId = ComponentId;
            this.ComponentVersion = ComponentVersion;
            this.ComponentTS = ComponentTS;            
        }
        
        public SystemIdentifier DefiningSystem { get; }

        public ComponentIdentifier ComponentId { get; }

        public Version ComponentVersion { get; }

        public DateTime ComponentTS { get; }

        public SqlPackageName PackageName
            => PackageDescription.PackageName;

        public override string ToString()
            => DefiningSystem.IsEmpty
            ? PackageName.ToString()
            : $"{DefiningSystem}/{PackageName}";
    }
}