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
    /// Represents a system-level result
    /// </summary>
    public class SystemResultCode : ValueObject<SystemResultCode>
    {
        public static implicit operator string(SystemResultCode x) 
            => x.Name;

        public static implicit operator SystemResultCode(string x) 
            => SystemResultCodes.Find(x);
        
        public static implicit operator int(SystemResultCode x) 
            => x.TypeCode;

        /// <summary>
        /// The name of the result code
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// Integer code that identifies the result
        /// </summary>
        public readonly int TypeCode;

        public SystemResultCode(int TypeCode, string Name)
        {
            this.Name = Name;
            this.TypeCode = TypeCode;
        }

        public bool Success 
            => this == SystemResultCodes.Success;
    }
}
