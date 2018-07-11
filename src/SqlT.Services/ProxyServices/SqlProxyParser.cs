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

    using SqlT.Core;
    using Meta.Core;

    using static metacore;

    class SqlProxyParser : ApplicationService<SqlProxyParser, ISqlProxyParser>, ISqlProxyParser
    {
        static SqlTabularProxyInfo Describe<P>()
                        where P : class, ISqlTabularProxy, new()
            => SqlProxyMetadataProvider.ProxyMetadata<P>().Tabular<P>();

        public SqlProxyParser(IApplicationContext C)        
            : base(C)
        {

        }

        static IReadOnlyDictionary<int, Func<string, object>> FieldParsers<P>()
                        where P : class, ISqlTabularProxy, new()
        {
            var projector = PrimitiveParsers.Projectors();
            var columns = mapi(Describe<P>().Columns, (i, c) => (i, c.RuntimeType));
            var parsers = new(int, Func<string, object>)[columns.Count];
            foreach (var c in columns)
                parsers[c.i] = (c.i, (string src) => projector.Convert(c.RuntimeType, src));
            return parsers.ToReadOnlyDictionary();                            
        }

        static Func<long, string[], (long LineNumber, P LineValue)> CreateLineParser<P>()
            where P : class, ISqlTabularProxy, new()
        {
            var proxyInfo = Describe<P>();
            var colcount = proxyInfo.Columns.Count;
            var fieldParsers = FieldParsers<P>();

            Func<long, string[], (long, P)> parser = (long lineNumber, string[] components) =>
             {
                 var compcount = components.Length;
                 var values = new object[compcount];
                 iteri(components, (i, c) => values[i] = fieldParsers[i](c));
                 var proxy = new P();
                 proxy.SetItemArray(values);
                 return (lineNumber, proxy);

             };
            return parser;
        }

        IEnumerable<(TextLine Line, P Proxy)> Parse<P>(ITextFile Src, Action<IApplicationMessage> Observer, DelimitedTextDescription Config)
            where P : class, ISqlTabularProxy, new()
        {
            var proxyInfo = Describe<P>();
            var colcount = proxyInfo.Columns.Count;
            var fieldParsers = FieldParsers<P>();

            (TextLine,P) ParseLine(TextLine SrcLine)
            {
                var components = SrcLine.Data.Split(Config.Delimiter);
                var compcount = components.Length;
                var values = new object[compcount];
                iteri(components, (i, c) => values[i] = fieldParsers[i](c));
                var proxy = new P();
                proxy.SetItemArray(values);
                return (SrcLine,proxy);

            }

            if (Config.HasHeader)
            {
                var header = Src.Read().FirstOrDefault();
                if (!header.IsEmpty)
                    foreach (var line in Src.Read().Skip(1))
                        yield return ParseLine(line);
                else
                    Observer(error($"The file {Src.SourcePath} has no data"));
            }
            else
                foreach (var line in Src.Read())
                {
                    var parsed = ParseLine(line);
                    yield return parsed;
                }            
        }

        public IEnumerable<(long LineNumber,P LineValue)> ParseFile<P>(NodeFilePath SrcPath, DelimitedTextDescription Config)
            where P : class, ISqlTabularProxy, new()
        {

            var parser = CreateLineParser<P>();
            var file = new TextFile(SrcPath.AbsolutePath);
            throw new NotImplementedException();
            //return file.Parse(parser, Config.HasHeader ? 1 : 0, Config.Delimiter.ToString());

        }

        public IEnumerable<(long LineNumber, P LineValue)> ParseTop<P>(NodeFilePath SrcPath, DelimitedTextDescription Config, int TopCount)
                   where P : class, ISqlTabularProxy, new()
        {
            var parser = CreateLineParser<P>();
            var file = new TextFile(SrcPath.AbsolutePath);
            throw new NotImplementedException();
            //return file.ParseTop(parser, TopCount, Config.HasHeader ? 1 : 0, Config.Delimiter.ToString());

        }
    }

}