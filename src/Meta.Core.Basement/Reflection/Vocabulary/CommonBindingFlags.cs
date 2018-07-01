//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Reflection;

/// <summary>
/// Defines useful collection of reflection binding flags
/// </summary>
public static class CommonBindingFlags
{
    public const BindingFlags BF_Instance
        = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

    public const BindingFlags BF_Static =
        BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;

    public const BindingFlags BF_AllRestrictedInstance
        = BindingFlags.FlattenHierarchy | BindingFlags.NonPublic | BindingFlags.Instance;

    public const BindingFlags BF_DeclaredRestrictedInstance
        = BindingFlags.DeclaredOnly | BindingFlags.NonPublic | BindingFlags.Instance;

    public const BindingFlags BF_PublicInstance
        = BindingFlags.Public | BindingFlags.Instance;

    public const BindingFlags BF_PublicStatic
        = BindingFlags.Public | BindingFlags.Static;

    public const BindingFlags BF_DeclaredPublicInstance
        = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance;

    public const BindingFlags BF_DeclaredNonPublicInstance
        = BindingFlags.DeclaredOnly | BindingFlags.NonPublic | BindingFlags.Instance;

    public const BindingFlags BF_AllPublicInstance
        = BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance;

    public const BindingFlags BF_DeclaredPublicStatic
        = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Static;

    public const BindingFlags BF_DeclaredNonPublicStatic
        = BindingFlags.DeclaredOnly | BindingFlags.NonPublic | BindingFlags.Static;

    public const BindingFlags BF_Declared
        = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;

    public const BindingFlags BF_DeclaredStatic
        = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;

    public const BindingFlags BF_DeclaredInstance
        = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

    public const BindingFlags BF_AllPublicStatic
        = BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Static;

    public const BindingFlags BF_PublicNonPublic
       = BindingFlags.Public | BindingFlags.NonPublic;

    public const BindingFlags BF_InstanceStatic
        = BindingFlags.Instance | BindingFlags.Static;

    public const BindingFlags AnyVisibilityOrInstanceType
        = BindingFlags.Public
        | BindingFlags.NonPublic
        | BindingFlags.Instance
        | BindingFlags.Static;

}

public enum MemberInstanceType
{
    Instance = 0,
    Static = 1
}
