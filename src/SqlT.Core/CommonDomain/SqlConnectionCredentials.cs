//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SqlConnectionCredentials
    {
        public SqlConnectionCredentials(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }
        public string Username { get; }
        public string Password { get; }

        public override string ToString()
            => $"User Id={Username}; Password={Password}";
    }
}
