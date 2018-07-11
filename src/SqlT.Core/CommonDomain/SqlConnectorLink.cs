//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;

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