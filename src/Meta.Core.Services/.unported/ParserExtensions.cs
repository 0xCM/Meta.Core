//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualBasic.FileIO;
    using System.IO;

    using static metacore;


    /// <summary>
    /// Defines rudimentary capabilities to chunk lines of text from text-based documents
    /// </summary>
    public static class ParserExtensions
    {

        public static string[] Parse(this TextLine line, string delimiter)
        {
            
            using (var reader = new StringReader(line.Data))
            {
                using (var parser = new TextFieldParser(reader))
                {
                    parser.SetDelimiters(delimiter);
                    return parser.ReadFields();
                }
            }
        }

        public static IEnumerable<T> Parse<T>(this ITextFile file, Func<string[], T> f, int skip = 0, string delimiter = ",")
        {
            using (var reader = new TextFieldParser(file.SourcePath)
            {
                TextFieldType = FieldType.Delimited,
                Delimiters = array(delimiter)
            })
            {
                var skipped = 0;
                while(skipped < skip && !reader.EndOfData)
                {                    
                    reader.ReadLine();
                    skipped++;
                }

                while (!reader.EndOfData)
                {
                    yield return f(reader.ReadFields());
                }
            }
        }

        public static IEnumerable<(long LineNumber, T LineValue)> Parse<T>(this ITextFile file, Func<long, string[], (long, T)> f, int skip = 0, string delimiter = ",")
            => file.ParseTop(f, Int32.MaxValue - 1, skip, delimiter);

        public static IEnumerable<(long LineNumber, T LineValue)> ParseTop<T>(this ITextFile file, Func<long, string[], (long, T)> f, int top, int skip = 0, string delimiter = ",")
        {
            using (var reader = new TextFieldParser(file.SourcePath)
            {
                TextFieldType = FieldType.Delimited,
                Delimiters = array(delimiter)
            })
            {
                var skipped = 0;
                while (skipped < skip && !reader.EndOfData)
                {
                    reader.ReadLine();
                    skipped++;
                }

                while (!reader.EndOfData && reader.LineNumber <= top)
                {
                    yield return f(reader.LineNumber, reader.ReadFields());
                }
            }
        }

        public static IReadOnlyList<T> ParseAll<T>(this TextFile file, Func<string[], T> f)
            => file.Parse(f).ToList();
    }

}