//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Concurrent;

    using Meta.Core;

    /// <summary>
    /// Binds source and target connectors together with configuration information
    /// </summary>
    /// <typeparam name="O"></typeparam>
    public struct SqlConnectorLink<O>
        where O : class, new()
    {

        public SqlConnectorLink(SqlConnectionString SourceConnector, SqlConnectionString TargetConnector)
        {
            this.Link = new Link<SqlConnectionString>(SourceConnector, TargetConnector);
            this.Options = new O();
        }

        public SqlConnectorLink(SqlConnectionString SourceConnector, SqlConnectionString TargetConnector, O Options)
        {
            this.Link = new Link<SqlConnectionString>(SourceConnector, TargetConnector);
            this.Options = Options;
        }

        public Link<SqlConnectionString> Link { get; }

        public SqlConnectionString Source
            => Link.Source;

        public SqlConnectionString Target
            => Link.Target;

        public O Options { get; }

        public override string ToString()
            => Link.ToString();

    }


}