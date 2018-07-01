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
    /// Enumerates system-defined result codes
    /// </summary>
    public class SystemResultCodes : HostedFieldList<SystemResultCode, SystemResultCodes>
    {
        static readonly SystemResultCodes Index = new SystemResultCodes();

        /// <summary>
        /// Specifies an operation succeeded
        /// </summary>
        public static readonly SystemResultCode Success = new SystemResultCode(1, nameof(Success));

        /// <summary>
        /// Specifies an operation failed
        /// </summary>
        public static readonly SystemResultCode Failure = new SystemResultCode(2, nameof(Failure));

        /// <summary>
        /// Looks up a result code by name
        /// </summary>
        /// <param name="Name">The name of the result cod</param>
        /// <returns></returns>
        public static SystemResultCode Find(string Name) 
            => Index.Single(x => x.Name == Name);

    }
}
