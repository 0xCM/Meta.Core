//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

using Meta.Core;

public class NodeUncDrive : NodeResource<NodeUncDrive>
{
    public NodeUncDrive(SystemNode Node, UncRoot Root, char DriveLetter)
        : base(Node, DriveLetter.ToString())
    {
        this.Root = Root;
        this.Share = new NodeUncShare(Node, Root);
        this.DriveLetter = DriveLetter;
    }


    public NodeUncDrive(NodeUncShare Share, UncRoot Root, char DriveLetter)
        : this(Share.Node, Root, DriveLetter)
    {
        this.Share = Share;
    }

    public NodeUncDrive(NodeUncDrive Parent, FolderName Subfolder)
        : this(new NodeUncShare(Parent.Node, Parent.Root, Parent.Share.SharePath + Subfolder), Parent.Root, Parent.DriveLetter)
    {

    }

    public NodeUncDrive(NodeUncDrive Parent, SystemResourceUrn Urn)
        : this(new NodeUncShare(Parent.Node, Parent.Root, Parent.Share.SharePath + Urn), Parent.Root, Parent.DriveLetter)
    {

    }

    public NodeUncDrive(NodeUncDrive Parent, RelativePath Subpath)
        : this(new NodeUncShare(Parent.Node, Parent.Root, Parent.Share.SharePath + Subpath), Parent.Root, Parent.DriveLetter)
    {

    }

    public UncRoot Root { get; }

    public NodeUncShare Share { get; }

    public char DriveLetter { get; }

    public FolderPath UncPath
        => Share.SharePath;

    public FolderPath HostPath
        => UncPath.FileSystemPath.Replace(Share.BasePath.FileSystemPath, $"{DriveLetter}:");

    public NodeUncDrive Subfolder(FolderName Name)
        => new NodeUncDrive(this, Name);

    public IEnumerable<NodeUncDrive> Subfolders()
    {
        foreach (var folder in UncPath.GetFolders())
            yield return Subfolder(folder.FolderName);
    }

    public IEnumerable<FilePath> Content(string match = null)
        => UncPath.Files(match);

    public NodeUncDrive Subpath(RelativePath Name)
        => new NodeUncDrive(this, Name);

    public override string ToString()
        => $"{Share}";
}
