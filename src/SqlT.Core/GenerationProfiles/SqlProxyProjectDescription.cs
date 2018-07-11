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
            this.ProfileIdentifiers = ProfileIdentifiers;

        }

        public string ProjectName { get; set; }

        public Lst<SqlProxyProfileIdentifier> ProfileIdentifiers { get; set; }
    }

    public sealed class SqlProxyProjectDescriptions : ReadOnlySet<SqlProxyProjectDescription>
    {
        public static implicit operator SqlProxyProjectDescriptions(SqlProxyProjectDescription[] items)
            => new SqlProxyProjectDescriptions(items);


        public SqlProxyProjectDescriptions(IEnumerable<SqlProxyProjectDescription> items)
            : base(items)
        { }

        public SqlProxyProjectDescriptions(params SqlProxyProjectDescription[] items)
            : base(items)
        { }

    }

}