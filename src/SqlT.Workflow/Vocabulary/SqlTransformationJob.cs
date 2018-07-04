//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Workflow
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;
    using Meta.Core;


    public class TransformationJob
    {

        public TransformationJob(FlowSettings Settings, IEnumerable<TransformationDescription> TransformationDescriptions)
        {
            this.Settings = Settings;
            this.TransformationDescriptions = rolist(TransformationDescriptions);
        }

        public ReadOnlyList<TransformationDescription> TransformationDescriptions { get; }


        public FlowSettings Settings { get; }
    }


}