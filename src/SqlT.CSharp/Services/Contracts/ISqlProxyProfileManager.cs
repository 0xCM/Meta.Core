//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using SqlT.Core;

    public interface ISqlProxyProfileManager 
    {
        /// <summary>
        /// Loads a generation profile from a file
        /// </summary>
        /// <param name="SrcPath">The path to the profile</param>
        /// <returns></returns>
        Option<CodeGenerationProfile> LoadProfile(FilePath SrcPath);

        /// <summary>
        /// Loads a generation profile from text
        /// </summary>
        /// <param name="Text">Text that defines a profile</param>
        /// <returns></returns>
        Option<CodeGenerationProfile> ParseProfile(string Text);

        /// <summary>
        /// Loads the profiles embedded as assembly resources
        /// </summary>
        /// <param name="AssemblyId">The assembly's component identifier</param>
        /// <returns></returns>
        IEnumerable<CodeGenerationProfile> LoadProfiles(ComponentIdentifier AssemblyId);

    }


}
