//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Patterns
{
    using SqlT.Models;
    using SqlT.Core;
    using System;

    public class CreateTableMergeProcedure : CreateProcedure<CreateTableMergeProcedure>
    {

        public CreateTableMergeProcedure()
        {

        }

        public CreateTableMergeProcedure(SqlProcedureName Name)
            : base(Name)
        {

        }


        public SqlTable Source { get; set; }

        public SqlTable Target { get; set; }

        public override SqlProcedure Render()
        {
            throw new NotImplementedException();
        }
    }

}
