//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// 
// License:MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using MetaFlow.Core;    
    using Meta.Core;


    using static metacore;

    public class PlatformShare
    {

        static IEnumerable<ClrEnumLiteralInfo> ShareTypes
            => from l in ClrEnumInfo.FromType<PlatformShareKind>().Literals
               where l.Name.SimpleName != nameof(PlatformShareKind.None)
               select l;

        public static IEnumerable<PlatformShare> Potential(SystemNodeIdentifier Node)
            => from k in ShareTypes
               select new PlatformShare(Node, parseEnum<PlatformShareKind>(k.Name));

        public PlatformShare()
        {

        }

        public PlatformShare(SystemNodeIdentifier Node, PlatformShareKind ShareType, FolderName ShareName = null)
        {
            this.Node = Node;
            this.ShareType = ShareType;
            this.ShareFolderName = ShareFolderName ?? concat(Node.IdentifierText, ".", ShareType.ToString());
        }

        public SystemNodeIdentifier Node { get; set; }

        public PlatformShareKind ShareType { get; set; }

        public FolderName ShareFolderName { get; set; }

        public override string ToString()
            => ShareFolderName;
    }


}