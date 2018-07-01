//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Build
{
    using System;
    using System.Reflection;

    using static metacore;
    using static xmlfunc;

    partial class BuildSyntax
    {


        public class AssemblyReference : SyntaxElement<AssemblyReference>
        {

            public AssemblyReference(AssemblyName Include, FilePath HintPath = null, bool Private = false, string Label = null)
                : base(new ElementDescriptor("", Label))
            {
                this.Include = Include;
                this.HintPath = HintPath ?? FilePath.Empty;
                this.Private = Private;
            }


            public AssemblyName Include { get; set; }

            public FilePath HintPath { get; set; }

            public bool Private { get; set; }

            public override string ToXml()
                => tag
                    ("Reference",
                        block
                        (
                            tag(nameof(HintPath), HintPath),
                            tag(nameof(Private), Private)
                        ),
                        (nameof(Include), Include.Name)
                    );

        }

    }
}
