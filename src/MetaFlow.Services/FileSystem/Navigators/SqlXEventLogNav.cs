//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License:MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Meta.Core;

    using MetaFlow.Core;

    using static metacore;

    using N = SystemNode;

    /// <summary>
    /// Dataset file navigator
    /// </summary>
    public class SqlXEventLogNav : FileSystemNavigator<SqlXEventLogNav>
    {
        public SqlXEventLogNav(IApplicationContext C, N Host)
            : base(C, Host)
        {
            this.NavRoot = ShareRoot(PlatformShareKind.XEV.ToString());
        }

        public override NodeFolderPath NavRoot { get; }

        public IEnumerable<NodeFilePath> XEventLogs
            => NavRoot.Files("Platform*.xel");



    }

}