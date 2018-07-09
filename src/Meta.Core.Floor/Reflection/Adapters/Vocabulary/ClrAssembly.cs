//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.ComponentModel;

using Meta.Core;


using static metacore;

/// <summary>
/// Defines a convenience adapter for <see cref="Assembly"/> values
/// </summary>
public sealed class ClrAssembly : ClrElement<Assembly, ClrAssembly>
{
    public static implicit operator Assembly(ClrAssembly a)
        => a.ReflectedElement;

    public static implicit operator ClrAssembly(Assembly a)
        => Get(a);

    /// <summary>
    /// Specifies the 
    /// </summary>
    public static ClrAssembly ExecutingAssembly
        => Get(Assembly.GetExecutingAssembly());

    public static ClrAssembly CallingAssembly
        => Get(Assembly.GetCallingAssembly());

    public static ClrAssembly EntryAssembly
        => Get(Assembly.GetEntryAssembly());

    /// <summary>
    /// Creates a <see cref="ClrAssembly"/> adapter from a loaded assembly
    /// </summary>
    /// <param name="a">The assembly to adapt</param>
    /// <returns></returns>
    public static ClrAssembly Get(Assembly a)
        => new ClrAssembly(a);

    /// <summary>
    /// Attempts to load an assembly from disk
    /// </summary>
    /// <param name="Location">The path to the assembly</param>
    /// <returns></returns>
    public static Option<ClrAssembly> Get(FilePath Location)
        => Try(() => Get(Assembly.LoadFile(Location)));
        
    ClrAssembly(Assembly a)
        : base(a)
    { }

    /// <summary>
    /// Specifies the simple assembly name
    /// </summary>
    public override string Name
        => ReflectedElement.GetSimpleName();

    /// <summary>
    /// Specifies the simple name of the assembly; a (typed) synonym for <see cref="Name"/> property
    /// </summary>
    public ClrSimpleAssemblyName SimpleName
        => ClrSimpleAssemblyName.Parse(Name);

    /// <summary>
    /// Attemps to get the value of a specified attribute
    /// </summary>
    /// <typeparam name="A">The attribute type</typeparam>
    /// <returns></returns>
    public override Option<A> Attribute<A>()
        => ReflectedElement.TryGetAttribute<A>();

    /// <summary>
    /// Gets an attribute attached to the assembly; otherwise, returns null
    /// </summary>
    /// <typeparam name="A">The attribute type</typeparam>
    /// <returns></returns>
    public override A GetCustomAttribute<A>()
        => ReflectedElement.GetCustomAttribute<A>();

    public override bool HasAttribute<A>()
        => ReflectedElement.HasAttribute<A>();

    /// <summary>
    /// Describes the element as specified via an applied <see cref="DescriptionAttribute"/>
    /// </summary>
    public string Description
        => TryGetCustomAttribute<DescriptionAttribute>()
            .MapValueOrDefault(d => d.Description, String.Empty);

    /// <summary>
    /// Specifies the assembly's component identifier
    /// </summary>
    public ComponentIdentifier Identifier
        => Name;

    Seq<ClrType> TypeSeq
        => seq(ReflectedElement.GetTypes().Select(ClrType.Get));

    /// <summary>
    /// Specifies the types defined in the assembly
    /// </summary>
    public IEnumerable<ClrType> Types
        => from t in ReflectedElement.GetTypes()
           select ClrType.Get(t);

    /// <summary>
    /// Specifies the classes defined in the assembly
    /// </summary>
    public Seq<ClrClass> Classes
        => from t in TypeSeq
           where t.IsClassType
           select ClrClass.Get(t);

    /// <summary>
    /// Specifies the nested types defined in the assembly
    /// </summary>
    public Seq<ClrType> InnerTypes
        => from t in TypeSeq
           where t.IsNested
           select t;

    /// <summary>
    /// Specifies the nested classes defined in the assembly
    /// </summary>
    public Seq<ClrClass> InnerClasses
        => from t in InnerTypes
           where t.IsClassType
           select ClrClass.Get(t);

    /// <summary>
    /// Specifies the non-nested types defined in the assembly
    /// </summary>
    public Seq<ClrType> OuterTypes
        => from t in TypeSeq
           where not(t.IsNested)
           select t;

    /// <summary>
    /// Specifies the non-nested classes defined in the assembly
    /// </summary>
    public Seq<ClrClass> OuterClasses
        => from t in OuterTypes
           where t.IsClassType
           select ClrClass.Get(t);

    /// <summary>
    /// Specifies the generic types defiined in the assembly
    /// </summary>
    public Seq<ClrType> GenericTypes
       => from t in TypeSeq
          where t.IsGenericType
          select t;

    /// <summary>
    /// Specifies the non-generic types defiined in the assembly
    /// </summary>
    public IEnumerable<ClrType> NonGenericTypes
       => from t in Types
          where not(t.IsGenericType)
          select t;

    /// <summary>
    /// Specifies the closed generic types defined in the assembly
    /// </summary>
    public Seq<ClrType> ClosedGenericTypes
       => from t in TypeSeq
          where t.IsClosedGenericType
          select t;

    /// <summary>
    /// Specifies the named types defined in the assembly
    /// </summary>
    public Seq<ClrType> NamedTypes
        => seq(ReflectedElement.GetNamedTypes().Select(ClrType.Get));
           

    /// <summary>
    /// Specifies the named public types defined in the assembly
    /// </summary>
    public Seq<ClrType> NamedPublicTypes
        => from t in NamedTypes
           where t.IsPublic
           select t;

    /// <summary>
    /// Specifies the named public static types defined in the assembly
    /// </summary>
    public Seq<ClrType> NamedPublicStaticTypes
        => from t in NamedTypes
           where t.IsPublic && t.IsStaticType
           select t;

