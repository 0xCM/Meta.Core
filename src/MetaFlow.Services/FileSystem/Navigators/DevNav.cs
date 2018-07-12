//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// 
// License:MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using Meta.Core;

    using static metacore;

    using N = SystemNode;

    using Meta.Core.Project;


    public class DevNav : FileSystemNavigator<DevNav>
    {

        protected static readonly FolderPathVariable DevRootVar = new FolderPathVariable("DevRoot");

        public DevNav(IApplicationContext C, N Host)
            : base(C, Host)
        {
            this.NavRoot = Host.NodeFolder(DevRootVar.ResolveValue().Require());
        }


        public override NodeFolderPath NavRoot { get; }
            
        public FolderPath DevAreaDir
            => NavRoot + FolderName.Parse("PDMS");

        public FolderPath ProjectSegmentDir(DevSegment Segment)
            => DevAreaDir + FolderName.Parse(Segment.Identifier);


    }


}