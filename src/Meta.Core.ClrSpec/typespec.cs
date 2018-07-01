//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

using static metacore;
using static ClrStructureSpec;
using static ClrBehaviorSpec;

using ClrModel;

/// <summary>
/// Type specification combinators
/// </summary>
public static class typespec
{
    /// <summary>
    /// Specifies a method argument value
    /// </summary>
    /// <param name="name">The name of the argument</param>
    /// <param name="value">The argument value</param>
    /// <param name="pos">The argument position</param>
    /// <returns></returns>
    public static MethodArgumentValueSpec argval(string name, IClrExpressionSpec value, int? pos = null)
        => new MethodArgumentValueSpec(name, value, pos);

    /// <summary>
    /// Specifies a method argument value
    /// </summary>
    /// <param name="name">The name of the argument</param>
    /// <param name="value">The argument value</param>
    /// <param name="pos">The argument position</param>
    /// <returns></returns>
    public static MethodArgumentValueSpec argval(string name, object value, int? pos = null)
        => new MethodArgumentValueSpec(name, literal(value), pos);

    /// <summary>
    /// Specifies a type closure
    /// </summary>
    /// <param name="openType">The name of the type over which to close</param>
    /// <param name="arguments">The arguments supplied to the type parameters</param>
    /// <returns></returns>
    public static ClrTypeClosure close(ClrTypeName openType, params (ClrTypeName argType, string argName)[] arguments)
        => new ClrTypeClosure(openType,
                arrayi(arguments, (i, parameter) => typearg(parameter.argType, parameter.argName, i)));

    /// <summary>
    /// Specifies a type closure
    /// </summary>
    /// <param name="arguments">The arguments supplied to the type parameters</param>
    /// <returns></returns>
    public static ClrTypeClosure close<t>(params (ClrTypeName argType, string argName)[] arguments)
        => close(name<t>(), arguments);
        
    /// <summary>
    /// Specifies a type closure
    /// </summary>
    /// <param name="arguments">The arguments supplied to the type parameters</param>
    /// <returns></returns>
    public static ClrTypeClosure close<t>(params Type[] arguments)
        => close<t>(map(arguments, arg => (ClrTypeName.Define(arg.Name), string.Empty)).ToArray());

    /// <summary>
    /// Specifies a degenerate closure
    /// </summary>
    /// <returns></returns>
    public static ClrTypeClosure close(ClrTypeName openType)
        => new ClrTypeClosure(openType);

    /// <summary>
    /// Specifies a type closure
    /// </summary>
    /// <param name="typeArgs">The arguments supplied to the type parameters</param>
    /// <returns></returns>
    public static ClrTypeClosure close(ClrTypeName openType, params ClrTypeName[] typeArgs)
        => new ClrTypeClosure(openType, arrayi(typeArgs, (i, parameter) => typearg(parameter, i)));

    /// <summary>
    /// Specifies a default constructor
    /// </summary>
    /// <param name="declaringType">The constructed type</param>
    /// <returns></returns>
    public static ConstructorSpec constructor(ClrTypeName declaringType)
        => new ConstructorSpec(declaringType);

    /// <summary>
    /// Specifies a constant field
    /// </summary>
    /// <param name="declaringType">The name of the declaring type</param>
    /// <param name="namedValue"></param>
    /// <returns></returns>
    /// <typeparam name="t">The constant type</typeparam>
    public static FieldSpec constField<t>(ClrTypeName declaringType, NamedValue namedValue, ClrAccessKind? access = null)
        => new FieldSpec
        (
             declaringType,
             Name: namedValue.Name,
             FieldType: reference<t>(),
             AccessLevel: access ?? ClrAccessKind.Public,
             IsConst: true,
             Initializer: literal(namedValue.Value)
        );

    /// <summary>
    /// Specifies a literal value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static LiteralValueSpec literal(CoreDataValue value)
        => new LiteralValueSpec(value);

    /// <summary>
    /// Converts an object to a core data value
    /// </summary>
    /// <param name="o">The object to convert</param>
    /// <returns></returns>
    public static CoreDataValue coreval(object o)
        => CoreDataValue.FromObject(o).Map(x => x, () => CoreDataValue.Empty);

    /// <summary>
    /// Specifies a literal value
    /// </summary>
    /// <param name="value">The defining object value</param>
    /// <returns></returns>
    public static LiteralValueSpec literal(object value)
        => new LiteralValueSpec(coreval(value));

