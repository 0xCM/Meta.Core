//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using static metacore;

    using sxc = contracts;
    using static SqlSyntax;

    partial class SqlSyntax
    {

        public sealed class restore_database : statement<restore_database>
        {
            public restore_database(simple_database_name database_name, FilePath target_path)
                : base(DATABASE)
            {
                this.database_name = database_name;
                this.target_path = target_path;
            }


            public simple_database_name database_name { get; }

            public FilePath target_path { get; }

            public override string ToString()
                => $"{RESTORE} {database_name} {FROM} {DISK} = {target_path}";

        }
    }


}