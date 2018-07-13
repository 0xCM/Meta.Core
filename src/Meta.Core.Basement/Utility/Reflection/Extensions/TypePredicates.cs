//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

partial class Reflections
{
    /// <summary>
    /// Determines whether a type has a public default constructor
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    public static bool HasDefaultPublicConstructor(this Type t)
        => t.GetConstructor(new Type[] { }) != null;

    /// <summary>
    /// Determines whether a type has a public default constructor
    /// </summary>
    /// <typeparam name="T">The type to examine</typeparam>
    /// <returns></returns>
    public static bool HasDefaultPublicConstructor<T>()
        where T : class 
            => typeof(T).GetConstructor(new Type[] { }) != null;

    /// <summary>
    /// Determines whether the member instance classification is equivalent to static
    /// </summary>
    /// <param name="mit">The instance classification</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsStaticType(this MemberInstanceType mit)
        => mit == MemberInstanceType.Static;

    /// <summary>
    /// Determines whether a type implements a specified interface
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <param name="interfaceType">The interface type</param>
    /// <returns></returns>
    public static bool Realizes(this Type t, Type interfaceType)
        => interfaceType.IsInterface && t.GetInterfaces().Contains(interfaceType);

    /// <summary>
    /// Determines whether a type implements a specific interface
    /// </summary>
    /// <typeparam name="T">The interface type</typeparam>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    public static bool Realizes<T>(this Type t)
        => typeof(T).IsInterface && t.GetInterfaces().Contains(typeof(T));

    /// <summary>
    /// Determines whether a type is nullable
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNullableType(this Type t)
        => t.IsGenericType
            && t.GetGenericTypeDefinition() == typeof(Nullable<>);

    /// <summary>
    /// Determines whether a type is a nullable or non-nullable type with a given underlying type
    /// </summary>
    /// <typeparam name="T">The type to match</typeparam>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool IsTypeOf<T>(this Type t)
        => t == typeof(T) || t.IsNullableType<T>();

    /// <summary>
    /// Determines whether a supplied type is either a <see cref="DateTime"/> or a <see cref="Nullable{DateTime}"/>
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsDateTime(this Type t)
        => t.IsTypeOf<DateTime>();

    /// <summary>
    /// Determines whether a supplied type is either a <see cref="Int16"/> or a <see cref="Nullable{Int16}"/>
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsInt16(this Type t)
        => t.IsTypeOf<Int16>();

    /// <summary>
    /// Determines whether a supplied type is either a <see cref="Int32"/> or a <see cref="Nullable{Int32}"/>
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsInt32(this Type t)
        => t.IsTypeOf<Int32>();

    /// <summary>
    /// Determines whether a supplied type is either a <see cref="Int64"/> or a <see cref="Nullable{Int64}"/>
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsInt64(this Type t)
        => t.IsTypeOf<Int64>();

    /// <summary>
    /// Determines whether a supplied type is either a <see cref="UInt16"/> or a <see cref="Nullable{UInt16}"/>
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsUInt16(this Type t)
        => t.IsTypeOf<UInt16>();

    /// <summary>
    /// Determines whether a supplied type is either a <see cref="UInt32"/> or a <see cref="Nullable{UInt32}"/>
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsUInt32(this Type t)
        => t.IsTypeOf<UInt32>();

    /// <summary>
    /// Determines whether a supplied type is either a <see cref="UInt64"/> or a <see cref="Nullable{UInt64}"/>
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsUInt64(this Type t)
        => t.IsTypeOf<UInt64>();

    /// <summary>
    /// Determines whether a supplied type is either a <see cref="Byte"/> or a <see cref="Nullable{Byte}"/>
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsUInt8(this Type t)
        => t.IsTypeOf<Byte>();

    /// <summary>
    /// Determines whether a supplied type is either a <see cref="SByte"/> or a <see cref="Nullable{SByte}"/>
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsInt8(this Type t)
        => t.IsTypeOf<SByte>();

    /// <summary>
    /// Determines whether a supplied type is one of the intrinsic integral types or a nullable type thereof
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsInteger(this Type t)
        => t.IsInt32() || t.IsInt64() || t.IsInt8() || t.IsInt16()
        || t.IsUInt8() || t.IsUInt32() || t.IsUInt64() || t.IsUInt16();

    /// <summary>
    /// Determines whether a supplied type is DBNull
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsDbNull(this Type t)
        => t.IsTypeOf<DBNull>();

