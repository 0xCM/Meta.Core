//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.InteropServices;

using Meta.Core;

using static metacore;

public static class WinIni
{
    [DllImport("kernel32")]
    static extern int WritePrivateProfileString(string iniSection, string iniKey, string iniValue, string iniFilePath);

    public static void WriteValue(string iniSection, string iniKey, string iniValue, string iniFilePath)
        => WritePrivateProfileString(iniSection, iniKey, iniValue, iniFilePath);

}