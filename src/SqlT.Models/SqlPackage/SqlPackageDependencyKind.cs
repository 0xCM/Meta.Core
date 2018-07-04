//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
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
