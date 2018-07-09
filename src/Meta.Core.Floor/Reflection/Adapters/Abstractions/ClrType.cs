//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ComponentModel;

using static metacore;


using static CommonBindingFlags;
using static MemberInstanceType;

using Meta.Core;

public abstract class ClrType : ClrElement<Type, ClrType>
{
    sealed class ClrVoid{ClrVoid() { } }

    public static ClrType Void = Get<ClrVoid>();

    public static ClrType Get(Type t)
    {

        if (t == null)
            throw new ArgumentNullException();

        if (t.IsClass)
            return new ClrClass(t);
        else if (t.IsEnum)
            return new ClrEnum(t);
        else if (t.IsStruct())
            return new ClrStruct(t);
        else if (t.IsInterface)
            return new ClrInterface(t);
        else if (t.IsDelegate())
            return new ClrDelegate(t);

        throw new NotSupportedException($"No adapter has been defined for {t}");        
    }

    public static ClrType Get<T>()
        => Get(typeof(T));

    /// <summary>
    /// Defines a type reference
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static ClrTypeReference Reference<T>()
        => Get<T>().GetReference();

    /// <summary>
    /// Implicitly converts the adapter to its underlying adapted type
    /// </summary>
    /// <param name="x"></param>
    public static implicit operator Type(ClrType x)
        => x.ReflectedElement;

    protected ClrType(Type ReflectedElement)
        : base(ReflectedElement)
    { }

    /// <summary>
    /// Specifies whether the adapted type is a nullable type
    /// </summary>
    public bool IsNullableType
        => ReflectedElement.IsNullableType();

    /// <summary>
    /// Specifies whether the adapted type is a nested type
    /// </summary>
    public bool IsNested
        => ReflectedElement.IsNested;

    /// <summary>
    /// Specifies whether the adapted type is a value type
    /// </summary>
    public bool IsValueType
        => ReflectedElement.IsValueType;

    /// <summary>
    /// Specifies whether the adapted type is a numeric type
    /// </summary>
    public bool IsNumericType
        => ReflectedElement.IsNumber();

    /// <summary>
    /// Specifies whether the adapted type is a delegate type
    /// </summary>
    public bool IsDelegateType
        => ReflectedElement.IsDelegate();

    /// <summary>
    /// Specifies whether the adapted type is an enum type
    /// </summary>
    public bool IsEnumType
        => ReflectedElement.IsEnum;

    /// <summary>
    /// Specifies whether the adapted type is an interface type
    /// </summary>
    public bool IsInterfaceType
        => ReflectedElement.IsInterface;

    /// <summary>
    /// Specifies whether the adapted type is a class type
    /// </summary>
    public bool IsClassType
        => ReflectedElement.IsClass;

    public bool HasDefaultPublicConstructor
        => ReflectedElement.HasDefaultPublicConstructor();

    public bool IsAbstract
        => ReflectedElement.IsAbstract;

    public bool IsArray
        => ReflectedElement.IsArray;

    public bool IsAnonymous
        => ReflectedElement.IsAnonymous();

    public bool IsPublic
        => ReflectedElement.IsPublic;

    public bool IsPrimitive
        => ReflectedElement.IsPrimitive;

    /// <summary>
    /// Specifies whether the type is sealed
    /// </summary>
    public bool IsSealed
        => ReflectedElement.IsSealed;

    /// <summary>
    /// Specifies whether the type is serializable
    /// </summary>
    public bool IsSerializable
        => ReflectedElement.IsSerializable;

    /// <summary>
    /// Specifies whether the metadata of the adapted type has the 'special name' flag set
    /// </summary>
    public bool IsSpecialName
        => ReflectedElement.IsSpecialName;

    public bool IsExternallyVisible
        => ReflectedElement.IsVisible;

    public Option<ClrNamespaceName> Namespace
        => isBlank(ReflectedElement.Namespace)
        ? none<ClrNamespaceName>()
        : new ClrNamespaceName(ReflectedElement.Namespace);

    public override A GetCustomAttribute<A>()
        => ReflectedElement.GetCustomAttribute<A>();

    public override Option<A> Attribute<A>()
        => ReflectedElement.GetCustomAttribute<A>();

    public override bool HasAttribute<A>()
        => System.Attribute.IsDefined(ReflectedElement, typeof(A));

    /// <summary>
    /// Determines whether the adapted type is of type <see cref="Nullable{T}"/>
    /// </summary>
    /// <typeparam name="T">The type to test</typeparam>
    /// <returns></returns>
    public bool IsNullableTypeOf<T>()
        => ReflectedElement.IsNullableType<T>();

    /// <summary>
    /// Determines whether the adapted type is of type <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T">The type to test</typeparam>
    /// <returns></returns>
    public bool IsTypeOf<T>()
        => ReflectedElement == typeof(T);

