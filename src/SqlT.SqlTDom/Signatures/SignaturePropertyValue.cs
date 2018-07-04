//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dom
{
    using System;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;
    using static metacore;

    public struct SignaturePropertyValue
    {

        public SignaturePropertyValue(ClrProperty Property, object Value)
        {
            this.Property = Property;
            this.Value = Value;
        }

        public ClrProperty Property { get; }

        public object Value { get; }


        public override string ToString()
            => toString(Value);
    }


}