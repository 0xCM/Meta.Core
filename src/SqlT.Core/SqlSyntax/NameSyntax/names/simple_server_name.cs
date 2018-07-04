//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System.Collections.Generic;

    using sxc = contracts;
    using SqlT.Core;
    using System;
    using static metacore;


    /// <summary>
    /// Specifies the simple name of a server
    /// </summary>
    public class simple_server_name : simple_name<simple_server_name>, ISimpleSqlName
    {
        public static implicit operator simple_server_name(string text)
            => new simple_server_name(text);

        public static implicit operator string(simple_server_name name)
            => name.text;


        public simple_server_name(string text, bool quoted = true)
            : base(text,quoted)
        {
        }


    }



}