//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.IO;


    using static metacore;

    /// <summary>
    /// Encapsulates a block of JSON text
    /// </summary>
    public sealed class Json : IEquatable<Json>
    {
        public static readonly Json Empty = new Json();

        public static Json FromText(string text)
            => new Json(text);

        public static implicit operator string(Json x)
            => x?.Text ?? String.Empty;

        public static implicit operator Json(string x)
            => new Json(x);

        public Json()
        {
            this.Text = string.Empty;
        }

        public Json(string Text)
            => this.Text = Text ?? String.Empty;

        /// <summary>
        /// The encapsulated JSON
        /// </summary>
        public string Text { get; }

        public bool Equals(Json other)
            => other != null && other.Text == this.Text;

        public override int GetHashCode()
            => Text.GetHashCode();

        public override bool Equals(object obj)
            => this.Equals(obj as Json);

        public override string ToString()
            => Text;
    }
}