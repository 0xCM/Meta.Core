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
    /// Defines contract for converters used in the HTTP Request/Response pipeline that
    /// transform representations from one format to another
    /// </summary>
    public interface IHttpConverter
    {
        /// <summary>
        /// Converts a <see cref="Json"/> representation to a logically-equivalent type-based representation
        /// </summary>
        /// <typeparam name="T">The representation type</typeparam>
        /// <param name="j">The representation text</param>
        /// <returns></returns>
        Outcome<T> Parse<T>(global::Json j);

        /// <summary>
        /// Converts a <see cref="Json"/> representation to a logically equivalent type-based representation 
        /// </summary>
        /// <param name="t">The representation type</param>
        /// <param name="j">The representation text</param>
        /// <returns></returns>
        Outcome<object> Parse(Type t, global::Json j);

        /// <summary>
        /// Converts a type-based representation to a <see cref="Json"/> representation
        /// </summary>
        /// <typeparam name="T">The representation type</typeparam>
        /// <param name="r">The type-based representation</param>
        /// <returns></returns>
        global::Json Format<T>(T r);

        /// <summary>
        /// Converts a type-based representation to a <see cref="Json"/> representation
        /// </summary>
        /// <param name="r">The representation to convert</param>
        global::Json Format(object r);
    }
}
