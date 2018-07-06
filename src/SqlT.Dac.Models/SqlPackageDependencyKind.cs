//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.ComponentModel;

    [Description("Classifies the type of dependency that exists between two packages")]
    public enum SqlPackageDependencyKind : byte
    {
        [Description("Indicates lack of dependency information")]
        Unspecified = 0,

        [Description("Indicates that one package is embedded within another")]
        Composite = 1,

        [Description("Indicates that the database into which the client package is deployed references the supplier package through a database deployed on the same server")]
        SameServer = 2,

        [Description("Indicates that the database into which the client package is deployed references a supplier package through a database deployed on a different server")]
        OtherServer = 3
    }
}
