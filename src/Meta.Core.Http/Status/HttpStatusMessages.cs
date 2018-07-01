//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Http
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines common HTTP status messages
    /// </summary>
    public static class HttpStatusMessages
    {
        public static IApplicationMessage SystemError(string description)
            => ApplicationMessage.Error("System Result:@SystemResult; Protocol Result:@ProtocolResult; @ErrorResponse",
                new HttpStatusDescription(
                    new HttpReplyStatus(
                        HttpResultCodes.InternalServerError,
                        SystemResultCodes.Failure), description
                    ));


        public static IApplicationMessage ErrorStatus(HttpReplyStatus Status, string ErrorResponse)
            => ApplicationMessage.Error("System Result:@SystemResult; Protocol Result:@ProtocolResult; @ErrorResponse",
                new HttpStatusDescription(Status, ErrorResponse));



    }
}
