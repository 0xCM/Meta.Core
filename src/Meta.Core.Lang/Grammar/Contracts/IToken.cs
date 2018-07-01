//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Syntax
{
    using static metacore;

    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface IToken
    {
        /// <summary>
        /// The name of the token
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The rendered value
        /// </summary>
        object Value { get; }

        /// <summary>
        /// Specifies the purpose of the token
        /// </summary>
        Option<string> Description { get; }
    }

    public interface IToken<T> : IToken
    {
        /// <summary>
        /// The rendered value
        /// </summary>
        new T Value { get; }
    }

}