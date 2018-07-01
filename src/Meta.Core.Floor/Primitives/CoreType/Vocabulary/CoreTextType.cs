//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

using static metacore;

public sealed class CoreTextType : CoreDataType<string>
{
    internal CoreTextType(string DataTypeName)
        : base
        (
            DataTypeName,
            DataTypeName != CoreDataTypeNames.AnsiTextMax &&
            DataTypeName != CoreDataTypeNames.UnicodeTextMax
        )
    {

    }
    public override bool IsText 
        => true;

    public override string ParseTypedValue(string value) 
        => value;
}
