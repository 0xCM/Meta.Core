//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Text
{
    using System;
    using System.Linq;
   
    using static minicore;

    public enum WhitespaceKind : ushort
    {
        /// <summary>
        /// Indicates the absence of a classification
        /// </summary>
        None,

        /// <summary>
        /// Identifies a space
        /// </summary>
        Space,

        /// <summary>
        /// Identifies a carriage return
        /// </summary>
        CR,

        /// <summary>
        /// Identifies a line feed
        /// </summary>
        LF,
        
        /// <summary>
        /// Identifies a tab
        /// </summary>
        Tab
    }


    public readonly struct Whitespace
    {
        //public static Option<Whitespace> Parse(char c)


        public static readonly Whitespace Empty = default;
        public static readonly Whitespace Space = new Whitespace(WhitespaceKind.Space, ' ');
        public static readonly Whitespace CR = new Whitespace(WhitespaceKind.CR, '\r');
        public static readonly Whitespace LF = new Whitespace(WhitespaceKind.LF, '\n');
        public static readonly Whitespace Tab = new Whitespace(WhitespaceKind.Tab, '\t');

        public static readonly ReadOnlyList<Whitespace> All = array(Space, CR, LF, Tab);

        /// <summary>
        /// Determines whether a specified character is a whitespace character
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        public static bool IsWhitespace(char test)
            => All.Any(x => x.Character == test);

        /// <summary>
        /// Assigns a whitespace classification to a character
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        public static WhitespaceKind Classify(char test)
            => (from x in All
               where x.Character == test
               select x.Kind).FirstOrDefault();

        Whitespace(WhitespaceKind Kind, char Character)
        {
            this.Kind = Kind;
            this.Character = Character;
        }

        public WhitespaceKind Kind { get; }

        public char Character { get; }

        public override string ToString()
            => Kind.ToString();

        
    }


}