//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;

using Meta.Core;

/// <summary>
/// Implementation provides specialized serialization services for command specs
/// </summary>
public interface ICommandSpecSerializer
{
    /// <summary>
    /// Materializes a command specification from JSON
    /// </summary>
    /// <param name="j">The JSON that will be parsed to determine the specification</param>
    /// <returns></returns>
    Option<ICommandSpec> Decode(Json j);

    /// <summary>
    /// Materializes a command specification from JSON
    /// </summary>
    /// <typeparam name="T">The type for which an instance will be materialized</typeparam>
    /// <param name="j">The JSON that will be parsed to determine the specification</param>
    /// <returns></returns>
    CommandSpec<T> Decode<T>(Json j) where T : CommandSpec<T>, new();

    /// <summary>
    /// Encodes a command specification into JSON
    /// </summary>
    /// <param name="spec">The specification to encode</param>
    /// <returns></returns>
    Json Encode(ICommandSpec spec);

    
}
