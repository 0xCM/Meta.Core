//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;

using static metacore;

public static partial class ClrStructureSpec
{

    /// <summary>
    /// Characterizes a method signature
    /// </summary>
    public class MethodSignature : ElementSpec<MethodSignature>
    {
        public MethodSignature
            (
                ClrMethodName Name,
                ClrTypeReference ReturnType = null,
                IEnumerable<MethodParameterSpec> MethodParameters = null,
                IEnumerable<TypeParameter> TypeParameters = null,
                CodeDocumentationSpec Documentation = null
            ) : base(Name, Documentation: Documentation, AccessLevel: ClrAccessKind.Default)
        {

            this.MethodName = Name;
            this.ReturnType = ReturnType;
            this.MethodParameters = rovalues(MethodParameters).OrderBy(x => x.Position).ToList();
            this.TypeParameters = rovalues(TypeParameters).OrderBy(x => x.Position).ToList();
        }

        /// <summary>
        /// The method's name
        /// </summary>
        public ClrMethodName MethodName { get; }

        /// <summary>
        /// The method's return type
        /// </summary>
        public ClrTypeReference ReturnType { get; }

        /// <summary>
        /// The method's value parameters
        /// </summary>
        public IReadOnlyList<MethodParameterSpec> MethodParameters { get; }

        /// <summary>
        /// The method's type parameters
        /// </summary>
        public IReadOnlyList<TypeParameter> TypeParameters { get; }

        public override string ToString()
            => $"{ReturnType} {Name}({string.Join(", ", MethodParameters)})";
    }

}