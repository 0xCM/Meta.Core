//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using Meta.Core;    
    using Meta.Models;
    
    using sxc = Syntax.contracts;

    public sealed class SqlDatePartType : Model<SqlDatePartType>,  sxc.scalar_expression
    {

        internal SqlDatePartType(string Identifier, params string[] Synonyms)
        {
            this.Synonyms = Synonyms.ToReadOnlySet();
            this.PartIdentifier = Identifier;
        }

        public SqlIdentifier PartIdentifier { get; }

        public ReadOnlySet<string> Synonyms { get; }

    }
}
