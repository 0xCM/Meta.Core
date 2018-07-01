//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using static metacore;

    using System;
    using System.Collections.Generic;
    using System.Linq;


    public class VariableName : SemanticIdentifier<VariableName, string>
    {

        public static implicit operator VariableName(string Identifier)
            => new VariableName(Identifier);

        VariableName()
            : base(string.Empty)
        {

        }

        VariableName(string Identifier)
            : base(Identifier)
        { }

        public Option<string> Description { get; }

        protected override VariableName New(string IdentifierText)
            => new  VariableName(Identifier);

        public override string ToString()
            => $"$({IdentifierText})";


        public string Name
            => this.IdentifierText;
    }
 
}