    /// <summary>
    /// Gets the name of the type
    /// </summary>
    /// <typeparam name="t">The type</typeparam>
    /// <returns></returns>
    public static ClrTypeName name<t>()
        => ClrTypeName.Adapt(ClrType.Get<t>().TypeName);

    /// <summary>
    /// Specifies a method parameter
    /// </summary>
    /// <typeparam name="t">The parameter type</typeparam>
    /// <param name="name">The paramter name</param>
    /// <param name="pos">The 0-based position of the parameter</param>
    /// <returns></returns>
    public static MethodParameterSpec parameter<t>(ClrMethodParameterName name, int? pos = null)
        => new MethodParameterSpec(name, reference<t>(), pos);

    /// <summary>
    /// Specifies a method parameter
    /// </summary>
    /// <param name="type">The parameter type</param>
    /// <param name="name">The paramter name</param>
    /// <param name="pos">The 0-based position of the parameter</param>
    /// <returns></returns>
    public static MethodParameterSpec parameter(Type type, ClrMethodParameterName name, int? pos = null)
        => new MethodParameterSpec(name, reference(type), pos);

    /// <summary>
    /// Specifies a list of homgenously-typed method parameters
    /// </summary>
    /// <typeparam name="t">The common parameter type</typeparam>
    /// <param name="names">The paramter names</param>
    /// <returns></returns>
    public static IReadOnlyList<MethodParameterSpec> parameters<t>(params ClrMethodParameterName[] names)
        => mapi(names, (pos, name) => parameter<t>(name, pos));

    /// <summary>
    /// Specifies a list of method parameters
    /// </summary>
    /// <returns></returns>
    public static IReadOnlyList<MethodParameterSpec> parameters(params (Type type, string name)[] specs)
        => mapi(specs, (pos, spec) => parameter(spec.type, spec.name, pos));

    /// <summary>
    /// Specifies a type reference
    /// </summary>
    /// <typeparam name="t">The type for which a reference will be created</typeparam>
    /// <returns></returns>
    public static ClrTypeReference reference<t>()
        => ClrType.Reference<t>();

    /// <summary>
    /// Specifies a type reference
    /// </summary>
    /// <param name="t">The type to reference</param>
    /// <returns></returns>
    public static ClrTypeReference reference(ClrType t)
        => t.GetReference();

    /// <summary>
    /// Specifies a type reference
    /// </summary>
    /// <param name="t">The type to reference</param>
    /// <returns></returns>
    public static ClrTypeReference reference(Type t)
        => t.SpecifyClrTypeReference();

    /// <summary>
    /// Specifies a type reference
    /// </summary>
    /// <param name="name">The name of the type to reference</param>
    /// <param name="isNullable"></param>
    /// <returns></returns>
    public static ClrTypeReference reference(ClrTypeName name, bool isNullable = false)
        => new ClrTypeReference(name, isNullable);

