//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

public class CommonFileExtensions : TypedItemList<CommonFileExtensions, FileExtension>
{

    public static readonly FileExtension Xml = new FileExtension("xml");
    public static readonly FileExtension Exe = new FileExtension("exe");
    public static readonly FileExtension Cmd = new FileExtension("cmd");
    public static readonly FileExtension Bat = new FileExtension("bat");
    public static readonly FileExtension Dll = new FileExtension("dll");
    public static readonly FileExtension Pdb = new FileExtension("pdb");
    public static readonly FileExtension Xsd = new FileExtension("xsd");
    public static readonly FileExtension Sql = new FileExtension("sql");
    public static readonly FileExtension Csv = new FileExtension("csv");
    public static readonly FileExtension AppConfig = new FileExtension("config");
    public static readonly FileExtension Dacpac = new FileExtension("dacpac");
    public static readonly FileExtension DacProfile = new FileExtension("publish.xml");
    public static readonly FileExtension SqlProject = new FileExtension("sqlproj");
    public static readonly FileExtension CsProject = new FileExtension("csproj");
    public static readonly FileExtension VsSolution = new FileExtension("sln");
    public static readonly FileExtension Zip = new FileExtension("zip");
    public static readonly FileExtension Props = new FileExtension("props");
    public static readonly FileExtension Markdown = new FileExtension("md");
    public static readonly FileExtension Log = new FileExtension("log");

}

