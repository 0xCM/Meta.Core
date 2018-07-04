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
    /// Specifies a simple identifer for type of database element
    /// </summary>
    public sealed class simple_element_name : simple_name<simple_element_name>, ISimpleSqlName
    {
        public static simple_element_name specify(string text, bool quoted = true)
            => new simple_element_name(text, quoted);

        public static readonly simple_element_name Empty 
            = specify(string.Empty, false);

        public static implicit operator simple_element_name(string text)
            => new simple_element_name(text);

        public static implicit operator string(simple_element_name name)
            => name.text;

        public static implicit operator SqlIdentifier(simple_element_name name)
            => new SqlIdentifier(name.text, name.quoted);


        public simple_element_name(string text, bool quoted = true)
            : base(text,quoted)
        {
            
        }

    }



}