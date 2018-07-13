//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

partial class Reflections
{

    /// <summary>
    /// Determines whether a property is an indexer
    /// </summary>
    /// <param name="p">The property to examine</param>
    /// <returns></returns>
    public static bool IsIndexer(this PropertyInfo p)
        => p.GetIndexParameters().Length > 0;

    /// <summary>
    /// Determines whether the property has a public or non-public setter
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
    public static bool HasSetter(this PropertyInfo p)
        => p.TryGetSetter().Exists;

    /// <summary>
    /// Determines whether the property has a public or non-public getter
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
    public static bool HasGetter(this PropertyInfo p)
        => p.TryGetGetter().Exists;

    /// <summary>
    /// Attempts to determine whether a method is sporting the "new" keyword
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// Approach adapted from https://stackoverflow.com/questions/288357/how-does-reflection-tell-me-when-a-property-is-hiding-an-inherited-member-with-t
    /// </remarks>
    public static bool IsHidingBaseMember(this MethodInfo self)
    {
        Type baseType = self.DeclaringType.BaseType;
        var baseMethod = baseType.GetMethod(self.Name, self.GetParameters().Select(p => p.ParameterType).ToArray());

        if (baseMethod == null)
            return false;

        if (baseMethod.DeclaringType == self.DeclaringType)
            return false;

        var baseMethodDefinition = baseMethod.GetBaseDefinition();
        var thisMethodDefinition = self.GetBaseDefinition();

        return baseMethodDefinition.DeclaringType != thisMethodDefinition.DeclaringType;
    }

    /// <summary>
    /// Determines whether a method is an action
    /// </summary>
    /// <param name="m">The method to examine</param>
    /// <returns></returns>
    public static bool IsAction(this MethodInfo m)
        => m.ReturnType == typeof(void);

    /// <summary>
    /// Determines whether a method is a function
    /// </summary>
    /// <param name="m">The method to examine</param>
    /// <returns></returns>
    public static bool IsFunction(this MethodInfo m)
        => m.ReturnType != typeof(void);

    /// <summary>
    /// Determines whether the method is an implicit conversion operator
    /// </summary>
    /// <param name="m">The method to test</param>
    /// <returns></returns>
    public static bool IsImplicitConverter(this MethodInfo m)
        => string.Equals(m.Name, "op_Implicit", StringComparison.InvariantCultureIgnoreCase);

    /// <summary>
    /// Determines whether the method is an explicit conversion operator
    /// </summary>
    /// <param name="m">The method to test</param>
    /// <returns></returns>
    public static bool IsExplicitConverter(this MethodInfo m)
        => string.Equals(m.Name, "op_Explicit", StringComparison.InvariantCultureIgnoreCase);

    /// <summary>
    /// Determines whether an attribute is applied to a member
    /// </summary>
    /// <typeparam name="A">The type of attribute for which to check</typeparam>
    /// <param name="m">The member to examine</param>
    /// <returns></returns>
    public static bool HasAttribute<A>(this MemberInfo m) where A : Attribute
        => Attribute.IsDefined(m, typeof(A));

}