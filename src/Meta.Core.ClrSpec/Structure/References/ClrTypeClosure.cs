//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

using static metacore;

public static partial class ClrStructureSpec
{

    /// <summary>
    /// Specifies a generic type closure CL(T)(A1...An) for a type T with arguments A1...An
    /// </summary>
    /// <remarks>
    /// A closure defined over a type with with 0 paramters is conidered degenerate and equivalent to
    /// the to the type T itself, i.e. CL(T)() = T. Specifically, this permits closure to be applied
    /// to non-generic types.
    /// </remarks>
    public class ClrTypeClosure : ClrTypeReference
    {
        /// <summary>
        /// Constructs a closure
        /// </summary>
        /// <param name="OpenTypeName">The type over which to close</param>
        /// <param name="TypeArguments">The closure arguments</param>
        /// <returns></returns>
        public static ClrTypeClosure CloseType(IClrTypeName OpenTypeName, params TypeArgument[] TypeArguments)
            => new ClrTypeClosure(OpenTypeName, TypeArguments);

        /// <summary>
        /// Defines an array <see cref="ClrTypeClosure"/>
        /// </summary>
        /// <param name="ArrayItemTypeName"></param>
        protected ClrTypeClosure(IClrTypeName ArrayItemTypeName)
            : base(ClrType.Get<Array>().TypeName)
        {
            TypeArguments = metacore.roitems(new TypeArgument(new TypeParameter(String.Empty, 0), ArrayItemTypeName));
            IsArray = true;
        }

        public ClrTypeClosure(IClrTypeName OpenTypeName, params TypeArgument[] TypeArguments)
            : base(OpenTypeName)
                => this.TypeArguments = rovalues(TypeArguments);

        /// <summary>
        /// The types over which the closure will be defined
        /// </summary>
        public IReadOnlyList<TypeArgument> TypeArguments { get; }

        /// <summary>
        /// Whether the closure specifies an array type
        /// </summary>
        public bool IsArray { get; }
            = false;

        /// <summary>
        /// Specifies whether the closure is defined over a generic type
        /// </summary>
        public bool IsGenericClosure
            => TypeArguments.Count != 0 && not(IsArray);

        public override string ToString()
            => concat(ReferencedType.SimpleName, 
                embrace(String.Join(",", map(TypeArguments, x => x.ArgumentValue.SimpleName))));

    }

}