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
    public sealed class TypeParameter : ElementSpec<TypeParameter>
    {
        public readonly int Position;

        public TypeParameter(ClrTypeParameterName ParameterName, int Position, CodeDocumentationSpec Documentation = null)
            : base(ParameterName, Documentation, ClrAccessKind.Default, array<AttributionSpec>())
        {
            this.Position = Position;
        }
    }


}