    /// <summary>
    /// Specifies the anonymous types defined in the assembly
    /// </summary>
    public IEnumerable<ClrType> AnonymousTypes
        => from t in ReflectedElement.GetAnonymousTypes()
           where t != null
           select ClrType.Get(t);

    /// <summary>
    /// Specifies the public enum types defined in the assembly
    /// </summary>
    public Seq<ClrEnum> PublicEnums
        => from t in NamedPublicTypes
           where t.IsEnumType
           select ClrEnum.Get(t);

    /// <summary>
    /// Specifies the public interfaces defined in the assembly
    /// </summary>
    public Seq<ClrInterface> PublicInterfaces
        => from t in NamedPublicTypes
           where t.IsInterfaceType
           select ClrInterface.Get(t);

    /// <summary>
    /// Specifies the sealed classes defined int in assembly
    /// </summary>
    public Seq<ClrClass> SealedClasses
        => from c in Classes
           where c.IsSealed
           select c;

    /// <summary>
    /// Specifies the non-nested sealed classed defined in the assembly
    /// </summary>
    public Seq<ClrClass> SealedOuterClasses
        => from c in OuterClasses
           where c.IsSealed
           select c;

    /// <summary>
    /// Specifies the non-nested static classes defined in the assembly
    /// </summary>
    public Seq<ClrClass> StaticOuterClasses
        => from c in OuterClasses
           where c.IsStaticType
           select c;

    /// <summary>
    /// Specifies the non-nested public static classes defined in the assembly
    /// </summary>
    public Seq<ClrClass> PublicStaticOuterClasses
        => from c in OuterClasses
           where c.IsStaticType && c.IsPublic
           select c;

    /// <summary>
    /// Specifies the public, non-nested and sealed classes defined in the assembly
    /// </summary>
    public Seq<ClrClass> PublicSealedOuterClasses
        => from c in OuterClasses
           where c.IsSealed && c.IsPublic
           select c;

    /// <summary>
    /// Specifies the named public classes defined by the assembly
    /// </summary>
    public Seq<ClrClass> PublicClasses
        => from t in NamedPublicTypes
           where t.IsClassType
           select ClrClass.Get(t);

    /// <summary>
    /// Specifies the named public structs defined in the assembly
    /// </summary>
    public Seq<ClrStruct> PublicStructs
        => from t in NamedPublicTypes
           where t.IsStructType
           select ClrStruct.Get(t);

    /// <summary>
    /// Specifies the public extension methods defined in the assembly
    /// </summary>
    public Seq<ClrMethod> PublicExtensionMethods
        => from c in PublicStaticOuterClasses
           where not(c.IsGenericType)
           from m in c.DeclaredPublicStaticMethods
           where m.HasAttribute<ExtensionAttribute>()
           select m;

    /// <summary>
    /// Retrieves the implicit and explicit conversion operators defined in the assembly
    /// </summary>
    public IEnumerable<ClrConversionOperator> ConversionOperators
        => from t in Types
           from m in t.DeclaredStaticMethods.OfType<ClrConversionOperator>()
           select m;

    /// <summary>
    /// Specifies the assembly's component classification
    /// </summary>
    public ComponentClassification Classification
         => ReflectedElement.Classification();

    /// <summary>
    /// Specifies the assembly' designator
    /// </summary>
    public Option<IAssemblyDesignator> Designator
        => ReflectedElement.Designator() != null 
        ? some(ReflectedElement.Designator()) 
        : none<IAssemblyDesignator>();

    /// <summary>
    /// Specifies the title of the assembly as provided by the <see cref="AssemblyTitleAttribute"/>
    /// </summary>
    public Option<string> Title
        => ReflectedElement.Title();

    /// <summary>
    /// Specifies the title of the assembly as provided by the <see cref="AssemblyCompanyAttribute"/>
    /// </summary>
    public Option<string> Company
        => ReflectedElement.Company();

    /// <summary>
    /// Specifies the title of the assembly as provided by the <see cref="AssemblyProductAttribute"/>
    /// </summary>
    public Option<string> Product
        => ReflectedElement.Product();

    /// <summary>
    /// Conditionally extracts the text resources defined in the assembly
    /// </summary>
    /// <param name="match">The resource name match pattern</param>
    /// <returns></returns>
    public IEnumerable<TextResource> TextResources(string match)
        => ReflectedElement.GetResourceProvider().TextResources(match);

    /// <summary>
    /// Specifies the area in whic the assembly is defined
    /// </summary>
    public Option<FolderPath> DefiningAreaLocation
        => from d in Designator
           select new FolderPath(CommonFolders.DevAreaRoot + FolderName.Parse(d.Area.Identifier));

    /// <summary>
    /// Returns an associatiave array that pairs types and applied attributes
    /// </summary>
    /// <typeparam name="A">The attribute type</typeparam>
    /// <returns></returns>
    public IDictionary<Type, A> TypeAttributions<A>()
        where A : Attribute
        => ReflectedElement.GetTypeAttributions<A>();

    /// <summary>
    /// Describes the assembly in terms of a <see cref="ComponentDescriptor"/>
    /// </summary>
    /// <returns></returns>
    public Option<ComponentDescriptor> Describe()
        => Try(() => ReflectedElement.ComponentDescriptor());

    /// <summary>
    /// Specifies the assembly's location in the file system
    /// </summary>
    public FilePath Location
        => FilePath.Parse(ReflectedElement.Location);

    /// <summary>
    /// Gets the .net framework version on which the assembly depends
    /// </summary>
    public Version NetFrameworkVersion
        => ReflectedElement.GetNetFrameworkVersion();
}