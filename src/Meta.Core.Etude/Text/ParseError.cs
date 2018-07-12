//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Text
{
    using static metacore;

    public readonly struct ParseError
    {
        public ParseError(TextBlock Text, IAppMessage Message)
        {

            this.Text = Text;
            this.Message = Message;
        }

        public ParseError(TextBlock Text, string Message)
        {

            this.Text = Text;
            this.Message = error(Message);
        }

        /// <summary>
        /// The block posioned at the point of failure
        /// </summary>
        public TextBlock Text { get; }

        /// <summary>
        /// The reason for failure
        /// </summary>
        public IAppMessage Message { get; }

        public override string ToString()
            => Message.Format();
    }
}