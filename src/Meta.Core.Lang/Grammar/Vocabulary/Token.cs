//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Syntax
{
    using System;
    using System.Linq;

    using static metacore;

    /// <summary>
    /// Represents a token, a value to which semantics may be attached
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct Token<T> : IToken<T>
    {
        public static implicit operator Token(Token<T> t)
            => Token.Define(t.Name, t.Value);

        public Token(string Name, T Value, string Description = null)
        {
            this.Name = Name;
            this.Value = Value;
            this.Description = Description;         
        }

        /// <summary>
        /// The token name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The token value
        /// </summary>
        public T Value { get; }

        /// <summary>
        /// Specifies the purpose of the token
        /// </summary>
        public Option<string> Description { get; }

        object IToken.Value
            => Value;

        public override string ToString()
            => toString(Value);
    }

    /// <summary>
    /// Represents a token, a value to which semantics may be attached
    /// </summary>
    public struct Token : IToken<string>
    {
        public static Token<T> Define<T>(string Name, T Value, string Description = null)
            => new Token<T>(Name, Value, Description);

        public static Token Define(string Name, string Value = null, string Description = null)
            => new Token(Name, Value, Description);

        Token(string Name, string Value, string Description = null)
        {
            this.Name = Name;
            this.Value = ifBlank(Value, Name);
            this.Description = Description;
        }

        /// <summary>
        /// The token name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The token value
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Specifies the purpose of the token
        /// </summary>
        public Option<string> Description { get; }

        object IToken.Value
            => Value;

        public override string ToString()
            => toString(Value);
    }

}