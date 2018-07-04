//This file was generated at 5/12/2018 8:42:10 PM using version 1.2018.3.3482 the SqT data access toolset.
namespace SqlT.Types.Lists
{
    using SqlT.Types.MC;
    using System.Collections.Generic;
    using System;
    using System.ComponentModel;
    using SqlT.Core;

    public class RegisteredTools : TypedItemList<RegisteredTools, ToolRegistration>
    {
        public readonly static ToolRegistration MsBuild = new ToolRegistration("MsBuild", "msbuild.exe", null);
        public readonly static ToolRegistration SqlT = new ToolRegistration("SqlT", "SqlT.exe", null);
        public readonly static ToolRegistration SqlPackage = new ToolRegistration("SqlPackage", "sqlpackage.exe", null);
    }
}
// Emission concluded at 5/12/2018 8:42:10 PM
