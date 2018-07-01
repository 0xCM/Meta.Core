//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    using System.IO;
    using System.Runtime.CompilerServices;
        

    using static metacore;


    class IconStore : ApplicationService<IconStore,IIconStore>, IIconStore
    {

        FolderPath ServiceFolder { get; }

        FolderPath IconFolder { get; }

        FolderName IconFolderName
            => "Icons";

        IEnumerable<FileName> IconFileNames
           => from f in IconFolder.Files("*.ico")
              select f.FileName;


        static FilePath DefiningFile([CallerFilePath] string f = null)
            => f;        

        public IconStore(IApplicationContext C)
            : base(C)
        {
            ServiceFolder = DefiningFile().Folder;
            IconFolder = ServiceFolder + IconFolderName;
            
        }
        Option<FilePath> GenerateResourceScript()
        {
            var rcFileName = FileName.Parse($"{IconFolder.FolderName}.rc");
            var rcFilePath = IconFolder + rcFileName;

            var startId = 1;
            var sb = new StringBuilder();
            var fileNames = IconFileNames.ToList();

            for (var i = 0; i < fileNames.Count; i++)
                sb.AppendLine($"{startId + i} ICON \"{fileNames[i]}\"");

            return rcFilePath.Write(sb.ToString()).ToFileOption();
        }


        Option<FilePath> GenerateResourceEnum()
        {
            var sb = new StringBuilder();
            var enumName = nameof(IconIdentifier);
            sb.AppendLine($"public enum {enumName}");
            sb.AppendLine("{");
            sb.AppendLine("\tNone = 0,");
            var fileNames = IconFileNames.ToList();
            for (int i = 0; i < fileNames.Count; i++)
            {
                var fileName = fileNames[i];
                var identifier = fileName.Replace('-', '_').RemoveExtension();
                sb.AppendLine($"\t{identifier} = {i + 1},");
            }
            sb.AppendLine("}");
            var dstPath = ServiceFolder + FileName.Parse(enumName).AddExtension("cs");
            return dstPath.Write(sb.ToString()).ToFileOption();
            
        }

        public Option<IEnumerable<FilePath>> GenerateArtifacts()
            => from x in GenerateResourceScript()
               from y in GenerateResourceEnum()
               select stream(x, y);

        public Option<Link<IconIdentifier, FilePath>> ExtractIcon(Link<IconIdentifier, FilePath> path)
        {

            throw new NotImplementedException();
            //var xtractor = new IX.IconExtractor(Assembly.GetExecutingAssembly().Location);
            //path.Target.Folder.CreateIfMissing().Require();
            //path.Target.DeleteIfExists();
            //using (var stream = File.OpenWrite(path.Target))
            //    xtractor.Save(1, stream);
            //return path;
        }

    }
}
