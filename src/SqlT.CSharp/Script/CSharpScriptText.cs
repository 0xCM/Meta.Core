﻿//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.CSharp
{

    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CSharpScriptText 
    {

        public CSharpScriptText(string Body)
        {
            this.Body = Body;
        }

        public string Body { get; }

        public override string ToString()
            => Body;

    }


}