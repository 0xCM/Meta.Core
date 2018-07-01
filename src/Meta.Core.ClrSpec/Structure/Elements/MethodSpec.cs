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
    /// Base type for method specifications
    /// </summary>
    /// <typeparam name="T">The derived subtype</typeparam>
    /// <typeparam name="N">The element name type</typeparam>
    public abstract class MethodSpec<T,N> : MemberSpec<T,N>
        where T : MethodSpec<T,N>
        where N : IClrElementName
    {

        public MethodSpec
            (
                IClrElementName DeclaringTypeName,
                N Name,
                ClrTypeReference ReturnType = null,
                ClrAccessKind? AccessLevel = null,
                bool IsStatic = false,
                bool IsExtension = false,
                bool IsAbstract = false,
                bool IsVirtual = false,
                bool IsOverride = false,
                bool IsSealed = false,
                bool IsPartial = false,
                MethodBodySpec Body = null,
                CodeDocumentationSpec Documentation = null,
                ClrCustomMemberIdentifier CustomMemberKind = null,
                IEnumerable<MethodParameterSpec> MethodParameters = null,
                IEnumerable<AttributionSpec> Attributions = null
            )
            : base(DeclaringTypeName, Name, Documentation, null, AccessLevel ?? ClrAccessKind.Default, IsStatic, Attributions, CustomMemberKind)
        {
            this.IsAbstract = IsAbstract;
            this.IsVirtual = IsVirtual;
            this.IsOverride = IsOverride;
            this.IsSealed = IsSealed;
            this.IsPartial = IsPartial;
            this.ReturnType = ReturnType;
            this.MethodParameters = rovalues(MethodParameters).OrderBy(x => x.Position).ToList();
            this.IsExtension = IsExtension;
            this.Body = Body;
        }


        /// <summary>
        /// Specifies the method's return type, if any
        /// </summary>
        public Option<ClrTypeReference> ReturnType{get;}

        /// <summary>
        /// Specifies the method argument parameters
        /// </summary>
        public IReadOnlyList<MethodParameterSpec> MethodParameters;
        
        /// <summary>
        /// Specifies whether the method is an extension method
        /// </summary>
        public bool IsExtension{get;}

        /// <summary>
        /// Specifies the method's body, if applicable
        /// </summary>
        public Option<MethodBodySpec> Body { get; }

        /// <summary>
        /// Specifies whether the method is abstract
        /// </summary>
        public bool IsAbstract {get;}

        /// <summary>
        /// Specifies whether the method is virtual
        /// </summary>
        public bool IsVirtual { get; }

        /// <summary>
        /// Specifies whether the method is an override of a virtual or abstract
        /// method declared in the type's inheritance chain
        /// </summary>
        public bool IsOverride {get; }

        /// <summary>
        /// Specifies whether the method is declared with the sealed modifier
        /// </summary>
        public bool IsSealed { get; }

        /// <summary>
        /// Specifies whether the method is declared with the parital modifier
        /// </summary>
        public bool IsPartial {get;}

    }

    /// <summary>
    /// Characterizes a method
    /// </summary>
    public sealed class MethodSpec : MethodSpec<MethodSpec,ClrMethodName>
    {

        public MethodSpec
            (
                IClrElementName DeclaringTypeName,
                ClrMethodName Name,
                ClrTypeReference ReturnType = null,
                ClrAccessKind? AccessLevel = null,
                bool IsStatic = false,
                bool IsExtension = false,
                bool IsAbstract = false,
                bool IsVirtual = false,
                bool IsOverride = false,
                bool IsSealed = false,
                bool IsPartial = false,
                MethodBodySpec Body = null,
                CodeDocumentationSpec Documentation = null,
                ClrCustomMemberIdentifier CustomMemberKind = null,
                IEnumerable<MethodParameterSpec> MethodParameters = null,
                IEnumerable<AttributionSpec> Attributions = null
            )
            : base(
                  DeclaringTypeName: DeclaringTypeName, 
                  Name: Name, 
                  ReturnType: ReturnType,
                  AccessLevel: AccessLevel,
                  IsStatic: IsStatic,
                  IsExtension: IsExtension,
                  IsAbstract: IsAbstract,
                  IsVirtual: IsVirtual,
                  IsOverride: IsOverride,
                  IsSealed: IsSealed,
                  IsPartial: IsPartial,
                  Body: Body,
                  Documentation: Documentation,
                  CustomMemberKind: CustomMemberKind,
                  MethodParameters: MethodParameters,
                  Attributions: Attributions)
        { }

        public MethodSpec DefineExtension
            (
                IClrElementName DeclaringTypeName,
                ClrMethodName ExtensionName,
                ClrTypeReference ExtendedType,
                ClrTypeReference ReturnType,
                MethodBodySpec Body,
                IEnumerable<AttributionSpec> Attributions = null,
                params MethodParameterSpec[] MethodParameters
            ) => new MethodSpec
            (
                DeclaringTypeName,
                ExtensionName,
                ReturnType: ReturnType,
                AccessLevel: ClrAccessKind.Public,
                IsStatic: true,
                IsExtension: true,
                Body: Body,
                Attributions: Attributions,
                MethodParameters: array(new MethodParameterSpec("@this", ExtendedType, 1), MethodParameters)
            );
    }
}