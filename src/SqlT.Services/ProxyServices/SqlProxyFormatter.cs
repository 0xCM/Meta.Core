//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Core;
    using SqlT.Core;

    using static metacore;
    using static sqlfunc;

    class SqlProxyFormatter : ApplicationService<SqlProxyFormatter, ISqlProxyFormatter>, ISqlProxyFormatter
    {

        public SqlProxyFormatter(IApplicationContext C)
            : base(C)
        {

        }

        static string FormatColumnValue(SqlColumnProxyInfo col, object value)
        {
            if (isNull(value))
                return string.Empty;

            return value.ToString();
        }

        IEnumerable<Link<P, TextLine>> FormatDelimited<P>(Seq<P> proxies, DelimitedTextDescription Config)
            where P : class, ISqlTabularProxy, new()
        {
            var config = Config ?? new DelimitedTextDescription();
            var delimiter = config.Delimiter.ToString();
            var hasHeader = config.HasHeader;
            var proxyInfo = PXM.Tabular<P>();
            var columns = proxyInfo.Columns;
            var colcount = columns.Count;
            int lineCount = 0;
            var headerEmitted = false;

            foreach (var proxy in proxies.Stream())
            {
                if (hasHeader && !headerEmitted)
                {
                    yield return new Link<P, TextLine>(new P(),
                        new TextLine(++lineCount,
                                string.Join(delimiter, map(columns, c => c.ColumnName.UnquotedLocalName))));
                    headerEmitted = true;
                }

                var formatArray = array<string>(colcount);
                var itemArray = proxy.GetItemArray();
                for (var i = 0; i < colcount; i++)
                    formatArray[i] = FormatColumnValue(columns[i], itemArray[i]);

                yield return new Link<P, TextLine>(proxy,
                    new TextLine(++lineCount,
                            string.Join(delimiter.ToString(), formatArray)));
            }
        }

        Seq<Link<P, TextLine>> ISqlProxyFormatter.FormatDelimited<P>(Seq<P> proxies, DelimitedTextDescription Config)
            => Seq.make(FormatDelimited(proxies, Config));

    }

}