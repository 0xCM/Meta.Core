//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License:MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Meta.Core;

    using static metacore;
    using static NfsFolderNames;

    using N = SystemNode;

    /// <summary>
    /// Dataset file navigator
    /// </summary>
    public class DataSetNav : FileSystemNavigator<DataSetNav>
    {

        public DataSetNav(IApplicationContext C, NodeFolderPath NavRoot)
            : base(C.NodeContext(NavRoot.Node))
        {
            this.NavRoot = NavRoot;
            this.IncomingFolder = NavRoot + IncomingFolderName;
            this.OutgoingFolder = NavRoot + OutgoingFolderName;
            this.DefaultPort = DefaultPort;
        }

        public override NodeFolderPath NavRoot { get; }

        public NodeFolderPath IncomingFolder { get; }

        public NodeFolderPath OutgoingFolder { get; }

        public EndpointPort DefaultPort { get; }

        public NodeFolderPath RootFolder(EndpointPort Port)
            => Port == EndpointPort.Outgoing ? OutgoingFolder : IncomingFolder;

        public new IEnumerable<NodeFilePath> Files(EndpointPort Port, string match = null, bool recursive = false)
            => RootFolder(Port).Files(match, recursive);

        public Option<NodeFilePath> File(EndpointPort Port, FileName FileName)
            => RootFolder(Port).File(FileName);

        public IEnumerable<NodeFilePath> IncomingFiles(string match = null, bool recursive = false)
            => Files(EndpointPort.Incoming, match, recursive);

        public Option<NodeFilePath> IncomingFile(FileName FileName)
            => File(EndpointPort.Incoming, FileName);
            
        public IEnumerable<NodeFilePath> OutgoingFiles(string match = null, bool recursive = false)
            => Files(EndpointPort.Outgoing, match, recursive);

        public Option<NodeFilePath> OutgoingFile(FileName FileName)
            => File(EndpointPort.Outgoing, FileName);
    }

}