//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Project
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;


    using static metacore;

    public abstract class DevProject<P> 
        where P : DevProject<P>
    {

        protected DevProject(DevProjectName ProjectName)
        {
            this.ProjectName = ProjectName;
        }

        public DevProjectName ProjectName { get; }


        public override string ToString()
            => ProjectName;
    }


}