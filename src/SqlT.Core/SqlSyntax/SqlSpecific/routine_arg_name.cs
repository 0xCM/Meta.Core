//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using SqlT.Core;

    using Meta.Syntax;
    using Meta.Models;



    public sealed class routine_arg_name : cdu<IName, SqlVariableName, SqlParameterName>
    {


        public static implicit operator routine_arg_name(string arg_name)
            => new routine_arg_name(new SqlParameterName(arg_name));

        public static implicit operator routine_arg_name(SqlParameterName arg_name)
            => new routine_arg_name(arg_name);


        public static implicit operator routine_arg_name(SqlVariableName routine_variable)
            => new routine_arg_name(routine_variable);

        public routine_arg_name(SqlVariableName arg_name)
            : base(arg_name)
        {

        }
        public routine_arg_name(SqlParameterName arg_name)
            : base(arg_name)
        {

        }


    }


}