using System.Collections.Generic;
using static metacore;

using System.Reflection;
using System;

using CID = ComponentIdentifier;


public partial class SqlTOperations : SqlTModule<SqlTOperations>
{

    public static readonly SqlTComponents SystemComponents
            = new SqlTComponents();

    public const string ComponentName = nameof(SqlTOperations);

}

public sealed class SqlTComponents : TypedItemList<SqlTComponents, CID>
{
    public static readonly CID SqlTCore = global::SqlTCore.Identifier;
    public static readonly CID SqlTSharp = global::SqlTSharp.Identifier;
    public static readonly CID SqlTLanguage = global::SqlTLanguage.Identifier;
    public static readonly CID SqlTModels = global::SqlTModels.Identifier;
    public static readonly CID SqlTServices = global::SqlTServices.Identifier;
    public static readonly CID SqlTWorkflow = global::SqlTWorkflow.Identifier;
    public static readonly CID SqlTDom = global::SqlTDomServices.Identifier;
    public static readonly CID SqlTDocsProxies = global::SqlTDocsProxies.Identifier;
    public static readonly CID SqlTTypes = global::SqlTTypeProxies.Identifier;
    public static readonly CID SqlTStore = global::SqlTStoreProxies.Identifier;
    public static readonly CID SqlTOperations = global::SqlTOperations.Identifier;
    public static readonly CID SqlTSyntax = global::SqlTSyntax.Identifier;
}