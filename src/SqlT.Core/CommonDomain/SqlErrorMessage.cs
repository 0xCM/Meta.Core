//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Data.SqlClient;

    public class SqlErrorMessage : SqlMessage
    {
        public static implicit operator SqlErrorMessage(SqlException e) 
            => new SqlErrorMessage(e);

        public static implicit operator SqlErrorMessage(Exception e) 
            => new SqlErrorMessage(e);


        public SqlErrorMessage(string context, SqlMessage InnerMessage)
            : base(context, InnerMessage)
        { }


        public SqlErrorMessage(SqlError error)
            : base(error)
        { }

        public SqlErrorMessage(SqlException e)
            : base(e.ToString())
        {

        }

        public SqlErrorMessage(Exception e)
            : base(e.ToString())
        {

        }

        public SqlErrorMessage(string text)
            : base(text)
        { }

        public override bool IsErrorMessage
            => true;
    }
}