    /// <summary>
    /// Specifies a method signature
    /// </summary>
    /// <param name="declaringType">The name of the declaring type</param>
    /// <param name="methodName">The name of the method</param>
    /// <param name="returnType">The name of the method return type, if any</param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public static MethodSpec signature(ClrTypeName declaringType, ClrMethodName methodName,
        ClrTypeName returnType = null, params MethodParameterSpec[] parameters)
        => new MethodSpec
        (
            declaringType,
            Name: methodName,
            MethodParameters: parameters,
            ReturnType: ifNull(null, () => reference(returnType))
        );
    
    /// <summary>
    /// Specifies a named/positional type argument
    /// </summary>
    /// <param name="argType">The name of the type supplied as an argument</param>
    /// <param name="argName">The type parameter name</param>
    /// <param name="pos">The type parameter position</param>
    /// <returns></returns>
    public static TypeArgument typearg(ClrTypeName argType, string argName, int pos)
        => new TypeArgument(argName.SpecifyTypeParameter(pos), argType);

    /// <summary>
    /// Specifies a positional type argument
    /// </summary>
    /// <param name="argType">The name of the type supplied as an argument</param>
    /// <param name="pos">The 0-based argument position</param>
    /// <returns></returns>
    public static TypeArgument typearg(ClrTypeName argType, int pos)
        => new TypeArgument(new TypeParameter(ClrTypeParameterName.Empty, pos), argType);

    /// <summary>
    /// Specifies a list of using namespace directives
    /// </summary>
    /// <param name="namespaces"></param>
    /// <returns></returns>
    public static IReadOnlyList<UsingSpec> use(params ClrNamespaceName[] namespaces)
        => map(namespaces, ns => new UsingSpec(ns));

    /// <summary>
    /// Specifies a using namespace directive
    /// </summary>
    /// <param name="namespaces"></param>
    /// <returns></returns>
    public static IReadOnlyList<UsingSpec> use(params string[] namespaces)
        => use(map(namespaces, ns => ns.SpecifyNamespaceName()).ToArray());

    /// <summary>
    /// Specifies an attribution with no parameters
    /// </summary>
    /// <typeparam name="A"></typeparam>
    /// <returns></returns>
    public static AttributionSpec attrib<A>()
        where A : Attribute => AttributionSpec.Specify<A>();
    
    /// <summary>
    /// Specifies an attribution with explicit parameters
    /// </summary>
    /// <typeparam name="A">The attribute type</typeparam>
    /// <param name="parameters">The parameter values</param>
    /// <returns></returns>
    public static AttributionSpec attrib<A>(params AttributeParameterSpec[] parameters)
        where A : Attribute => AttributionSpec.Specify<A>(parameters);

    /// <summary>
    /// Specifies an attribution using named parameters
    /// </summary>
    /// <typeparam name="A">The attribute type</typeparam>
    /// <param name="parameters">The parameter values</param>
    /// <returns></returns>
    public static AttributionSpec attrib<A>(params (string name, object value)[] parameters)
        where A : Attribute => AttributionSpec.Specify<A>(
            arrayi(parameters, 
                (i, p) => new AttributeParameterSpec(p.name, coreval(p.value), i)));

    /// <summary>
    /// Specifies a subclass
    /// </summary>
    /// <typeparam name="t">The base type</typeparam>
    /// <param name="name">The subclass name</param>
    /// <returns></returns>
    public static ClassSpec subclass<t>(ClrClassName name)
        => unwrap(from super in some(ClrClass.Get<t>())
                  let closure = new ClrTypeClosure(super.TypeName)
                  select new ClassSpec(name, BaseTypes: stream(closure)));

    /// <summary>
    /// Specifies a subclass
    /// </summary>
    /// <param name="sub">The subclass name</param>
    /// <param name="super">The superclass name</param>
    /// <returns></returns>
    public static ClassSpec subclass(ClrClassName sub, ClrClassName super)
        => new ClassSpec(sub, BaseTypes: stream(close(super)));

    /// <summary>
    /// Subclasses and closes a generic type
    /// </summary>
    /// <param name="sub">The subclass</param>
    /// <param name="super">The superclass</param>
    /// <param name="typeArgs">The type arguments supplied to the superclass</param>
    /// <returns></returns>
    public static ClassSpec subclose(ClrClassName sub, ClrClassName super, params ClrTypeName[] typeArgs)
        => new ClassSpec(sub, BaseTypes: stream(close(super, typeArgs)));

    /// <summary>
    /// Declares a public read/write auto property 
    /// </summary>
    /// <typeparam name="t">The property type</typeparam>
    /// <param name="declarer">The name of the declaring type</param>
    /// <param name="propName">The property name</param>
    /// <returns></returns>
    public static PropertySpec property<t>(ClrTypeName declarer, ClrPropertyName propName)
        => new AutoPropertySpec(declarer, propName, reference<t>());

    /// <summary>
    /// Declares a public read/write auto property 
    /// </summary>
    /// <param name="declarer">The name of the declaring type</param>
    /// <param name="propName">The property name</param>
    /// <param name="propType">The property type name</param>
    /// <returns></returns>
    public static PropertySpec property(ClrTypeName declarer, ClrPropertyName propName, ClrTypeName propType)
        => new AutoPropertySpec(declarer, propName, reference(propType));

    /// <summary>
    /// Declares a list of public read/write auto properties 
    /// </summary>
    /// <param name="declarer">The name of the declaring type</param>
    /// <param name="props">Tuples specifying the names/types os the properties to declare</param>
    /// <returns></returns>
    public static IReadOnlyList<PropertySpec> properties(ClrTypeName declarer, 
        params (ClrPropertyName propName, ClrTypeName propType)[] props)
            => map(props, p => property(declarer, p.propName, p.propType));

    /// <summary>
    /// Creates a class with properties 
    /// </summary>
    /// <param name="name">The class name</param>
    /// <param name="props">Tuples specifying the names/types os the properties to declare</param>
    /// <returns></returns>
    public static ClassSpec poco(ClrClassName name,
        params (ClrPropertyName propName, ClrTypeName propType)[] props)
        => new ClassSpec(name, Members: properties(name, props));


}