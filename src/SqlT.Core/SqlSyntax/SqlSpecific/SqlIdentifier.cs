//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections.Generic;

    using SqlT.Core;
    using Meta.Models;

    using static metacore;

    using sxc = contracts;

    /// <summary>
    /// Specifies a simple (non-componentized) identifier
    /// </summary>
    public class SqlIdentifier : Identifier<SqlIdentifier>, ISqlIdentifier, IEquatable<SqlIdentifier>
    {
        public static bool operator ==(SqlIdentifier x, SqlIdentifier y)
            => equals(x.IdentifierText, y.IdentifierText);

        public static bool operator !=(SqlIdentifier x, SqlIdentifier y)
            => not(equals(x.IdentifierText, y.IdentifierText));        

        /// <summary>
        /// The canonical empty value
        /// </summary>
        public static new readonly SqlIdentifier empty 
            = new SqlIdentifier(string.Empty, false);

        /// <summary>
        /// Implicitly converts a string to an (unquoted) identifier
        /// </summary>
        /// <param name="text">The text to convert</param>
        public static implicit operator SqlIdentifier(string text)
            => new SqlIdentifier(text, false);

        /// <summary>
        /// Implicitly renders the identifier
        /// </summary>
        /// <param name="x">The identifer to render</param>
        public static implicit operator string(SqlIdentifier x)
            => x.ToString();

        public SqlIdentifier(string text, bool quoted)
            : base(text)
        {            
            this.Quoted = quoted;
        }

        /// <summary>
        /// Whether the identifier should be quoted when rendered
        /// </summary>
        public bool Quoted { get; }

        public SqlIdentifier unquoted()
            => new SqlIdentifier(IdentifierText, false);

        public override string ToString()
            => Quoted ? bracket(IdentifierText) : IdentifierText;

        public override int GetHashCode()
            => IdentifierText.ToLower().GetHashCode();

        public bool Equals(SqlIdentifier other)
            => other.IdentifierText.ToLower() == IdentifierText.ToLower();

        public override bool Equals(object obj)
        {
            if (obj is SqlIdentifier x)
                return x.Equals(this);
            else
                return false;
        }


    }

}