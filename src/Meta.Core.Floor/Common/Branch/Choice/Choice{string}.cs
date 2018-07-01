//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    using G = ChoiceGrammar;

    public class Choice : Choice<string>
    {
        public static new Choice Parse(string Choice)
        {
            var parts = Choice.Bifurcate(G.Entails);
            var identity = parts.Left.Bifurcate(G.OfType);
            return new Choice(identity, parts.Right.Trim());
        }

        public Choice(ChoiceIdentity Identity, string Value)
            : base(Identity, Value)
        { }

    }
}