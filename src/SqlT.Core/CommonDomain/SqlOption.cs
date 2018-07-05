//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.SqlClient;

    using static metacore;

    public static class SqlOption
    {
        
        public static Option<P> ToOption<P>(this SqlOutcome<P> x)
        => x ? some(x.Payload)
             : none<P>(ApplicationMessage.Error(x.Messages.Render()));



    }


}