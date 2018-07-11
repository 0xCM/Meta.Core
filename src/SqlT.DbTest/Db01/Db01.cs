//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Bindings.Test
{
    using System;
    using System.Linq;

    using Meta.Core.Workflow;

    using SqlT.Models;
    using SqlT.Services;    

    using Meta.Core;

    public sealed class Db01 : Database<Db01>
    {

    }


    [WorkflowNode]
    public sealed class Db01Test : WorkflowNode<NodeFilePath>
    {
        public Db01Test(IWorkflowContext C)
            : base(C)
        {
            this.SqlGenerator = C.SqlGenerator();
            this.SqlPack = C.SqlPackageManager();
        }
          
        ISqlGenerator SqlGenerator { get; }
           
        ISqlPackageManager SqlPack { get; }

        public WorkFlowed<NodeFilePath> BuildPackage()
        {
            var db = new Db01();
            var model = db.Define();
            var script = SqlGenerator.GenerateScript(model);
            var package = new SqlPackage(model, script);
            var outpath = NodeFolderPath.Define(Host, CommonFolders.DevTemp + FolderName.Parse("DbGenTest")) 
                    + FileName.Parse($"{package.PackageName}.{CommonFileExtensions.Dacpac}");
            outpath.Folder.CreateIfMissing().Require();
            return SqlPack.Save(package, outpath, message => Notify(message));
        }
    }
}