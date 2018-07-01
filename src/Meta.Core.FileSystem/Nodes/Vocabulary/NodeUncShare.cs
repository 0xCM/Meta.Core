//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
public class NodeUncShare : NodeResource<NodeUncShare>
{
    static string sep() => System.IO.Path.DirectorySeparatorChar.ToString();
    static string sep2() => sep() + sep();

    public NodeUncShare(SystemNode Node, UncRoot Root, FolderPath SharePath)
        : base(Node, SharePath.FullPath)
    {
        this.SharePath = SharePath;
        this.Root = Root;
        this.BasePath = SharePath;
    }

    public NodeUncShare(SystemNode Node, UncRoot Root)
        : this(Node, Root, new FolderPath($"{sep2()}{Node.NetworkName}{sep()}{Root}"))
    {
        
    }

    public UncRoot Root { get; }

    public FolderPath BasePath { get; }

    public FolderPath SharePath { get; }

    public FolderPath Subfolder(FolderName FolderName)
        => SharePath + FolderName;

    public FolderPath Subpath(RelativePath Subpath)
        => SharePath + Subpath;

    public FilePath FilePath(SystemResourceUrn Urn)
        => SharePath.GetCombinedFilePath(Urn);

    public override string ToString()
        => SharePath;

}
