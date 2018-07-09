//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System.Collections.Generic;

    using SqlT.Models;
    using SqlT.Core;

    /// <summary>
    /// Defines contract for components that provide access to SQL scripts
    /// </summary>
    public interface ISqlScriptProvider
    {
        /// <summary>
        /// Finds a script in a specified source
        /// </summary>
        /// <param name="source">The script source</param>
        /// <param name="identifier">The identifier that allows the script to be located in the source</param>
        /// <returns></returns>
        SqlParameterizedScript FindScript(SqlScriptSource source, SqlScriptName identifier);

        /// <summary>
        /// Finds a script in the Core script package
        /// </summary>
        /// <param name="identifer"></param>
        /// <returns></returns>
        SqlParameterizedScript FindScript(SqlScriptName identifer);

        /// <summary>
        /// Finds all scripts defined by the supplied source
        /// </summary>
        /// <param name="source">The script source, if specified; if unspecified, the default script source is searched</param>
        /// <returns></returns>
        IReadOnlyDictionary<SqlScriptName,SqlParameterizedScript> FindScripts(SqlScriptSource source = null);
    }
}
