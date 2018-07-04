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
    /// Specifies the  simple name (database relative) of a schema 
    /// </summary>
    public class simple_schema_name : simple_name<simple_schema_name>
    {
        public static implicit operator simple_schema_name(string text)
            => new simple_schema_name(text);

        public static implicit operator string(simple_schema_name name)
            => name.ToString();
       
        public simple_schema_name(string identifier, bool quoted = true)
            : base(identifier,quoted)
        {

        }



    }


}
