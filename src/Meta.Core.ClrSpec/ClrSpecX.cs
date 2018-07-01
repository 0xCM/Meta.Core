//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClrModel;

using static metacore;
using static ClrStructureSpec;
using static ClrBehaviorSpec;

/// <summary>
/// CLR specification factories
/// </summary>
public static class ClrSpecX
{
    public static ClrTypeClosure SpecifyTypeClosure(this ClrClassName typeName, params TypeArgument[] args)
        => new ClrTypeClosure(typeName, args);

    public static IEnumerable<ConstructorSpec> SpecifyStandardConstructors(this ClrClassName typeName, IReadOnlyList<PropertySpec> properties)
    {
        yield return new DefaultConstructorSpec(typeName);
        if (properties.Count != 0)
        {
            yield return new ItemArrayConstructorSpec(typeName, properties);
            yield return new PropertyConstructorSpec(typeName, properties);
        }
    }

    static string FormatGenericName(string unparametrizedName, params string[] parameterNames)
    {
        var parmeters = string.Join(", ", parameterNames);
        return $"{unparametrizedName}<{parmeters}>";
    }

    public static string FormatGenericName(this Type genericType, params string[] parameterNames)
    {
        var arityidx = genericType.Name.IndexOf('`');
        var unparametrizedName = arityidx == -1 ? genericType.Name : genericType.Name.Substring(0, arityidx);
        return FormatGenericName(unparametrizedName, parameterNames);
    }

    public static ClrTypeParameterName TypeParameterName(this string name)
        => new ClrTypeParameterName(name);

    public static TypeParameter TypeParameter(this string name, int position, string description = null)
        => new TypeParameter(name.TypeParameterName(), position, description?.Documentation());

    public static TypeParameter TypeParameter(this ClrTypeParameterName name, int position, string description = null)
        => new TypeParameter(name, position, description?.Documentation());

    public static TypeArgument TypeArgument(this TypeParameter parameter, IClrTypeName typeName)
        => new TypeArgument(parameter, typeName);

    public static CodeDocumentationSpec Documentation(this string x)
        => new ElementDescription(x);

    public static TypeArgument TypeArgument(this
        IClrTypeName typeName,
        string parameterName,
        int position,
        string description = null)
            => parameterName.TypeParameter(position, description).TypeArgument(typeName);

    public static TypeArgument TypeArgument(this
        IClrTypeName typeName,
        ClrTypeParameterName parameterName,
        int position,
        string description = null)
            => parameterName.TypeParameter(position, description).TypeArgument(typeName);

    internal static ClrTypeReference SpecifyClrTypeReference<X>(this X x)
        => ClrType.Reference<X>();

    public static MethodArgumentValueSpec SpecifyArgumentValue(this CoreDataValue v, int idx)
        => new MethodArgumentValueSpec(idx, v.SpecifyCoreExpression());

    public static IClrExpressionSpec SpecifyCoreExpression(this CoreDataValue v)
    {
        if (v.IsDateTime())
        {
            var items = v.ToClrValue<DateTime>().GetItemArray();
            var args = mapi(items,
                (idx, value) => SpecifyArgumentValue(value, idx));
            return new ConstructorInvocationSpec(v.ClrType.GetReference(), args.ToArray());
        }
        else
            return new LiteralValueSpec(v);
    }

    static MethodArgumentValueSpec SpecifyArgumentValue(NamedValue pv)
        =>  (isNull(pv.Value) || object.Equals(pv.Value, DBNull.Value))
            ? new MethodArgumentValueSpec(pv.Name,null)
            : new MethodArgumentValueSpec(pv.Name,
                    new LiteralValueSpec(CoreDataValue.FromObject(pv.Value).Require()));
                     
    public static ConstructorInvocationSpec SpecifyConstructorInvocation
        (
            this ClrClassName declaringType,
            IEnumerable<NamedValue> paramValues
        ) => new ConstructorInvocationSpec
                (
                    declaringType.CreateReference(),
                    map(paramValues, SpecifyArgumentValue).ToArray()
                );

