//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

/// <summary>
/// Declares the supported runtime environments
/// </summary>
public class RuntimeEnvironments : HostedFieldList<RuntimeEnvironment, RuntimeEnvironments>
{
    /// <summary>
    /// Represents the absence of an environment
    /// </summary>
    public static readonly RuntimeEnvironment NONE
        = new RuntimeEnvironment(String.Empty, RuntimeEnvironmentKind.None);

    /// <summary>
    /// Identifies a production environment
    /// </summary>
    public static readonly RuntimeEnvironment Prod 
        = new RuntimeEnvironment(RuntimeEnvironmentNames.PROD, RuntimeEnvironmentKind.Prod);

    /// <summary>
    /// Identifies a team development environment
    /// </summary>
    public static readonly RuntimeEnvironment Dev 
        = new RuntimeEnvironment(RuntimeEnvironmentNames.DEV, RuntimeEnvironmentKind.Dev);

    /// <summary>
    /// Identifies a test environment
    /// </summary>
    public static readonly RuntimeEnvironment DevTest 
        = new RuntimeEnvironment(RuntimeEnvironmentNames.TEST, RuntimeEnvironmentKind.DevTest);

    /// <summary>
    /// Identifies a local environment
    /// </summary>
    public static readonly RuntimeEnvironment Local 
        = new RuntimeEnvironment(RuntimeEnvironmentNames.LOC, RuntimeEnvironmentKind.Local);

    /// <summary>
    /// Identifies an environment specialized for quality assurance
    /// </summary>
    public static readonly RuntimeEnvironment QaTest
        = new RuntimeEnvironment(RuntimeEnvironmentNames.QA, RuntimeEnvironmentKind.QaTest);

    /// <summary>
    /// Identifies an environment specialized for user acceptance testing
    /// </summary>
    public static readonly RuntimeEnvironment UserTest
        = new RuntimeEnvironment(RuntimeEnvironmentNames.UAT, RuntimeEnvironmentKind.UserTest);
}