    /// <summary>
    /// Determines whether the adapted type is of the type <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T">The type to test</typeparam>
    /// <returns></returns>
    public bool IsSubclassOf<T>()
        => ReflectedElement.IsSubclassOf(typeof(T));

    /// <summary>
    /// Determines whether a type is a subclass of the adapted type
    /// </summary>
    /// <param name="t">The type to test</param>
    /// <returns></returns>
    public bool IsSubclassOf(ClrType t)
        => ReflectedElement.IsSubclassOf(t);

    /// <summary>
    /// Determines whether a type is a subclass of the adapted type
    /// </summary>
    /// <param name="t">The type to test</param>
    /// <returns></returns>
    public bool IsSubclassOf(Type t)
        => ReflectedElement.IsSubclassOf(t);

    /// <summary>
    /// Determines whether the adapted type conforms to a specified interface
    /// </summary>
    /// <param name="i">The interface to test</param>
    /// <returns></returns>
    public bool Realizes(ClrInterface i)
        => ReflectedElement.Realizes(i.ReflectedElement);

    /// <summary>
    /// Determines whether the adapted type conforms to an interface <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T">The interface type to test</typeparam>
    /// <returns></returns>
    public bool Realizes<T>()
        => ReflectedElement.Realizes<T>();

    /// <summary>
    /// Specifies whether the adapted type is a struct
    /// </summary>
    public bool IsStructType
        => ReflectedElement.IsStruct();

    /// <summary>
    /// Specifies whether the adapted type is static
    /// </summary>
    public bool IsStaticType
        => ReflectedElement.IsStatic();

    /// <summary>
    /// Specifies whether the type is an <see cref="Option{T}"/> closure
    /// </summary>
    public bool IsOptionType
        => ReflectedElement.IsOption();

    /// <summary>
    /// Specifies the type's inheritance chain up to, but not including, <see cref="object"/>
    /// </summary>
    public Seq<ClrType> BaseTypes
        => from x in seq(ReflectedElement.BaseTypes())
           where x != null
           select Get(x);

    public ClrType UnderlyingSystemType
        => Get(ReflectedElement.UnderlyingSystemType);

    public ClrTypeLineage TypeLineage
        => array(this, BaseTypes.AsArray());

    /// <summary>
    /// Specifies the static properties exposed by the adapted type
    /// </summary>
    public Seq<ClrProperty> StaticProperties
        => seq(ReflectedElement.GetStaticProperties()).Select(ClrProperty.Get);
           

    /// <summary>
    /// Specifies the static properties declared by the adapted type
    /// </summary>
    public Seq<ClrProperty> DeclaredStaticProperties
        => seq(ReflectedElement.GetProperties(BF_DeclaredStatic)).Select(ClrProperty.Get);

    /// <summary>
    /// Specifies the static methods declared by the adapted type
    /// </summary>
    public Seq<ClrMethod> DeclaredStaticMethods
        => seq(ReflectedElement.GetMethods(BF_DeclaredStatic)).Select(ClrMethod.Get);
           
    /// <summary>
    /// Specifies the instance methods declared by the adapted type
    /// </summary>
    public Seq<ClrMethod> DeclaredInstanceMethods
        => seq(ReflectedElement.GetMethods(BF_DeclaredInstance)).Select(ClrMethod.Get);
           
    /// <summary>
    /// Specifies all methods declared by the adapted type
    /// </summary>
    public Seq<ClrMethod> DeclaredMethods
        => DeclaredStaticMethods + DeclaredInstanceMethods;

    public Seq<ClrMethod> DeclaredInstanceGenericMethods
        => from x in DeclaredInstanceMethods
           where x.IsGeneric
           select x;

    /// <summary>
    /// Specifies the static generic methods declared by the type
    /// </summary>
    public Seq<ClrMethod> DeclaredStaticGenericMethods
        => from x in DeclaredStaticMethods
           where x.IsGeneric
           select x;

    /// <summary>
    /// Specifies all public fields exposed by the type
    /// </summary>
    public IEnumerable<ClrField> PublicFields
        => from x in ReflectedElement.GetPublicFields()
           select ClrField.Get(x);

    /// <summary>
    /// Specifies the public fields declared by the type
    /// </summary>
    public IEnumerable<ClrField> DeclaredPublicFields
        => from x in ReflectedElement.GetDeclaredPublicFields()
           select ClrField.Get(x);

    /// <summary>
    /// Specifies the public static instance declared by the type
    /// </summary>
    public Seq<ClrMethod> DeclaredPublicInstanceMethods
        => seq(ReflectedElement.GetDeclaredPublicMethods(Instance).Select(ClrMethod.Get));           

    /// <summary>
    /// Specifies the public static methods declared by the type
    /// </summary>
    public Seq<ClrMethod> DeclaredPublicStaticMethods
        => seq(ReflectedElement.GetDeclaredPublicMethods(Static).Select(ClrMethod.Get));