    /// <summary>
    /// Defines a field
    /// </summary>
    /// <param name="DeclaringType">The type that declares the field</param>
    /// <param name="FieldName">The name of the field</param>
    /// <param name="FieldType">The field's type</param>
    /// <param name="AccessLevel">The fields visibility</param>
    /// <param name="IsStatic">Specifies whether the field is static</param>
    /// <param name="IsReadOnly">Specifies whether the field is readonly</param>
    /// <param name="Initializer">Specifies the value with which the field is initialized</param>
    /// <returns></returns>
    public static FieldSpec SpecifyField(this ClrClassName DeclaringType, ClrFieldName FieldName,
        ClrTypeReference FieldType, ClrAccessKind? AccessLevel = null, bool IsStatic = true,
        bool IsReadOnly = true, ConstructorInvocationSpec Initializer = null)
            => new FieldSpec
            (
                    DeclaringTypeName: DeclaringType,
                    Name: FieldName,
                    FieldType: FieldType,
                    AccessLevel: AccessLevel ?? ClrAccessKind.Public,
                    IsStatic: true,
                    IsReadOnly: true,
                    Initializer: Initializer != null ? new FieldInitializerSpec(Initializer) : null
             );

    /// <summary>
    /// Defines a <see cref="FieldSpec"/>
    /// </summary>
    /// <typeparam name="T">The field's type</typeparam>
    /// <param name="declaringType">The type that declares the field</param>
    /// <param name="name">The name of the field</param>
    /// <param name="init">The field initializer</param>
    /// <returns></returns>
    public static FieldSpec SpecifyField<T>(this ClrClassName declaringType, string name, ConstructorInvocationSpec init)
        => new FieldSpec(DeclaringTypeName: declaringType, Name: new ClrFieldName(name),
                FieldType: ClrType.Get<T>().GetReference(), AccessLevel: ClrAccessKind.Public,
                IsStatic: true, IsReadOnly: true, Initializer: new FieldInitializerSpec(init));

    public static ClrNamespaceName SpecifyNamespaceName(this IEnumerable<ClrItemIdentifier> components)
        => new ClrNamespaceName(components.ToArray());

    /// <summary>
    /// Defines a method signature based on relected metadata
    /// </summary>
    /// <param name="method">The reflected method</param>
    /// <returns></returns>
    public static MethodSignature SpecifyMethodSignature(this ClrMethod method)
        => new MethodSignature(method.Name, 
                method.ReturnType.ValueOrDefault().SpecifyClrTypeReference(), 
                map(method.Parameters, p => p.Specify())
            );

    /// <summary>
    /// Defines a consructor invocation
    /// </summary>
    /// <param name="type">The type that defines the constructor</param>
    /// <param name="arguments">The arguments to supply upon invocation</param>
    /// <returns></returns>
    public static ConstructorInvocationSpec CreateObject(this ClrTypeReference type, params MethodArgumentValueSpec[] arguments)
        => new ConstructorInvocationSpec(type, arguments);

    /// <summary>
    /// Defines using namespace directives
    /// </summary>
    /// <param name="namespaces">The namespaces to bring into scope</param>
    /// <returns></returns>
    public static IEnumerable<UsingSpec> SpecifyUsings(this IEnumerable<ClrNamespaceName> namespaces)
        => namespaces.Select(ns => new UsingSpec(ns));

    /// <summary>
    /// Specifies a using statement
    /// </summary>
    /// <param name="ns">The namespace to be brought into scope</param>
    /// <returns></returns>
    public static UsingSpec SpecifyUsing(this ClrNamespaceName ns)
        => new UsingSpec(ns);

    public static MethodSpec SpecifyCustomMethod(this ClrClassName type, ClrCustomMemberIdentifier kind)
    {
        return new MethodSpec
        (
            type,
            kind?.ToString() ?? string.Empty,
            ReturnType: null,
            CustomMemberKind: kind
        );
    }

    /// <summary>
    /// Defines a method parameter
    /// </summary>
    /// <param name="p">The reflected representation of the parameter</param>
    /// <returns></returns>
    public static MethodParameterSpec Specify(this ClrMethodParameter p)
         => new MethodParameterSpec(p.Name, p.ParameterType.GetReference(), p.Position);

    /// <summary>
    /// Defines a literal value
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static LiteralValueSpec SpecifyLiteralValue(this IClrElementName name)
        => name.SimpleName.Value.SpecifyLiteralValue();

    public static string Format(this IEnumerable<ClrTypeLineage> items)
    {
        var sb = new StringBuilder();
        foreach (var item in items.OrderBy(x => x.ToString()))
            sb.AppendLine(item.ToString());
        return sb.ToString();
    }

    /// <summary>
    /// Specifies a reference to a type closure
    /// </summary>
    /// <param name="name">The type to be closed</param>
    /// <param name="args">The arguments used to reify the closure</param>
    /// <returns></returns>
    public static ClrTypeClosure ReferenceTypeClosure(this IClrTypeName name, params TypeArgument[] args)
        => new ClrTypeClosure(name, args);
}