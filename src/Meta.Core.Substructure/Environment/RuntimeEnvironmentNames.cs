//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// The names of well-known development/runtime environments
/// </summary>
public class RuntimeEnvironmentNames : HostedFieldList<string, RuntimeEnvironmentNames>
{
    
    /// <summary>
    /// Identifies the production environment
    /// </summary>
    public const string PROD = "PROD";

    /// <summary>
    /// Identifies the primary/team development environment
    /// </summary>
    public const string DEV = "DEV";

    /// <summary>
    /// Identifies the test environment
    /// </summary>
    public const string TEST = "TEST";

    /// <summary>
    /// Identifies the local environment
    /// </summary>
    public const string LOC = "LOC";

    /// <summary>
    /// Identifies a QS environment
    /// </summary>
    public const string QA = "QA";

    /// <summary>
    /// Identifies a UAT environment
    /// </summary>
    public const string UAT = "UAT";
}

