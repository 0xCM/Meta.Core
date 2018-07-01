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
    /// Characterizes a conversion operator signature
    /// </summary>
    public class ConversionOperatorSignature : ElementSpec<ConversionOperatorSignature>
    {
        public ConversionOperatorSignature(ClrTypeReference InputType,ClrTypeReference ReturnType,
                ConversionOperatorKind ConversionKind,IEnumerable<TypeParameter> TypeParameters = null,
                CodeDocumentationSpec Documentation = null) 
                    : base(new ClrMemberOperatorName(""), Documentation: Documentation, 
                          AccessLevel: ClrAccessKind.Default)
        {            
            this.ConversionKind = ConversionKind;
            this.InputType = InputType;
            this.ReturnType = ReturnType;
            this.TypeParameters = rovalues(TypeParameters).OrderBy(x => x.Position).ToList();
        }

        public ConversionOperatorKind ConversionKind { get; }

        public ClrTypeReference InputType { get; }

        public ClrTypeReference ReturnType { get; }

        public IReadOnlyList<TypeParameter> TypeParameters { get; }

        public override string ToString()
            => $"{AccessLevel} static {ConversionKind} operator {ReturnType}({InputType})";
    }

}