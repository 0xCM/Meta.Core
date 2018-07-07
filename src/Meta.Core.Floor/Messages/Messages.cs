//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Reflection;
using System.Diagnostics;
using System.Runtime.CompilerServices;

using Meta.Core;
using Meta.Core.Modules;

partial class metacore
{

    public static IApplicationMessage Failure<T>(string InputValue)
        => error(@"The value '@InputValue' could not be interpreted as an instance of the @TypeName type",
            new
            {
                InputValue,
                TypeName = typeof(T).Name
            });

    public static IApplicationMessage GuardUnsatisfied(bool isError = false)
        => isError ? error("Guard condition was not satisfied")
            : inform("Guard condition was not satisfied");

    public static IApplicationMessage PredicateUnsatisfied(bool isError = false)
        => isError ? error("Predicate was not satisfied")
            : inform("Predicate was not satisfied");

    public static IApplicationMessage CoordinateMismatch(int expected, int actual)
        => error("Found @actual coordinate values but expected @expected", new
        {
            expected,
            actual
        });

    public static IApplicationMessage MalformedTuple()
        => error("The text was not recognized as a coordinate tuple");

    public static IApplicationMessage StringLengthMismatch(string x, int length)
        => error($"The string '{x}' has length of {x.Length} which unfortunately does not equal the required length {length}");

    public static IApplicationMessage FileNotFound(string Path)
        => inform("The file @Path does not exist",
                new
                {
                    Path
                });

    public static IApplicationMessage DirectoryNotFound(string Path)
        => error(@"The directory @Path does not exist", new
        {
            Path
        });

    public static IApplicationMessage EnvionmentVariableUndefined(string EnvironmentVariableName)
        => error(@"The @EnvironmentVariableName environment variable is not defined",
                new
                {
                    EnvironmentVariableName
                }
            );

    public static IApplicationMessage LoadedFile(string Path)
        => inform("The file @Path was loaded",
                new
                {
                    Path
                });

    public static IApplicationMessage InspectedShell()
        => inform("Executing version @ShellVersion of the @ShellName shell", new
        {
            ShellVersion = Assembly.GetEntryAssembly().GetName().Version,
            ShellName = Assembly.GetEntryAssembly().GetSimpleName()
        });

    public static IApplicationMessage InspectedEnvironment()
        => inform("Hosted by @SystemNode, @Bitness-bit process, .Net @NetVersion, @Shell Version @ShellVersion", new
        {
            Bitness = Environment.Is64BitProcess ? 64 : 32,
            Shell = Assembly.GetEntryAssembly().GetSimpleName(),
            ShellVersion = Assembly.GetEntryAssembly().GetName().Version,
            NetVersion = Assembly.GetEntryAssembly().GetNetFrameworkVersion(),
            SystemNode = SystemNode.Local//ifBlank(EnvironmentVariables.SystemNode.ResolveValue().ValueOrDefault(), $"!!SystemNode variable undefined!!")
        });

    public static IApplicationMessage ErrorOccurred(Exception e)
        => error("An error occurred: @ErrorSummary,  @ErrorDetail",
                new
                {
                    ErrorSummary = e.Message,
                    ErrorDetail = e.ToString()
                }
            );

    public static IApplicationMessage MethodNotImplemented(MethodBase m)
        => error("The method @MethodName declared on the type @TypeName is not implemented",
                new
                {
                    MethodName = m.Name,
                    TypeName = m.DeclaringType.Name
                }
            );
}