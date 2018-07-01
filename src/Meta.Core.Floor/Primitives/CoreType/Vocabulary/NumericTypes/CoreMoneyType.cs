//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System.Globalization;

public sealed class CoreMoneyType : CoreDataType<decimal>
{
    const NumberStyles AllowedStyles = NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign;

    internal CoreMoneyType(bool IsSmall = false)
        : base(IsSmall ? CoreDataTypeNames.SmallMoney : CoreDataTypeNames.Money)
    {

    }

    public override decimal ParseTypedValue(string value)
        => decimal.Parse(value, AllowedStyles);
}

