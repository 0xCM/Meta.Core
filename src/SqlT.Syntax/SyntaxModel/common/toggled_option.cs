//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using Meta.Models;

    using kwt = SqlKeywordTypes;

    partial class SqlSyntax
    {
        public static class toggled_option
        {
            /// <summary>
            /// Defines an optional toggle
            /// </summary>
            /// <typeparam name="m"></typeparam>
            /// <param name="on"></param>
            /// <returns></returns>
            public static ModelOption<toggled_option<m>> optional<m>(bool? on)
                => on.HasValue 
                ? ModelOption.some<toggled_option<m>>(on.Value)
                : ModelOption.none<toggled_option<m>>();

        }

        public sealed class toggled_option<m> : du<kwt.ON, kwt.OFF>
        {

            public static implicit operator toggled_option<m>(bool on)
                => on 
                ? new toggled_option<m>(ON) 
                : new toggled_option<m>(OFF);

            public static implicit operator toggled_option<m>(kwt.ON ON)
                => new toggled_option<m>(ON);

            public static implicit operator toggled_option<m>(kwt.OFF OFF)
                => new toggled_option<m>(OFF);

            public toggled_option(kwt.ON ON)
                : base(ON)
            { }

            public toggled_option(kwt.OFF OFF)
                : base(OFF)
            {

            }
        }
    }
}