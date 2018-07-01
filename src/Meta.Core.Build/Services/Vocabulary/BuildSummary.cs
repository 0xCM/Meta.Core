//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Build
{
    using System;

    using static metacore;

    public class BuildSummary
    {
        public string ProjectName { get; set; }

        public bool Succeeded { get; set; }

        public TimeSpan Duration { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public FilePath BuildLog { get; set; }

        public IApplicationMessage Description
            => Succeeded 
            ? inform($"{ProjectName} build succeded at {EndTime} after {Duration.TotalSeconds} (s)")
            : error($"{ProjectName} build failed at {EndTime} after {Duration.TotalSeconds} (s)");            
    }
}