    /// <summary>
    /// Determines whether a supplied type is either a <see cref="TimeSpan"/> or a <see cref="Nullable{TimeSpan}"/>
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsTimeSpan(this Type t)
        => t.IsTypeOf<TimeSpan>();


    /// <summary>
    /// Determines whether a supplied type is either a <see cref="Boolean"/> or a <see cref="Nullable{Boolean}"/>
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsBool(this Type t)
        => t.IsTypeOf<Boolean>();

    /// <summary>
    /// Determines whether a supplied type is either a <see cref="Decimal"/> or a nullable <see cref="Nullable{Decimal}"/>
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsDecimal(this Type t)
        => t.IsTypeOf<Decimal>();

    /// <summary>
    /// Determines whether a supplied type is of type string
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsString(this Type t)
        => t == typeof(string);

    /// <summary>
    /// Determines whether a supplied type is either a <see cref="Char"/> or a nullable <see cref="Nullable{Char}"/>
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsChar(this Type t)
        => t.IsTypeOf<Char>();

    /// <summary>
    /// Determines whether a supplied type is either a <see cref="Guid"/> or a nullable <see cref="Nullable{Guid}"/>
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsGuid(this Type t)
        => t.IsTypeOf<Guid>();

    /// <summary>
    /// Determine whether a type is a nullable type with a given underlying type
    /// </summary>
    /// <typeparam name="T">The underlying type</typeparam>
    /// <param name="t">The type to check</param>
    /// <returns>
    /// Returns true if t is both a nullable type and is of type T
    /// </returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNullableType<T>(this Type t)
        => t.IsNullableType() && Nullable.GetUnderlyingType(t) == typeof(T);

    /// <summary>
    /// Determines whether a type is an intrinsic numeric type
    /// </summary>
    /// <param name="type">The type to evaluate</param>
    /// <returns></returns>
    public static bool IsNumber(this Type type)
    {
        switch (Type.GetTypeCode(type))
        {
            case TypeCode.Byte: case TypeCode.Decimal: case TypeCode.Double:
            case TypeCode.Int16: case TypeCode.Int32: case TypeCode.Int64:
            case TypeCode.SByte: case TypeCode.Single: case TypeCode.UInt16:
            case TypeCode.UInt32: case TypeCode.UInt64:
                return true;
            case TypeCode.Object:
                if (type.IsNullableType())
                    return IsNumber(Nullable.GetUnderlyingType(type));
                return false;
        }
        return false;
    }

    /// <summary>
    /// Determines whether a type is anonymous
    /// </summary>
    /// <param name="type">The type to test</param>
    /// <returns></returns>
    /// <remarks>
    /// Lifted from: https://github.com/NancyFx/Nancy/blob/master/src/Nancy/ViewEngines/Extensions.cs
    /// </remarks>
    public static bool IsAnonymous(this Type type)
        => type == null ? false : type.GetTypeInfo().IsGenericType
                && (type.GetTypeInfo().Attributes & TypeAttributes.NotPublic) == TypeAttributes.NotPublic
                && (type.Name.StartsWith("<>", StringComparison.OrdinalIgnoreCase) || type.Name.StartsWith("VB$", StringComparison.OrdinalIgnoreCase))
                && (type.Name.Contains("AnonymousType") || type.Name.Contains("AnonType"))
                && type.GetTypeInfo().GetCustomAttributes(typeof(CompilerGeneratedAttribute)).Any();

    /// <summary>
    /// Determines whether the type is an option type and if so returns the underlying option
    /// type encapsulated within an option ( ! ). Otherwise, none
    /// </summary>
    /// <param name="candidate">the type to test</param>
    /// <returns></returns>
    public static bool IsOption(this Type candidate)
        => candidate.Realizes<IOption>();

    /// <summary>
    /// Determines whether a type has a name
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    public static bool IsNamed(this Type t)
        => !t.IsAnonymous();

    /// <summary>
    /// Determines whether a type is static
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsStatic(this Type t)
        => t.IsAbstract && t.IsSealed;

    /// <summary>
    /// Determines whether a type is a struct
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    [DebuggerStepThrough, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsStruct(this Type t)
        => t.IsValueType && !t.IsEnum;

    /// <summary>
    /// Determines whether the specified type is a delegate type
    /// </summary>
    /// <param name="t">The type to examine</param>
    /// <returns></returns>
    public static bool IsDelegate(this Type t)
        => t.IsSubclassOf(typeof(Delegate));

}