//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Models
{
    using System;
    using System.Collections.Generic;
   
    using static metacore;
   

    public abstract class Identifier<T> : Model<T>, IIdentifier
        where T : Identifier<T>
    {
        public Identifier(string text)
        {
            this.IdentifierText = text;
        }

        /// <summary>
        /// The unquoted identifier text
        /// </summary>
        public string IdentifierText { get; }

        public override bool IsEmpty
            => isBlank(IdentifierText);

        public override string ToString()
            => IdentifierText;

    }

    /// <summary>
    /// Represents an identifier within the context of the syntax being modeled
    /// </summary>
    public sealed class Identifier : Identifier<Identifier>, IIdentifier, IEquatable<Identifier>
    {
        public static bool operator ==(Identifier x, Identifier y)
            => equals(x.IdentifierText, y.IdentifierText);

        public static bool operator !=(Identifier x, Identifier y)
            => not(equals(x.IdentifierText, y.IdentifierText));

        public Identifier(string text)
            : base(text)
        {
            
        }

        /// <summary>
        /// The canonical empty value
        /// </summary>
        public static new readonly Identifier empty
            = new Identifier(string.Empty);

        /// <summary>
        /// Implicitly converts a string to an (unquoted) identifier
        /// </summary>
        /// <param name="text">The text to convert</param>
        public static implicit operator Identifier(string text)
            => new Identifier(text);

        /// <summary>
        /// Implicitly renders the identifier
        /// </summary>
        /// <param name="x">The identifer to render</param>
        public static implicit operator string(Identifier x)
            => x.ToString();

        public override int GetHashCode()
            => IdentifierText.ToLower().GetHashCode();

        public bool Equals(Identifier other)
            => other.IdentifierText.ToLower() == IdentifierText.ToLower();

        public override bool Equals(object obj)
        {
            if (obj is Identifier x)
                return x.Equals(this);
            else
                return false;
        }

    }
}