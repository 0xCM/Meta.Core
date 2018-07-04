//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using static metacore;

    /// <summary>
    /// Decribes a sql parser error
    /// </summary>
    public class SqlParseErrorMessage
    {
        public SqlParseErrorMessage(int ErrorNumber, int Offset, int Line, int Column, string MessageText)
        {
            this.ErrorNumber = ErrorNumber;
            this.Offset = Offset;
            this.Line = Line;
            this.Column = Column;
            this.MessageText = MessageText;

        }

        public int ErrorNumber { get; }

        public int Offset { get; }

        public int Line { get; }

        public int Column { get; }

        public string MessageText { get; }

        public override string ToString()
            => MessageText;

    }



}