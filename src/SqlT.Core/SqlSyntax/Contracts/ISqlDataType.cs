//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using Meta.Models;
    using SqlT.Core;
    
    public static partial class contracts
    {
        /// <summary>
        /// See https://docs.microsoft.com/en-us/sql/t-sql/data-types/data-types-transact-sql
        /// </summary>
        public interface ISqlDataType : ISqlType, IEquatable<ISqlDataType>
        {
            ModelOption<native_type> BaseType { get; }
        }
    }
}