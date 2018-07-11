//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------

using CID = ComponentIdentifier;

public partial class SqlTPlatform : SqlTModule<SqlTPlatform>
{

    public static readonly SqlTComponents SystemComponents
            = new SqlTComponents();

    public const string ComponentName = nameof(SqlTPlatform);

}

public sealed class SqlTComponents : TypedItemList<SqlTComponents, CID>
{
    public static readonly CID SqlCore = SqlTCore.Identifier;
    public static readonly CID SqlSyntax = SqlTSyntax.Identifier;
    public static readonly CID SqlModels = SqlTModels.Identifier;
    public static readonly CID SqlLanguage = SqlTLanguage.Identifier;
    public static readonly CID SqlModelConstruction = SqlTModelConstruction.Identifier;
    public static readonly CID DacServices = SqlTDacServices.Identifier;
    public static readonly CID SqlSystem = SqlTSqlSystem.Identifier;
    public static readonly CID SqlServices = SqlTServices.Identifier;
    public static readonly CID SqlDocs = SqlTSqlDocs.Identifier;
    public static readonly CID DatasetServices = SqlTDatasetServices.Identifier;
    public static readonly CID SqlSharp = SqlTSharp.Identifier;
    public static readonly CID SqlWorkflow = SqlTWorkflow.Identifier;
    public static readonly CID SqlTDom = SqlTDomServices.Identifier;
    public static readonly CID SqlDocsProxies = SqlTDocsProxies.Identifier;
    public static readonly CID SqlTypeProxies = SqlTTypeProxies.Identifier;
    public static readonly CID SqlStoreProxies = SqlTStoreProxies.Identifier;
    public static readonly CID SqlPlatform = SqlTPlatform.Identifier;
}