    /// <summary>
    /// Specifies the public static methods declared by the type
    /// </summary>
    public Seq<ClrMethod> DeclaredNonPublicStaticMethods
        => seq(ReflectedElement.GetDeclaredNonPublicMethods(Static).Select(ClrMethod.Get));           

    /// <summary>
    /// Specifies all static or instance methods declared by the type
    /// </summary>
    public Seq<ClrMethod> DeclaredPublicMethods
        => DeclaredPublicInstanceMethods + DeclaredPublicStaticMethods;

    /// <summary>
    /// Specifies the non-public instance properties declared by the type
    /// </summary>
    public Seq<ClrProperty> DeclaredNonPublicInstanceProperties
        => seq(ReflectedElement.GetDeclaredNonPublicProperties(Instance).Select(ClrProperty.Get));
               
    /// <summary>
    /// Specifies the non-public static properties declared by the type
    /// </summary>
    public Seq<ClrProperty> DeclaredNonPublicStaticProperties
        => seq(ReflectedElement.GetDeclaredNonPublicProperties(Static).Select(ClrProperty.Get));

    /// <summary>
    /// Specifies the public instance properties declared by the type
    /// </summary>
    public Seq<ClrProperty> DeclaredPublicInstanceProperties
        => seq(ReflectedElement.GetDeclaredPublicProperties(Instance).Select(ClrProperty.Get));
           

    /// <summary>
    /// Specifies the public static properties declared by the type
    /// </summary>
    public IEnumerable<ClrProperty> DeclaredPublicStaticProperties
        => from x in ReflectedElement.GetDeclaredPublicProperties(Static)
           select ClrProperty.Get(x);

    /// <summary>
    /// Specifies all public instance properties exposed by the adapted type
    /// </summary>
    public IEnumerable<ClrProperty> PublicInstanceProperties
        => from x in ReflectedElement.GetPublicInstanceProperties()
           select ClrProperty.Get(x);

    /// <summary>
    /// Specifies all public instance methods exposed by the adapted type
    /// </summary>
    public Seq<ClrMethod> PublicInstanceMethods
        => seq(ReflectedElement.GetPublicMethods(Instance).Select(ClrMethod.Get));
           

    /// <summary>
    /// Specifies the instance properties exposed by the adapted type
    /// </summary>
    public Seq<ClrProperty> InstanceProperties
        => seq(ReflectedElement.GetProperties(BF_Instance).Select(ClrProperty.Get));
           
    /// <summary>
    /// Specifies the public properties that have been inherited by the type
    /// </summary>
    public Seq<ClrProperty> InheritedPublicProperties
        => seq(ReflectedElement.GetInheritedPublicProperties().Select(ClrProperty.Get));

    /// <summary>
    /// Specifies the public methods that have been inherited by the type
    /// </summary>
    public Seq<ClrMethod> InheritedPublicMethods
        => from m in  seq(ReflectedElement.GetInheritedPublicMethods(Static)) 
                    + seq(ReflectedElement.GetInheritedPublicMethods(Instance))
           select ClrMethod.Get(m);
            
    /// <summary>
    /// Specifies all static or instance public methods declared or inherited by the type
    /// </summary>
    public Seq<ClrMethod> PublicMethods
        => DeclaredPublicMethods + InheritedPublicMethods;
           
    //See https://msdn.microsoft.com/en-us/library/system.type.isgenerictype(v=vs.110).aspx 

    /// <summary>
    /// Specifies whether the type is one of:
    /// 1. A closed generic type
    /// 2. A partially closed generic type
    /// 3. A generic type definition
    /// </summary>
    public bool IsGenericType
        => ReflectedElement.IsGenericType;

    /// <summary>
    /// Specifies whether the adapted type iteself is a generic parameter
    /// </summary>
    public bool IsGenericParameter
        => ReflectedElement.IsGenericParameter;

    /// <summary>
    /// Specifies whether the adapted type contains generic parameters, which will
    /// be true if the type is a generic type that is either partially closed 
    /// or a generic type definition
    /// </summary>
    public bool ContainsGenericParameters
        => ReflectedElement.ContainsGenericParameters;

    /// <summary>
    /// Specifies the explicit conversion operators declared by the type
    /// </summary>
    public IEnumerable<ClrExplicitConverter> DeclaredExplicitConverters
        => DeclaredStaticMethods.OfType<ClrExplicitConverter>();
           
    /// <summary>
    /// Specifies the explicit conversion operators declared by the type
    /// </summary>
    public IEnumerable<ClrImplictConverter> DeclaredImplicitConverters
        => DeclaredStaticMethods.OfType<ClrImplictConverter>();

