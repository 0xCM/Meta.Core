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

public sealed class CoreDateTimeType : CoreDataType<DateTime>
{
    static string GetSpecificName(bool legacy, bool small)
    {
        if (legacy && !small)
            return CoreDataTypeNames.LegacyDateTime;
        else if (legacy && small)
            return CoreDataTypeNames.LegacySmallDateTime;
        else
            return CoreDataTypeNames.DateTime;

    }

    public CoreDateTimeType(bool IsLegacy = false, bool IsSmall = false)
        : base(GetSpecificName(IsLegacy, IsSmall), false, true)
    {

    }

    public override string CreateValueText(DateTime value) 
        => value.ToString("yyyy-MM-dd HH:mm:ss.fff");

    public override DateTime ParseTypedValue(string value) 
        => DateTime.Parse(value);

    public override bool IsTemporal
        => true;

    protected override object Convert(DateTime srcValue, Type dstClrType)
    {
        if (dstClrType.IsDate())
            return srcValue.ToDate();
        else if (dstClrType.IsString())
            return srcValue.ToString();
        else
            return base.Convert(srcValue, dstClrType);
    }
}
