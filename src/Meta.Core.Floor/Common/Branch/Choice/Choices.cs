//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    using Modules;

    using static metacore;

    using G = ChoiceGrammar;
    public class Choices : Choice<Seq<Choice>>
    {
        public static Seq<EnumChoice<E>> FromEnum<E>()
            where E : Enum => from l in ClrEnum.Get<E>().Literals
                select new EnumChoice<E>(parseEnum<E>(l.LiteralName));

        public new static Choices Parse(string Value)
        {                  
            var parts = Value.Bifurcate(G.Entails);
            var identity = parts.Left.Bifurcate(G.OfType);
            var choices = Seq.make(parts.Right.Split(G.Or).Select(x => Choice.Parse(x)));
            return new Choices(identity, choices);
        }
        
        public Choices(ChoiceIdentity Identity, Seq<Choice> Choices)
            : base(Identity, Choices)
        {

        }

        public override int GetHashCode()
            => Identity.GetHashCode() & Value.GetHashCode();

        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case Choices other:
                    return Identity == other.Identity
                        && Value == other.Value;
                default:
                    return false;
            }
        }
        public override string ToString()
            =>  $"{Identity} {G.Entails} {string.Join(G.Or, Value.Stream())}";
    }
}