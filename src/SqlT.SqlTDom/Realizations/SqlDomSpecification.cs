//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dom
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;

    using static ClrStructureSpec;    
    using static metacore;

    static class SqlDomSpecification
    {
        static TypeArgument Specify(this ClrTypeArgument arg)
            => new TypeArgument(new TypeParameter($"T{arg.Position}", arg.Position),
                        ClrType.Get(arg.ReflectedElement).TypeName);

        static ClrTypeReference ClosePropertyType(this ClrProperty property)
        {
            var propertyType = property.PropertyType;
            var args = map(propertyType.GenericTypeArguments, arg => Specify(arg)).ToArray();
            var closure = ClrTypeClosure.CloseType(new ClrInterfaceName(propertyType.NonGenericName), args);
            return closure;
        }

        static ClrTypeReference SpecifyPropertyType(this ClrProperty property)
            => property.PropertyType.IsGenericType
            ? ClosePropertyType(property)
            : property.PropertyType.GetReference();

        static PropertySpec SpecifyProperty(this ClrProperty property)
        {
            return new AutoPropertySpec
                (
                    DeclaringTypeName: property.DeclaringType.TypeName,
                    Name: property.Name,
                    IsVirtual: false,
                    IsOverride: false,
                    PropertyType: SpecifyPropertyType(property),
                    AccessLevel: ClrAccessKind.Public,
                    ReadAccessLevel: ClrAccessKind.Public,
                    WriteAccessLevel: property.HasPublicSetter
                        ? ClrAccessKind.Public
                        : ClrAccessKind.Private
                );
        }

        public static NamespaceSpec Include(this ClrNamespaceName ns, IEnumerable<IClrElementSpec> elements)
            => new NamespaceSpec(ns, elements.ToArray());

        public static IEnumerable<PropertySpec> SpecifyProperties(this ClrClass type, bool declaredOnly)
        {
            var props = from p in (declaredOnly ? type.DeclaredPublicInstanceProperties.Stream() : type.PublicInstanceProperties)
                        where not(p.IsOverride)
                        select SpecifyProperty(p);
            return props;
        }

    }


}