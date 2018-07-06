//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using SqlT.Core;

    using static metacore;

    public class SqlMessageDefinition : SqlModel<SqlMessageDefinition>
    {
        public static SqlMessageDefinition Define(int msgnum, SqlSeverityLevel severity,
            string msg, string language = null, bool with_log = false)
                => new SqlMessageDefinition(new SqlMessageIdentity(msgnum, language), msg, severity, with_log);

        public SqlMessageDefinition
        (
            SqlMessageIdentity Identity, 
            string Text, 
            SqlSeverityLevel Severity = SqlSeverityLevel.Level01, 
            bool IsLogged = false,
            bool Replace = false,
            string Language = null
        )
        {
            this.Identity = Identity;
            this.MessageText = Text;
            this.Severity = Severity;
            this.IsLogged = IsLogged;
            this.Replace = Replace;
            this.Language = ifBlank(Language, "us_english");
        }

        public SqlMessageIdentity Identity { get; }

        public string MessageText { get; }

        public SqlSeverityLevel Severity { get; }

        public bool IsLogged { get; }

        public string Language { get; }

        public bool Replace { get; }

        public override string ToString()
              => concat("exec sp_addmessage ",
                  $"@msgnum={Identity.MessageId}, ",
                  $"@severity={(short)Severity}, ", 
                  $"@msgtext={squote(MessageText)}, ",
                  $"@lang={squote(Identity.Language)},",
                  $"@with_log={squote(IsLogged.ToString())}"
                  );            

    }
}
