//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dom
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;
    using System.ComponentModel;

    [Description("Classifies TSQL DOM Properties")]
    public enum SqlDomPropertyKind
    {
        [Description("Indicates that no classification has been assigned")]
        None = 0,

        [Description("Identifies a property that defines a SQL DOM attribute")]
        Attribute,

        [Description("Identifies a property that defines a SQL DOM association")]
        Association,

        [Description("Identifies a property that defines a SQL DOM collection")]
        Collection,
    }
}