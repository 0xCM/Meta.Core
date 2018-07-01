//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using static metacore;

using Meta.Core;

/// <summary>
/// A hierarchical set of values corresponding to folders in the file system
/// </summary>
public sealed class FolderTree : Tree<FolderTree, FolderPath>, ITree<FolderTree, FolderPath>
{
    public static readonly FolderTree None 
        = new FolderTree(FolderPath.None);

    static IEnumerable<FolderTree> RootTreeAt(FolderPath RootFolder)
    {
        var rootTree = new FolderTree(RootFolder);
        foreach (var child in DefineSubtrees(rootTree))
            yield return child;
    }

    static IEnumerable<FolderTree> DefineSubtrees(FolderTree ParentTree)
        => from f in ParentTree.AbsoluteLocation.GetFolders()
           select new FolderTree(ParentTree, f.FolderName);

    static IEnumerable<FolderTree> DefineSubtrees(FolderTree ParentTree, FolderName ChildFolder)
    {
        var childTree = new FolderTree(ParentTree, ChildFolder);
        foreach (var grandChild in DefineSubtrees(childTree))
            yield return grandChild;
    }

    ITree<FolderTree, FolderPath> Self { get; }

    public FolderTree(FolderPath Root)
        : base(t => RootTreeAt(Root))
    {
        this.Root = Root;
        this.FolderName = global::FolderName.None;
        this.RelativeLocation = RelativePath.None;
        this.Self = this;
    }

    public FolderTree(FolderTree Parent, FolderName Folder)
        : base(Parent, _ => DefineSubtrees(Parent, Folder))
    {
        this.Root = Parent.Root;
        this.FolderName = Folder;
        this.RelativeLocation = Parent.RelativeLocation + Folder;
    }

    protected override FolderPath GetContent()
        => AbsoluteLocation;

    public FolderPath Root { get; }

    public FolderName FolderName { get; }

    public RelativePath RelativeLocation { get; }

    public IEnumerable<FolderPath> Subfolders
        => Children.Select(c => c.Content);

    public IEnumerable<FolderTree> Subtrees
        => DefineSubtrees(this);

    public FolderPath AbsoluteLocation
        => Root + RelativeLocation;

    public IEnumerable<FilePath> ListFiles(string match = null, bool recursive = false)
        => AbsoluteLocation.Files(match,recursive);

    public Option<FolderTree> CreateFolder(FolderName child)
        => new FolderTree(this, child);

    public FolderTree CloneTree(FolderPath dstRoot,  bool cloneFiles = false, string fileMatch = null)
    {
        var srcFolder = this.AbsoluteLocation;
        var srcTree = this;
        var dstTree = new FolderTree(dstRoot);
        var dstSubFolder = dstRoot;

        var copyResults = MutableList.Create<FileCopyResult>();
        foreach(var srcSubFolder in srcFolder.GetFolders())
        {
            dstSubFolder += srcSubFolder.FolderName;
            srcSubFolder.Clone(dstSubFolder, 
                recursive: true, 
                cloneFiles: cloneFiles, 
                fileMatch: fileMatch
                );                
        }
        return dstTree;
    }
}
