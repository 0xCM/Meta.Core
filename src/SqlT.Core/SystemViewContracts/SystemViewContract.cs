//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;

    [AttributeUsage(AttributeTargets.Interface)]
    public class SystemViewContractAttribute : Attribute
    {
        private readonly string _SystemViewName;

        public SystemViewContractAttribute(string SystemViewName)
        {
            this._SystemViewName = SystemViewName;
        }

        public SqlObjectName SystemViewName => _SystemViewName;
      
    }
}
