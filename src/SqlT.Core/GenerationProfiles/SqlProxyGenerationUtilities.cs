//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;


    using static metacore;

    public static class SqlProxyGenerationUtilities
    {
        static readonly Regex Param = new Regex(@"\$\((?<Name>(\w)*)\)", RegexOptions.Compiled);

        static IEnumerable<string> GetParameterNames(string text)
        {
            var names = new HashSet<string>();
            if (!String.IsNullOrWhiteSpace(text))
            {
                foreach (Match match in Param.Matches(text))
                    names.Add(match.Groups["Name"].Value);
            }
            return names;
        }

        static string GetVariableValue(string name)
        {
            if (name == "WorkingDirectory")
                return Environment.CurrentDirectory;
            else
                return Environment.GetEnvironmentVariable(name);
        }

        static string ExpandParameter(string text, string paramName, string paramValue)
            => text.Replace($"$({paramName})", paramValue).Replace($"@{paramName}", paramValue);

        static string ExpandEnvironmentParameters(string text)
            => GetParameterNames(text).Aggregate(text,
                (input, name) => ExpandParameter(input, name, GetVariableValue(name)));


        /// <summary>
        /// Expands any environment variables into their literal form
        /// </summary>
        /// <returns></returns>
        public static SqlProxyGenerationProfile Expand(this SqlProxyGenerationProfile profile)
        {
            var dst = new SqlProxyGenerationProfile();
            foreach (var p in profile.GetType().GetProperties())
            {
                if (p.PropertyType == typeof(string))
                    p.SetValue(dst, ExpandEnvironmentParameters((string)p.GetValue(profile)));
                else if (p.PropertyType == typeof(string[]))
                {
                    var srcArray = (p.GetValue(profile) as string[]) ?? array<string>();
                    var dstArray = new string[srcArray.Length];
                    for (int i = 0; i < srcArray.Length; i++)
                        dstArray[i] = ExpandEnvironmentParameters(srcArray[i]);
                    p.SetValue(dst, dstArray);
                }
                else
                    p.SetValue(dst, p.GetValue(profile));
            }
            return dst;
        }

    }
}
