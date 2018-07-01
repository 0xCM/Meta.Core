//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

public static partial class ClrStructureSpec
{
    /// <summary>
    /// Characterizes a method parameter
    /// </summary>
    public sealed class MethodParameterSpec : ElementSpec<MethodParameterSpec>
    {
        public MethodParameterSpec(ClrMethodParameterName Name, ClrTypeReference ParameterType,
                int? Position = null, bool IsParameterArray = false, CodeDocumentationSpec Documentation = null,
                IEnumerable<AttributionSpec> Attributions = null)
                    : base(Name, Documentation, ClrAccessKind.Default, Attributions)
        {
            this.ParameterType = ParameterType;
            this.Position = Position;
            this.IsParameterArray = IsParameterArray;
        }

        /// <summary>
        /// Specifies the parameter's position
        /// </summary>
        public int? Position { get; }

        /// <summary>
        /// Specifies the parameter's type
        /// </summary>
        public ClrTypeReference ParameterType { get; }

        public bool IsParameterArray { get; }

        public override string ToString()
            => $"{ParameterType} {Name}";
    }
}