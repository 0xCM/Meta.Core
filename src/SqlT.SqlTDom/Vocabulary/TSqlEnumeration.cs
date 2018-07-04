//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dom
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using static metacore;


    public class TSqlEnumeration
    {
        public string EnumTypeName { get; set; }

        public TSqlEnumerationLiteral[] Literals { get; set; }

        public override string ToString()
            => $"{EnumTypeName}{embrace(string.Join(" ", stream(Literals)))}";
    }


}
