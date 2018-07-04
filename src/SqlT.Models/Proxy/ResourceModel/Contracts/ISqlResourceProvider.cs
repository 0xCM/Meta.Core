//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{

    using SqlT.Core;
    using Meta.Core;
    using Meta.Core.Resources;
    using SqlT.Models;

    using N = SystemNode;

    public interface ISqlResourceProvider
    {
        SqlTableEndpoint Table(N Host, SqlTableName TableName, EndpointRole Role);

    }
}
