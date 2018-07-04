//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

using static metacore;

public static partial class ClrStructureSpec
{
    /// <summary>
    /// Sepecifies the content of a source file
    /// </summary>
    public class CodeFileSpec : ValueObject<CodeFileSpec>
    {
        public static CodeFileSpec operator + (CodeFileSpec x, CodeFilePreamble y)
            => x.WithPreamble(y);

        public static CodeFileSpec operator + (CodeFileSpec x, IEnumerable<UsingSpec> y)
            => x.WithUsings(array(y));

        public static CodeFileSpec operator + (CodeFileSpec x, IEnumerable<IClrElementSpec> y)
            => x.WithElements(array(y));

        public CodeFileSpec(FilePath FilePath, IEnumerable<UsingSpec> Usings,
                IEnumerable<IClrElementSpec> ElementDefinitions, CodeFilePreamble Preamble)
        {
            this.FileName = FilePath;
            this.Usings = rovalues(Usings);
            this.ElementDefinitions = rovalues(ElementDefinitions);
            this.Preamble = Preamble;
        }

        public CodeFileSpec(FilePath FilePath, IEnumerable<UsingSpec> Usings,
                params IClrElementSpec[] ElementDefinitions)
        {
            this.FileName = FilePath;
            this.Usings = rovalues(Usings);
            this.ElementDefinitions = rovalues(ElementDefinitions);
        }

        public CodeFileSpec(FilePath FilePath, params IClrElementSpec[] ElementDefinitions)
        {
            this.FileName = FilePath;
            this.Usings = rovalues<UsingSpec>(stream<UsingSpec>());
            this.ElementDefinitions = rovalues(ElementDefinitions);
        }

        public FilePath FileName { get; }

        public IReadOnlyList<UsingSpec> Usings { get; }

        public IReadOnlyList<IClrElementSpec> ElementDefinitions { get; }

        public Option<CodeFilePreamble> Preamble { get; }

        public CodeFileSpec WithElements(params IClrElementSpec[] ElementDefinitions)
            => new CodeFileSpec
            (
                FileName,
                Usings,
                this.ElementDefinitions.Union(ElementDefinitions),
                this.Preamble.ValueOrDefault()
            );

        public CodeFileSpec WithElements(IEnumerable<IClrElementSpec> ElementDefinitions)
            => new CodeFileSpec
            (
                FileName,
                Usings,
                this.ElementDefinitions.Union(ElementDefinitions),
                this.Preamble.ValueOrDefault()
            );

        public CodeFileSpec WithUsings(params UsingSpec[] Usings)
            => new CodeFileSpec
            (
                FileName,
                this.Usings.Union(Usings),
                this.ElementDefinitions,
                this.Preamble.ValueOrDefault()
            );

        public CodeFileSpec WithPreamble(CodeFilePreamble Preamble)
            => new CodeFileSpec
            (
                FileName,
                Usings,
                ElementDefinitions,
                Preamble
            );

        public override string ToString()
            => FileName;
    }
}