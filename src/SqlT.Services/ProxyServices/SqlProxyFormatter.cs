//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ComponentModel;

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

        IEnumerable<Link<P, TextLine>> ISqlProxyFormatter.FormatDelimited<P>(IEnumerable<P> proxies, DelimitedTextDescription Config)
        {
            var config = Config ?? new DelimitedTextDescription();
            var delimiter = config.Delimiter.ToString();
            var hasHeader = config.HasHeader;
            var proxyInfo = PXM.Tabular<P>();
            var columns = proxyInfo.Columns;
            var colcount = columns.Count;
            int lineCount = 0;
            var headerEmitted = false;

            foreach(var proxy in proxies)
            {
                if(hasHeader && !headerEmitted)
                {
                    yield return new Link<P, TextLine>(new P(),
                        new TextLine(++lineCount,
                                string.Join(delimiter, map(columns, c => c.ColumnName.UnquotedLocalName))));
                    headerEmitted = true;
                }

                var formatArray = array<string>(colcount);
                var itemArray = proxy.GetItemArray();
                for(var i=0; i< colcount; i++)
                    formatArray[i] = FormatColumnValue(columns[i], itemArray[i]);

                yield return new Link<P, TextLine>(proxy,
                    new TextLine(++lineCount,
                            string.Join(delimiter.ToString(), formatArray)));
            }
        }
    }

}