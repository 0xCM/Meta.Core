//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;

    using static metacore;
    using Meta.Core;

    public class SqlProxyGenerationResult
    {

        public static SqlProxyGenerationResult Failure(string ProfileText, IAppMessage Description)
            => new SqlProxyGenerationResult(ProfileText, Description);

        public static SqlProxyGenerationResult Success(SqlProxyGenerationProfile Profile, IReadOnlyList<FilePath> Emissions)
            => new SqlProxyGenerationResult(Profile,some(Emissions));


        public SqlProxyGenerationResult(SqlProxyGenerationProfile Profile,  Option<IReadOnlyList<FilePath>> Result)
        {
            this._Result = Result;
            this.Profile = Profile;
            this.ProfileText = JsonServices.ToJson(Profile);
        }

        SqlProxyGenerationResult(string ProfileText, IAppMessage Description)
        {
            this._Result = none<IReadOnlyList<FilePath>>(Description);
            this.ProfileText = ProfileText;

        }

        Option<IReadOnlyList<FilePath>> _Result { get; }


        public string ProfileText { get; }

        public Option<SqlProxyGenerationProfile> Profile { get; }

        public Option<IReadOnlyList<FilePath>> Value
            => _Result;

        public bool Succeeded
            => _Result.IsSome();

        public IAppMessage Description
            => _Result.Message;

        public override string ToString()
            => _Result.ToString();
    }

}
