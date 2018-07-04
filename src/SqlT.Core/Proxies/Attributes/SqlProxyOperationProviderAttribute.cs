//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;

    public class SqlProxyOperationProviderAttribute : Attribute
    {
        readonly Type _ContractType;
        public SqlProxyOperationProviderAttribute(Type ContractType)
        {
            this._ContractType = ContractType;
        }

        public Type ContractType 
            => _ContractType;
    }
}