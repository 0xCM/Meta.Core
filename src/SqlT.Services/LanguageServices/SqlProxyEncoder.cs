//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    using System.IO;

    //using Microsoft.VisualBasic.FileIO;



    using Meta.Core;

    using static ApplicationMessage;
    using static metacore;    

    /// <summary>
    /// Implements bare-bones proxy serialization to/from delimited text files
    /// </summary>
    /// <remarks>
    /// This would be in SqlT.Core, but not included to avoid dependency on Microsoft.VisualBasic assembly
    /// </remarks>
    public class SqlProxyEncoder : ISqlProxyEncoder
    {
        public static SqlProxyEncoder Create()
            => new SqlProxyEncoder();

        SqlProxyEncoder()
        {
            
        }

        static string Render(object o, string delimiter, string quote)
        {
            var s = o?.ToString() ?? String.Empty;
            if (s.Contains(delimiter))
                s.Replace(quote, quote + quote);

            return s.Contains(delimiter) ? $"\"{s}\"" : s;
        }


        static string FormatHeader(Type ProxyType, SqlProxyEncodingOptions Options)
        {
            var tabular = PXM.Tabular(ProxyType);
            var sb = new StringBuilder();
            for (int i = 0; i < tabular.Columns.Count; i++)
            {
                var col = tabular.Columns[i];
                sb.Append(Render(col.ColumnName, Options.Delimiter, Options.Quote));
                if (i != tabular.Columns.Count - 1)
                    sb.Append(Options.Delimiter);
            }
            return sb.ToString();
        }

        static string FormatProxy(ISqlTabularProxy proxy, SqlProxyEncodingOptions Options)
        {
            var items = proxy.GetItemArray();

            var sb = new StringBuilder();
            for (int i = 0; i < items.Length; i++)
            {
                sb.Append(Render(items[i], Options.Delimiter, Options.Quote));
                if (i != items.Length - 1)
                    sb.Append(Options.Delimiter);
            }
            return sb.ToString();

        }

        static IEnumerable<TextLine> FormatProxies(Type ProxyType, IEnumerable<ISqlTabularProxy> proxies, SqlProxyEncodingOptions Options)        
        {
            var options = Options;
            var sb = new StringBuilder();
            var tabular = PXM.Tabular(ProxyType);
            var count = 0;
            if (options.HeaderRow)
                yield return new TextLine(++count, FormatHeader(ProxyType, options));

            foreach (var proxy in proxies)
                yield return new TextLine(++count, FormatProxy(proxy, options));
        }

#if CSV
        static TextFieldParser CreateParser(FilePath InputFile, SqlProxyEncodingOptions Options)
            => new TextFieldParser(InputFile)
            {
                TextFieldType = FieldType.Delimited,
                Delimiters = array(Options.Delimiter)
            };

        static TextFieldParser CreateParser(StringReader reader, SqlProxyEncodingOptions Options)
            => new TextFieldParser(reader)
            {
                TextFieldType = FieldType.Delimited,
                Delimiters = array(Options.Delimiter)
            };
#endif
        public Option<int> EncodeDelimitedText(Type ProxyType, IEnumerable<ISqlTabularProxy> Input, FilePath Output, SqlProxyEncodingOptions Options)
        {
            var options = new SqlProxyEncodingOptions();
            var current = default(TextLine);
            using (var writer = new StreamWriter(Output, false))
            {
                foreach (var line in FormatProxies(ProxyType, Input, options))
                {
                    current = line;
                    writer.WriteLine(current.Data);
                }
            }
            return current.RowNumber;
        }

        public Option<int> EncodeDelimitedText<P>(IEnumerable<P> Input, FilePath Output, SqlProxyEncodingOptions Options)
            where P : class, ISqlTabularProxy, new()
        {
            var options = Options ?? new SqlProxyEncodingOptions();
            var current = default(TextLine);
            using (var writer = new StreamWriter(Output, false))
            {
                foreach (var line in FormatProxies(typeof(P), Input.Select(p => p as ISqlTabularProxy), options))
                {
                    current = line;
                    writer.WriteLine(current.Data);
                }
            }
            return current.RowNumber;
        }

        /// <summary>
        /// Ad-hoc, and not very pretty, functional Try construct
        /// </summary>
        static (Option<Exception>, Option<T>) Try<T>(Func<T> F)
        {
            try
            {
                return (none<Exception>(), some(F()));
            }
            catch (Exception e)
            {
                return (some(e), none<T>());
            }
        }
#if CSV
        IEnumerable<T> DecodeDelimitedText<T>(TextFieldParser reader, Action<IApplicationMessage> ErrorHandler, SqlProxyEncodingOptions Options)
            where T : class, ISqlTabularProxy, new()
        {
            
            var options = Options ?? new SqlProxyEncodingOptions();
            var description = PXM.Tabular<T>();
            var parsers = PrimitiveParsers.Projectors();
            string[] header = null;

            while (!reader.EndOfData)
            {
                var _fields = Try(reader.ReadFields);
                if (_fields.Item2.IsSome())
                {
                    var fields = _fields.Item2.ValueOrDefault();
                    if (header == null)
                    {
                        if (options.HeaderRow)
                        {
                            header = fields;
                            continue;
                        }
                        else
                            header = new string[0] { };
                    }

                    var datalen = Math.Min(fields.Length, description.Columns.Count);
                    var items = new object[datalen];
                    for (int i = 0; i < datalen; i++)
                    {
                        var inval = fields[i];
                        if (isNotNull(inval))
                        {
                            var col = description.Columns[i];
                            items[i] = parsers.Convert(col.RuntimeType, inval);
                        }
                    }
                    var proxy = new T();
                    proxy.SetItemArray(items);
                    yield return proxy;
                }
                else
                {
                    ErrorHandler(Error(_fields.Item1.ValueOrDefault().Message));
                }
            }
        }
#endif
        /// <summary>
        /// Hydrates proxies, where possible, from the supplied text; failures are pushed to the error handler
        /// </summary>
        public IEnumerable<T> DecodeDelimitedText<T>(string InputData, Action<IApplicationMessage> ErrorHandler, SqlProxyEncodingOptions Options)
            where T : class, ISqlTabularProxy, new()
        {
            var options = Options ?? new SqlProxyEncodingOptions();
            return stream<T>();

#if CSV
            using (var reader = new StringReader(InputData))
            using (var parser = CreateParser(reader,options))
                foreach (var item in DecodeDelimitedText<T>(parser, ErrorHandler,options))
                {
                    yield return item;
                }
#endif
        }

        /// <summary>
        /// Hydrates proxies, where possible, from the supplied file; failures are pushed to the error handler
        /// </summary>
        public IEnumerable<T> DecodeDelimitedText<T>(FilePath InputFile, Action<IApplicationMessage> ErrorHandler, SqlProxyEncodingOptions Options)
            where T : class, ISqlTabularProxy, new()
        {
            return stream<T>();
#if CSV
            var options = Options ?? new SqlProxyEncodingOptions();
            using (var parser = CreateParser(InputFile, options))
                foreach (var item in DecodeDelimitedText<T>(parser, ErrorHandler, options))
                    yield return item;
#endif
        }
    }
}


