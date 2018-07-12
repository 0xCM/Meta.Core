//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Meta.Core;
    using SqlT.Core;

    using static metacore;

    public static class ComponentX
    {

        static SystemIdentifier SystemFromProduct(Assembly a)
            => a.Product().MapValueOrDefault(product =>
            {
                var parts = product.Split('/');
                return parts.Length >= 2
                    ? SystemIdentifier.Parse(parts[1])
                    : SystemIdentifier.Empty;

            }, SystemIdentifier.Empty);


        public static Option<PlatformSystemAttribute> SystemAttribute(this Assembly a)
            => a.TryGetAttribute<PlatformSystemAttribute>();

        public static SystemIdentifier DefiningSystem(this Assembly a)
            => a.SystemAttribute().Map(attrib => SystemIdentifier.Parse(attrib.Classification.ToString()), () => SystemFromProduct(a));

        public static SystemIdentifier DefiningSystem(this ClrAssembly a)
            => a.ReflectedElement.DefiningSystem();

        public static SystemIdentifier DefiningSystem(this Type t)
            => t.Assembly.DefiningSystem();

        public static SystemIdentifier DefiningSystem(this ClrType t)
            => t.ReflectedElement.DefiningSystem();

        static ComponentClassification ClassificationFromProduct(this Assembly a)
            => a.Product().MapValueOrDefault(product =>
            {
                var parts = product.Split('/');
                return parts.Length >= 3
                    ? parseEnum(parts[2], ComponentClassification.None)
                    : ComponentClassification.None;

            }, ComponentClassification.None);

        public static ComponentClassification Classification(this Assembly a)
        {
            var @class = a.Classification();
            return
                @class != ComponentClassification.None
                ? @class
                : (a.IsProxyAssembly() 
                    ? ComponentClassification.DataProxy 
                    : a.ClassificationFromProduct()
                  );
        }

    }
}