    /// <summary>
    /// Specifies the conversion operators declared by the type
    /// </summary>
    public IEnumerable<ClrConversionOperator> DeclaredConversionOperators
        => DeclaredExplicitConverters.Concat<ClrConversionOperator>(DeclaredImplicitConverters);

    public bool IsGenericTypeParameter
        => IsGenericParameter && ContainsGenericParameters;

    public bool IsClosedGenericType
        => IsGenericType && not(ContainsGenericParameters);

    public bool IsPartiallyClosedGenericType
        => IsGenericType && ContainsGenericParameters;

    public bool IsOpenGenericType
        => not(IsClosedGenericType);

    public bool IsGenericTypeDefinition
        => ReflectedElement.IsGenericTypeDefinition;

    public IEnumerable<ClrTypeArgument> GenericTypeArguments
        => mapi(ReflectedElement.GetGenericArguments(), (i, argType)
           => ClrTypeArgument.Get(argType, i));

    public Option<ClrType> GenericTypeDefinition
        => IsGenericTypeDefinition 
        ? Get(ReflectedElement.GetGenericTypeDefinition())
        : null;

    public bool IsEnumerableType
        => ReflectedElement.Realizes<IEnumerable>();

    public bool IsListType
        => ReflectedElement.Realizes<IList>();

    public bool IsGenericEnumerableType
        => IsGenericType && IsEnumerableType;

    public bool IsGenericListType
        => IsListType && IsGenericType;
        
    /// <summary>
    /// Specifies the interfaces supported by the type
    /// </summary>
    public IEnumerable<ClrInterface> RealizedInterfaces
        => from x in ReflectedElement.GetInterfaces()
           select ClrInterface.Get(x);

    /// <summary>
    /// Specifies the type's description as provided by an application of the <see cref="DescriptionAttribute"/>,
    /// otherwise emtpy
    /// </summary>
    public string Description
        => TryGetCustomAttribute<DescriptionAttribute>().MapValueOrDefault(a => a.Description) ?? string.Empty;

    /// <summary>
    /// Specifies the type's base type, if any
    /// </summary>
    public Option<ClrType> BaseType
        => Get(ReflectedElement.BaseType);

    public bool IsSystemObjectType
        => this.ReflectedElement == typeof(object);

    public TypeCode TypeCode
        => Type.GetTypeCode(this.ReflectedElement);

    public override sealed string Name
        => TypeName.SimpleName;

    public abstract IClrTypeName TypeName { get; }

    public bool IsVoid
        => this.Equals(Void);


    public ClrAccessKind AccessLevel
    {
       get
        {
            if (ReflectedElement.IsPublic || ReflectedElement.IsNestedPublic)
                return ClrAccessKind.Public;
            else if (ReflectedElement.IsNestedPrivate)
                return ClrAccessKind.Private;
            else if (ReflectedElement.IsNestedFamORAssem)
                return ClrAccessKind.ProtectedOrInternal;
            else if (ReflectedElement.IsNestedFamANDAssem)
                return ClrAccessKind.ProtectedAndInternal;
            else if (ReflectedElement.IsNestedFamily)
                return ClrAccessKind.Protected;
            else 
                return ClrAccessKind.Internal;
        }
    }

    /// <summary>
    /// Specifies the nested classes declared by the adapted type, if any
    /// </summary>
    public IEnumerable<ClrClass> NestedClasses
        => from t in ReflectedElement.GetNestedTypes(BF_PublicNonPublic | BF_InstanceStatic)
           where t.IsClass
           select ClrClass.Get(t);
           
    /// <summary>
    /// Defines a reference to the adapted type
    /// </summary>
    /// <returns></returns>
    public abstract ClrTypeReference GetReference();

    public Option<CoreDataType> CoreType
        => ReflectedElement.ToCoreType();


    public bool IsDeclaredIn(ClrNamespaceName ns)
        => Namespace.MapValueOrDefault(x => x.ToString(),string.Empty) == ns.ToString();

    /// <summary>
    /// Returns the canonical parse method for a type if it exists
    /// </summary>
    public Option<ClrMethod> ParseMethod
        => (from m in DeclaredStaticMethods
            where m.Name == "Parse"
               && m.ReflectedElement.ReturnType == ReflectedElement
               && m.Parameters.Count() != 0
            let firstParam = m.Parameters.First()
            where firstParam.ParameterType.ReflectedElement == typeof(string)
            select m).FirstOrDefault();

    public string FormattedName
        => ReflectedElement.DisplayName();

    /// <summary>
    /// Returns the name of the type without generic/arity annoations
    /// </summary>
    public string NonGenericName
    {
        get
        {
            if(IsClosedGenericType)
            {
                var idx = this.Name.TryGetLastIndexOf('`');
                var simpleName = Name.Substring(0, idx.ValueOrDefault(Name.Length));
                return simpleName;
            }
            return this.Name;
        }
    }

    public override string ToString()
        => FormattedName;

}
