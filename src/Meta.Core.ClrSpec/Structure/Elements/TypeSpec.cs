//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

using static metacore;

public static partial class ClrStructureSpec
{
    /// <summary>
    /// Base type for type specifications
    /// </summary>
    /// <typeparam name="S">The specializing subtype</typeparam>
    public abstract class TypeSpec<S> : ElementSpec<S>, IClrTypeSpec
        where S : TypeSpec<S>
    {
        protected TypeSpec
            (
                IClrTypeName Name,
                CodeDocumentationSpec Documentation,
                ClrAccessKind AccessLevel,
                IEnumerable<AttributionSpec> Attributions,
                IEnumerable<TypeParameter> TypeParameters,
                IEnumerable<ClrTypeClosure> BaseTypes,
                IEnumerable<ClrInterfaceName> ImplicitRealizations,
                IClrElementName DeclaringType,
                bool IsStatic,
                IEnumerable<IClrMemberSpec> Members,
                bool IsPartial = false
            )
            : base(Name, Documentation, AccessLevel, Attributions)
        {
            this.Members = rovalues(Members);
            this.BaseTypes = rovalues(BaseTypes);
            this.ImplicitRealizations = rovalues(ImplicitRealizations);
            this.TypeParameters = rovalues(TypeParameters);
            this.DeclaringType = DeclaringType != null? some(DeclaringType) : none<IClrElementName>();
            this.IsStatic = IsStatic;
            this.IsPartial = IsPartial;
        }

        /// <summary>
        /// Specifies the members defined for the type
        /// </summary>
        public IReadOnlyList<IClrMemberSpec> Members { get; }

        /// <summary>
        /// Specifies the types' generic parameters
        /// </summary>
        public IReadOnlyList<TypeParameter> TypeParameters { get; }

        /// <summary>
        /// Specifies the types' base types
        /// </summary>
        public IReadOnlyList<ClrTypeClosure> BaseTypes { get; }

        /// <summary>
        /// If the type is nested, specifies the declaring type
        /// </summary>
        public Option<IClrElementName> DeclaringType { get; }

        /// <summary>
        /// Names of interfaces for which no explicit implementation is given
        /// </summary>
        public IReadOnlyList<IClrTypeName> ImplicitRealizations { get; }

        /// <summary>
        /// Specifies whether the type is declared with the static modifier
        /// </summary>
        public bool IsStatic { get; }

        /// <summary>
        /// Specifies whether the type is declared with the partial modifier
        /// </summary>
        public bool IsPartial { get; }

        IClrElementName IClrTypeSpec.TypeName
            => Name;
    }

}