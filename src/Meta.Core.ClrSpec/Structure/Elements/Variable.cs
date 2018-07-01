//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------

using static metacore;

public static partial class ClrStructureSpec
{
    /// <summary>
    /// Represents a generic parameter defined by a type or method
    /// </summary>
    public sealed class Variable : ElementSpec<Variable>
    {
        public Variable(ClrVariableName Name, ClrTypeReference typeref = null, CodeDocumentationSpec Documentation = null)
            : base(Name, Documentation, ClrAccessKind.Default, array<AttributionSpec>())
        {
            this.VariableType = typeref;
        }

        public Option<ClrTypeReference> VariableType { get; }
    }
}