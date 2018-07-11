//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;    

    /// <summary>
    /// Specifies credentials for authenticating via SQL Server security
    /// </summary>
    public readonly struct SqlConnectionCredentials
    {
        public SqlConnectionCredentials(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }

        /// <summary>
        /// The credential username
        /// </summary>
        public string Username { get; }

        /// <summary>
        /// The credential password
        /// </summary>
        public string Password { get; }

        public override string ToString()
            => $"User Id={Username}; Password={Password}";
    }
}
