//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
public static partial class ClrBehaviorSpec
{

    /// <summary>
    /// Defines a legagal identifier
    /// </summary>
    public sealed class IdentifierSpec : ExpressionSpec<IdentifierSpec>
    {
        public static implicit operator ClrItemIdentifier(IdentifierSpec x) 
            => x.ItemIdentifier;

        public static implicit operator IdentifierSpec(ClrItemIdentifier x) 
            => new IdentifierSpec(x);

        public readonly ClrItemIdentifier ItemIdentifier;

        public IdentifierSpec(ClrItemIdentifier ItemIdentifier)
        {
            this.ItemIdentifier = ItemIdentifier;
        }

        public override string ToString()
            => ItemIdentifier.ToString();
    }


}


