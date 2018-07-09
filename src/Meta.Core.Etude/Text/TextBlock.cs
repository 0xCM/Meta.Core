//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Text
{
    using System;
    using System.Linq;

    using static metacore;

    public readonly struct TextBlock
    {
        public TextBlock(string Text, TextPosition Position)
        {
            this.Text = Text;
            this.Position = Position;
        }

        public string Text { get; }

        public TextPosition Position { get; }

        public bool Finished
            => Position.ColumnNumber > Text.Length;

        public TextBlock Reposition(TextPosition NewPosition)
            => new TextBlock(this.Text, NewPosition);

        public char this[int pos]
            => Text[pos - 1];

        public string this[int startpos, int len]
            => Text.Substring(startpos - 1, len);

        public char Current
            => this[Position.ColumnNumber];

        public TextBlock Advance(int distance = 1)
            => new TextBlock(Text, Position.AdvanceColumn(distance));

        public override string ToString()
            => not(Finished)
            ? Text.Substring(Position.ColumnNumber - 1)
            : string.Empty;


    }
}