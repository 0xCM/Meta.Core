//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Templates
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
