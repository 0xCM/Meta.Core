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

    using Meta.Core;

    public class SqlProxyProjectDescription
    {
        public SqlProxyProjectDescription()
        {

        }

        public SqlProxyProjectDescription(string ProjectName,
            params SqlProxyProfileIdentifier[] ProfileIdentifiers)
        {
            this.ProjectName = ProjectName;
            this.ProfileIdentifiers = ProfileIdentifiers.ToList();

        }

        public string ProjectName { get; set; }

        public IReadOnlyList<SqlProxyProfileIdentifier> ProfileIdentifiers { get; set; }
    }

}