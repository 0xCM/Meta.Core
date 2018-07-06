//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Linq;


    /// <summary>
    /// Specifies <see cref="ISqlProxyEncoder"/> options
    /// </summary>
    public class SqlProxyEncodingOptions
    {
        public SqlProxyEncodingOptions(string Delimiter = ",", string Quote = "\"", bool HeaderRow = true)
        {
            this.Delimiter = Delimiter;
            this.Quote = Quote;
            this.HeaderRow = HeaderRow;
        }

        public string Delimiter { get; }

        public string Quote { get; }

        public bool HeaderRow { get; }

    }

}