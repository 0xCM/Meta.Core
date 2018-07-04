//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System.Collections.Generic;

    using sxc = contracts;
    using Meta.Models;

    using SqlT.Core;
    using System;
    using static metacore;


    public sealed class server_qualified_database_name : Model<server_qualified_database_name>, ICompositeSqlName
    {
        public server_qualified_database_name(simple_server_name server_name, simple_database_name database_name)
        {
            this.database_name = database_name;
            this.server_name = server_name;
            this.quoted = quoted;
        }

        public simple_server_name server_name { get; }

        public simple_database_name database_name { get; }

        public bool quoted { get; }

        public override bool IsEmpty
            =>server_name.IsEmpty && database_name.IsEmpty;

        public IReadOnlyList<string> NameComponents
            => new string[] {server_name, database_name};

        public string text
           => concat(
               server_name.IsEmpty ? string.Empty : toString(server_name) + dot(),
               database_name.IsEmpty ? string.Empty : toString(database_name)
               );



        public override string ToString()
            => text;


    }

}