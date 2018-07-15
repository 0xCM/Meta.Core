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

    using Meta.Core;
    using SqlT.Core;
    

    using static metacore;
    using static GenerationMessages;
    using static FileSystemMessages;
    

    class SqlProxyProfileManager : ApplicationService<SqlProxyProfileManager, ISqlProxyProfileManager>, ISqlProxyProfileManager
    {
        public SqlProxyProfileManager(IApplicationContext C)
            : base(C)
        {

        }

        public Option<CodeGenerationProfile> ParseProfile(string Text)
        {
            var common = C.ObjectFromJson<CodeGenerationProfile>(Text);
            var g = C.Service<ISqlProxyGenerator>();
            switch (common.ProfileType)
            {
                case CodeGenerationProfileKind.Default:
                    return C.ObjectFromJson<SqlProxyGenerationProfile>(Text).Expand();
                case CodeGenerationProfileKind.FieldList:
                    return C.ObjectFromJson<SqlFieldListGenerationProfile>(Text);
                default:
                    return none<CodeGenerationProfile>(InvalidProfileText());
            }
        }

        public Option<CodeGenerationProfile> LoadProfile(FilePath SrcPath)
        {
            if (!SrcPath.Exists())
                return none<CodeGenerationProfile>(PathDoesNotExist(SrcPath));

            var common = JsonServices.FromObjectFile<CodeGenerationProfile>(SrcPath);
            var g = C.Service<ISqlProxyGenerator>();
            switch (common.ProfileType)
            {
                case CodeGenerationProfileKind.Default:
                    return JsonServices.FromObjectFile<SqlProxyGenerationProfile>(SrcPath).Expand();
                case CodeGenerationProfileKind.FieldList:
                    return JsonServices.FromObjectFile<SqlFieldListGenerationProfile>(SrcPath);
                default:
                    return none<CodeGenerationProfile>(InvalidProfile(SrcPath));
            }
        }

        public IEnumerable<CodeGenerationProfile> LoadProfiles(ComponentIdentifier AssemblyId)
            => from assembly in stream(AssemblyId.Load())
               from resName in assembly.GetManifestResourceNames()
               where resName.EndsWith(".sqlt")
               let profileText = assembly.GetResourceText(resName)
               let profile = ParseProfile(profileText).OnNone(Notify)
               where profile.IsSome()
               select profile.ValueOrDefault();              
    }
}