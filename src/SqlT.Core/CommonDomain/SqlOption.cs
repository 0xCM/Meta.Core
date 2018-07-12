//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
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
             : none<P>(AppMessage.Error(x.Messages.Render()));



    }


}