//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{
    using SqlT.Syntax;
    using SqlT.Models;
    
    public class SqlCmdShell : SqlProcedureCall<SqlCmdShell>
    {
        public SqlCmdShell(string CommandString)
            : base("xp_cmdshell", new SqlRoutineParameter("@command_string", SqlNativeTypes.varchar.Reference(length: 8000)))
        {
            this.CommandString = CommandString;
        }

        [SqlTemplateParameter(null, "@command_string")]
        public string CommandString { get; set; }  
    }
}
