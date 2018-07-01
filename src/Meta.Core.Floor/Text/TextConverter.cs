//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    /// <summary>
    /// Signature for operation that transforms a text value into 
    /// a <typeparamref name="X"/> value with the potential for failure
    /// </summary>
    /// <typeparam name="X">The tpe of transformed value</typeparam>
    /// <param name="text">Textual representation of the <typeparamref name="X"/> value </param>
    /// <returns></returns>
    public delegate Option<X> TextConverter<X>(string text);
}