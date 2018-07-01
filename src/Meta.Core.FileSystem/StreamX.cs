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
    using System.IO;

    using static metacore;

    public static class FileSystemX
    {
        /// <summary>
        /// Reads all bytes from a stream and returns the result
        /// </summary>
        /// <param name="Src">The stream to read</param>
        /// <returns></returns>
        public static Option<byte[]> ReadAllBytes(this Stream Src)
            => Use(new MemoryStream(), stream =>
            {
                Src.CopyTo(stream);
                return stream.ToArray();
            });

        /// <summary>
        /// Reads all the text available from a stream and returns the result
        /// </summary>
        /// <param name="Src">The stream to read</param>
        /// <returns></returns>
        public static string ReadAllText(this Stream Src)
        {
            using (var reader = new StreamReader(Src))
                return reader.ReadToEnd();
        }

        /// <summary>
        /// Reads all lines of text from a file and returns the result
        /// </summary>
        /// <param name="Src">The file to read</param>
        /// <returns></returns>
        public static IReadOnlyList<TextLine> ReadAllLines(this ITextFile Src)
            => mapi(File.ReadAllLines(Src.SourcePath), (i, s) => new TextLine(i + 1, s));
    }
}