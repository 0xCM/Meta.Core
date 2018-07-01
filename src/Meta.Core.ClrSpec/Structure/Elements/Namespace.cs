//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static metacore;

public static partial class ClrStructureSpec
{
    /// <summary>
    /// Characterizes a namespace
    /// </summary>
    public class NamespaceSpec : ElementSpec<NamespaceSpec>
    {

        public NamespaceSpec(ClrNamespaceName Name, params IClrElementSpec[] DeclaredElements)
            : base(Name,null, ClrAccessKind.Default, array<AttributionSpec>())
        {
            this.DeclaredElements = DeclaredElements;
            this.Usings = array<UsingSpec>();
        }

        public NamespaceSpec(ClrNamespaceName Name, IEnumerable<IClrElementSpec> DeclaredElements,
                IEnumerable<UsingSpec> Usings) 
                    :  base(Name, null, ClrAccessKind.Default, array<AttributionSpec>())
        {
            this.DeclaredElements = rovalues(DeclaredElements);
            this.Usings = rovalues(Usings);
        }

        /// <summary>
        /// Specifies the types declared in the declared in the namespace
        /// </summary>
        public IEnumerable<IClrTypeSpec> DeclaredTypes 
            => DeclaredElements.OfType<IClrTypeSpec>();

        /// <summary>
        /// Specifies the elements declared in the declared in the namespace
        /// </summary>
        public IReadOnlyList<IClrElementSpec> DeclaredElements { get; }

        public IReadOnlyList<UsingSpec> Usings { get; }

        public new ClrNamespaceName Name 
            => cast<ClrNamespaceName>(base.Name);

        public override string ToString() 
            => Name;
    }
}