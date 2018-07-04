//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{

    /// <summary>
    /// Encapsulates a username/password used to authenticate with server
    /// or contained database or a windows username to be used with
    /// integrated security
    /// </summary>
    public class SqlUserCredentials : ValueObject<SqlUserCredentials>
    {

        public static readonly SqlUserCredentials Integrated = new SqlUserCredentials(SqlUserName.Empty);

        public static implicit operator string(SqlUserCredentials x) 
            => x.ToString();

        SqlUserCredentials()
        { }

        public SqlUserCredentials(SqlUserName UserName, string Password)
        {
            this.UserName = UserName;
            this.Password = Password;
        }

        public SqlUserCredentials(SqlUserName UserName)
        {
            this.UserName = UserName;
            this.Password = string.Empty;
        }

        public SqlUserName UserName { get; }

        public string Password { get; }

        public bool IntegratedSecurity
            => string.IsNullOrWhiteSpace(Password);

        public override string ToString() 
            => IntegratedSecurity 
            ? $"UserId = {UserName}; Integrated Security=true" 
            : $"UserId = {UserName}; Password = {Password}";

    }
}
