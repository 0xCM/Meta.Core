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

public sealed class CoreDateType : CoreDataType<Date>
{
    internal CoreDateType()
        : base(CoreDataTypeNames.Date)
    {

    }

    protected override object Convert(Date srcValue, Type dstClrType)
    {
        if (dstClrType.IsDateTime())
            return srcValue.ToDateTimeAtMidnight();
        else if (dstClrType.IsString())
            return srcValue.ToLexicalString();
        else
            return base.Convert(srcValue, dstClrType);
    }

    public override bool IsTemporal
        => true;

    public override string CreateValueText(Date value)
        => value.ToString("yyyy-MM-dd");

    public override Date ParseTypedValue(string text)
        => Date.Parse(text);
}
