//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System.Collections.Generic;

using static metacore;

public static partial class ClrStructureSpec
{
    /// <summary>
    /// Base type for class specifications
    /// </summary>
    /// <typeparam name="T">The specialized subtype</typeparam>
    public abstract class ClassSpec<T> : TypeSpec<T>
        where T : ClassSpec<T>
    {
        public ClassSpec
            (
                ClrClassName Name,
                CodeDocumentationSpec Documentation = null,
                ClrAccessKind? AccessLevel = null,
                IEnumerable<AttributionSpec> Attributions = null,
                IEnumerable<TypeParameter> TypeParameters = null,
                IEnumerable<ClrTypeClosure> BaseTypes = null,
                IEnumerable<ClrInterfaceName> ImplicitRealizations = null,
                IClrElementName DeclaringType = null,
                bool IsStatic = false,
                IEnumerable<IClrMemberSpec> Members = null,
                bool IsPartial = false,
                bool IsSealed = false,
                IEnumerable<IClrTypeSpec> DeclaredTypes = null,
                bool IsAbstract = false
            )
            : base
            (
                Name,
                Documentation,
                AccessLevel ?? ClrAccessKind.Public,
                Attributions ?? array<AttributionSpec>(),
                TypeParameters ?? array<TypeParameter>(),
                BaseTypes ?? array<ClrTypeClosure>(),
                ImplicitRealizations ?? array<ClrInterfaceName>(),
                DeclaringType,
                IsStatic,
                Members ?? array<IClrMemberSpec>(),
                IsPartial: IsPartial
            )
        {
            this.IsSealed = IsSealed;
            this.DeclaredTypes = rolist(DeclaredTypes);
            this.IsAbstract = IsAbstract;
        }
        public bool IsAbstract { get; }

        public bool IsSealed { get; }

        public IReadOnlyList<IClrTypeSpec> DeclaredTypes { get; }

        public override string ToString()
            => $"{AccessLevel} class {Name} " + "{...}";
    }

    /// <summary>
    /// Characterizes a class
    /// </summary>
    public sealed class ClassSpec : ClassSpec<ClassSpec>
    {
        public ClassSpec
            (
                ClrClassName Name,
                CodeDocumentationSpec Documentation = null,
                ClrAccessKind? AccessLevel = null,
                IEnumerable<AttributionSpec> Attributions = null,
                IEnumerable<TypeParameter> TypeParameters = null,
                IEnumerable<ClrTypeClosure> BaseTypes = null,
                IEnumerable<ClrInterfaceName> ImplicitRealizations = null,
                IClrElementName DeclaringType = null,
                bool IsStatic = false,
                IEnumerable<IClrMemberSpec> Members = null,
                bool IsPartial = false,
                bool IsSealed = false,
                IEnumerable<IClrTypeSpec> DeclaredTypes = null,
                bool IsAbstract = false
            )
            : base
            (
                Name,
                Documentation,
                AccessLevel ?? ClrAccessKind.Public,
                Attributions ?? array<AttributionSpec>(),
                TypeParameters ?? array<TypeParameter>(),
                BaseTypes ?? array<ClrTypeClosure>(),
                ImplicitRealizations ?? array<ClrInterfaceName>(),
                DeclaringType,
                IsStatic,
                Members ?? array<IClrMemberSpec>(),
                IsPartial: IsPartial,
                IsSealed: IsSealed,
                DeclaredTypes: DeclaredTypes,
                IsAbstract : IsAbstract
            )
        {
        }
    }
}