//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Meta.Core;
    using Meta.Core.Resources;

    
    using SqlT.Core;
    using SqlT.Models;

    using static metacore;
    using N = SystemNode;



    public interface ISqlResourceLocator
    {

        SqlTableEndpoint TableEndpoint(N Host, SqlTableName Table, EndpointRole Role);

        SqlTableEndpoint<T> TableEndpoint<T>(N Host, EndpointRole Role)
            where T : class, ISqlTableProxy, new();
                   

    }

}