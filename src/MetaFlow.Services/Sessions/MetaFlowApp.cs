//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Core;
    using SqlT.Core;
    


    using static metacore;



    public abstract class MetaFlowApp<App, Args> : FlowSubsystemShell<App, Args>
        where App : MetaFlowApp<App, Args>, new()
        where Args : FlowAppArgs<Args>, new()
    {
        public MetaFlowApp()
        {

        }

        public MetaFlowApp(Args Args)
            : base(Args)
        {


        }


        public override IConfigurationProvider ConfigurationProvider
            => global::ConfigurationProvider.FromValue(this);


    }


    public abstract class MetaFlowApp<App> : MetaFlowApp<App, FlowAppArgs>
        where App : MetaFlowApp<App>, new()
    {

        public MetaFlowApp()
        {

        }

        public MetaFlowApp(FlowAppArgs Args)
            : base(Args)
        {


        }


        public override IConfigurationProvider ConfigurationProvider
            => null;


    }


}



