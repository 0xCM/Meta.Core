//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{

    using System;
    using System.Collections.Generic;
    using System.Linq;


    using SqlT.Core;

    using sxc = contracts;

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class uriAttribute : Attribute
    {
        public uriAttribute(string text)
            => this.text = text;

        public string text { get; }
    }

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class urlAttribute : Attribute
    {
        public urlAttribute(string href)
            => this.href = href;

        public string href { get; }
    }

}