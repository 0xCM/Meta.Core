//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;
    using System.Text;
    using Microsoft.Win32.SafeHandles;
    using static metacore;

    using N = SystemNode;


    enum SymbolicLinkKind
    {
        File = 0,
        Directory = 1
    }


    static class SymbolicLinks
    {
        [DllImport("kernel32.dll")]
        public static extern bool CreateSymbolicLink(string lpSymlinkFileName, string lpTargetFileName, SymbolicLinkKind dwFlags);

    }


}