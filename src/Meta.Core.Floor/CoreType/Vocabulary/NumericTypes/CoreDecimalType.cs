//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

using static metacore;

public sealed class CoreDecimalType : CoreDataType<decimal>
{
    private const NumberStyles AllowedStyles = NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign;

    internal CoreDecimalType()
        : base(CoreDataTypeNames.Decimal, true, true)
    {

    }

    public override decimal ParseTypedValue(string value) 
        => Decimal.Parse(value, AllowedStyles);

}
