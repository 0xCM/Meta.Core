//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.CSharp
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;
    using static metacore;
    using static ClrStructureSpec;

    public static class CodeFactory
    {
        public static Option<CodeFileSpec> GenerateCode(this InterfaceSpec Spec, ClrNamespaceName DstNS, FilePath DstPath, params UsingSpec[] usings)
        {
            var fs = new CodeFileSpec(DstPath, usings, new NamespaceSpec(DstNS, array(Spec)));
            return fs.Emit().Map(_ => fs);

        }

        static Option<IReadOnlyList<FilePath>> GenerateProxies(this IApplicationContext C, CodeGenerationProfile profile)
        {
            var g = C.Service<ISqlProxyGenerator>();
            switch (profile.ProfileType)
            {
                case CodeGenerationProfileKind.Default:
                    return some(g.GenerateProxies(profile as SqlProxyGenerationProfile));
                case CodeGenerationProfileKind.FieldList:
                    return some(g.GenerateFieldLists(profile as SqlFieldListGenerationProfile));
                default:
                    return none<IReadOnlyList<FilePath>>(error($"The type {profile.GetType()} is not supported"));

            }
        }

        public static Option<IReadOnlyList<FilePath>> GenerateCode(this IApplicationContext C, FilePath ProfilePath)
                => from profile in C.SqlProxyProfileManager().LoadProfile(ProfilePath)
                   from emissions in GenerateProxies(C, profile)
                   select emissions;

    }
}