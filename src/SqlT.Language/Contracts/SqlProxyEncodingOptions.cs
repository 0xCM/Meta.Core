//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
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