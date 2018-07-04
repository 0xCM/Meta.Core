//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;

    using SqlT.Core;
    using SqlT.Syntax;
    using static SqlT.Syntax.SqlSyntax;

    using static metacore;

    using static SqlT.Syntax.SqlNativeTypes;
    



    public class SqlAddMessage : SqlProcedureCall<SqlAddMessage>
    {


        public SqlAddMessage(SqlMessageDefinition MsgDef)
            : base("sp_addmessage",
                  new SqlRoutineParameter("@msgnum", sqlint.Reference()),
                  new SqlRoutineParameter("@severity", smallint.Reference()),
                  new SqlRoutineParameter("@msgtext", nvarchar.Reference(true, 250)),
                  new SqlRoutineParameter("@replace", varchar.Reference(true, 7)),
                  new SqlRoutineParameter("@with_log", varchar.Reference(true, 5)),
                  new SqlRoutineParameter("@lang", nvarchar.Reference(true, 128))
                  )

        {

            this.MsgDef = MsgDef;
        }




        SqlParameterName this[int pos] 
            => SqlParameters[pos].ParameterName;
        

        public SqlMessageDefinition MsgDef { get; }

        string REPLACE
            => MsgDef.Replace ? squote("REPLACE") : NULL;



        public SqlScript ToScript() => concat($"{EXEC} {ActionName} ",
            $"{this[0]}={MsgDef.Identity},",
            $"{this[1]}={(short)MsgDef.Severity},",
            $"{this[2]}={squote(MsgDef.MessageText)},",
            $"{this[3]}={REPLACE},",
            $"{this[4]}={squote(MsgDef.IsLogged.ToString())}");


    }
}
