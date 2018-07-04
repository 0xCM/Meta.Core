//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using static metacore;

using System.Collections.Generic;
using System.Reflection;
using CID = ComponentIdentifier;

public class MetaCoreOperations : CoreModule<MetaCoreOperations>
{

    public static readonly MetaCoreComponents SystemComponents
        = new MetaCoreComponents();

    public override IReadOnlyList<Assembly> ModuleDependencies
        => new MetaCoreComponents().Load();    
}

public sealed class MetaCoreComponents : TypedItemList<MetaCoreComponents, CID>
{
    public static readonly CID MetaFloor = global::MetaFloor.Identifier;
    public static readonly CID MetaCore = global::MetaCore.Identifier;
    public static readonly CID MetaCoreClrSpec = global::MetaCoreClrSpec.Identifier;
    public static readonly CID MetaCoreSyntax = global::MetaCoreSyntax.Identifier;
    public static readonly CID MetaCoreFileSystem = global::MetaCoreSyntax.Identifier;
    //public static readonly CID MetaCoreBuild = global::MetaCoreBuild.Identifier;
    public static readonly CID MetaCoreCommands = global::MetaCoreCommands.Identifier;
    public static readonly CID MetaCoreExecutors = global::MetaCoreExecutors.Identifier;
    //public static readonly CID MetaCoreHttp = global::MetaCoreHttp.Identifier;
    public static readonly CID MetaCoreSerialization = global::MetaCoreJson.Identifier;
    public static readonly CID MetaCoreMessaging = global::MetaCoreMessaging.Identifier;
    public static readonly CID MetaCoreOperations = global::MetaCoreOperations.Identifier;
    public static readonly CID MetaCoreProcesses = global::MetaCoreProcesses.Identifier;
    public static readonly CID MetaCoreServices = global::MetaCoreServices.Identifier;
    public static readonly CID MetaCoreShells = global::MetaCoreShells.Identifier;
    public static readonly CID MetaCoreWorkflow = global::MetaCoreWorkflow.Identifier;

}
