//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    /// <summary>
    /// Encapsulates basic status/error message content
    /// </summary>
    public class SqlMessage 
    {
        public static readonly SqlMessage Empty 
            = new SqlMessage(String.Empty);

        public static implicit operator string(SqlMessage x) 
            => x.MessageText;

        SqlMessage InnerMessage { get; }

        SqlError SourceError { get; }

        string Text { get; }
        
        public SqlMessage(IApplicationMessage message)
        {
            this.Text = message.Format(false);
        }

        public SqlMessage(string text)
        {
            this.Text = text;
        }

        public SqlMessage(string text, SqlMessage InnerMessage)
        {
            this.Text = text;
            this.InnerMessage = InnerMessage;
        }

        public SqlMessage(SqlError error)
        {
            this.SourceError = error;
            this.Text = error.Message;
        }

        public bool IsEmpty
            => Object.ReferenceEquals(this, Empty);

        public string MessageText
            =>$"{Text} {InnerMessage?.Text ?? String.Empty}".Trim();

        public virtual bool IsErrorMessage
            => InnerMessage != null 
            ? InnerMessage.IsErrorMessage 
            : false ;

        public override string ToString() 
            => MessageText;
    }

    

}
