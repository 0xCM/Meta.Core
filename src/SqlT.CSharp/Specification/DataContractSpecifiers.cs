//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Syntax;
    using SqlT.Services;
    using SqlT.SqlSystem;

    using static metacore;
    using static ClrStructureSpec;
    using ClrModel;


    partial class SqlProxySpecifier
    {
        public static ClrInterfaceName SpecifyDataContractName(this SqlDataContractProperty property)
            => property.PropertyValue.SpecifyDataContractName();

        public static ClrInterfaceName SpecifyDataContractName(this SqlExternalContractProperty property)
            => property.PropertyValue;

        public static ClrInterfaceName SpecifyDataContractName(this vTableType definingType)
            => new SqlTypeName(definingType.SchemaName, definingType.Name).SpecifyDataContractName();

        public static ClrInterfaceName SpecifyDataContractName(this SqlTypeName definingRecord)
            => new ClrInterfaceName($"I{definingRecord.UnqualifiedName}");

        /// <summary>
        /// Defines data contracts based on the specified table types
        /// </summary>
        /// <param name="definingTypes">The types from which CLR interace types will be defined</param>
        /// <param name="gp">The generation profile</param>
        /// <returns></returns>
        public static IEnumerable<InterfaceSpec> SpecifyDataContracts(this IEnumerable<vTableType> definingTypes,
            SqlProxyGenerationProfile gp)
        {
            foreach (var gSchema in definingTypes.GroupBy(x => x.SchemaName))
            {
                var schemaName = gSchema.Key;
                var schemaSelection = gp.Schemas.Single(s => s.SchemaName == schemaName);
                foreach (var definingType in definingTypes)
                {
                    var contractName = definingType.SpecifyDataContractName();
                    var properties = new List<PropertySpec>();

                    iteri(definingType.Columns, 
                            (i, c) => properties.Add(c.SpecifyProperty(definingType.SpecifyDataContractName(), i, gp)));
                    
                    yield return new InterfaceSpec
                    (
                        Name: contractName,
                        AccessLevel: gp.Internalize
                          ? ClrAccessKind.Internal
                          : ClrAccessKind.Public,
                        IsPartial: true,
                        Members: properties,
                        Documentation: new ElementDescription($"Declares the columns defined by the {schemaName} schema"),
                        Attributions: array(new AttributionSpec(nameof(SqlDataContractAttribute)))
                    );
                }
            }
        }

        public static IEnumerable<ClrInterfaceName> SpecifyDataContractConformance(this vTableType subject, SqlProxyGenerationProfile gp)
        {
            var property = subject.DataContract();
            if (property)
                yield return property.MapValueOrDefault(x => x.SpecifyDataContractName());

            //Conformance to self
            if (gp.EmitTypeContracts)
                yield return subject.SpecifyDataContractName();

            var ec = subject.ExternalContract();
            if (ec)
                yield return ec.MapValueOrDefault(x => x.SpecifyDataContractName());
        }

        public static IEnumerable<ClrInterfaceName> SpecifyDataContractConformance(this vTable subject, SqlProxyGenerationProfile gp)
        {

            var property = subject.DataContract();
            if (property)
                yield return property.MapValueOrDefault(x => x.SpecifyDataContractName());

            var ec = subject.ExternalContract();
            if (ec)
                yield return ec.MapValueOrDefault(x => x.SpecifyDataContractName());

            foreach (var idc in subject.GetImplicitDataContracts(gp))
                yield return idc;

        }

        public static IEnumerable<ClrInterfaceName> SpecifyDataContractConformance(this vProcedure subject, SqlProxyGenerationProfile gp)
        {

            var property = subject.DataContract();
            if (property)
                yield return property.MapValueOrDefault(x => x.SpecifyDataContractName());

            var ec = subject.ExternalContract();
            if (ec)
                yield return ec.MapValueOrDefault(x => x.SpecifyDataContractName());
        }

        public static IEnumerable<ClrInterfaceName> SpecifyDataContractConformance(this vTableFunction subject, SqlProxyGenerationProfile gp)
        {

            var property = subject.DataContract();
            if (property)
                yield return property.MapValueOrDefault(x => x.SpecifyDataContractName());

            var ec = subject.ExternalContract();
            if (ec)
                yield return ec.MapValueOrDefault(x => x.SpecifyDataContractName());
        }

        public static IEnumerable<ClrInterfaceName> SpecifyDataContractConformance(this vView subject, SqlProxyGenerationProfile gp)
        {
            var dc = subject.DataContract();
            if (dc)
                yield return dc.MapValueOrDefault(x => x.SpecifyDataContractName());

            var ec = subject.ExternalContract();
            if (ec)
                yield return ec.MapValueOrDefault(x => x.SpecifyDataContractName());
        }


    }
}