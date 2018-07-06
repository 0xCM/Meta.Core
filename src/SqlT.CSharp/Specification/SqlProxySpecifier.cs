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
    using SqlT.SqlSystem;
    

    using static metacore;
    using static ClrStructureSpec;
    using ClrModel;
   
    public static partial class SqlProxySpecifier
    {
        public static ClrType SpecifyProxyType(this vSystemPrimitive subject, CodeGenerationProfile gp)
            => (from primitive in SqlNativeTypes.TryFind(p => string.Equals(p.Name.UnquotedLocalName,
                subject.TypeName.UnqualifiedName, StringComparison.InvariantCultureIgnoreCase))
                from clrType in primitive.MapToClrType()
                select clrType).Require($"The primitive type {subject.TypeName} could not be found among the known intrinsic primitives");


        public static ClrClassName GetResultTypeName(this vTableFunction subject, CodeGenerationProfile gp)
            => subject.ResultContractName.Map(c => c.SpecifyClassName(),
                    () => new ClrClassName(subject.ObjectName.SpecifyClassName().SimpleName + "Result"));

        public static IEnumerable<IClrMemberSpec> SpecifyProxyMembers(this vPrimaryKey subject, SqlProxyGenerationProfile gp)
            => stream( subject.KeyColumns.SpecifyProperties(subject.SpecifyClassName(), gp),
                    subject.SpecifyCustomMethods(gp),
                    subject.SpecifyConstructors(gp));

        public static IEnumerable<IClrMemberSpec> SpecifyProxyMembers(this vIndex subject, SqlProxyGenerationProfile gp)
            => stream( subject.PrimaryColumns.SpecifyProperties(subject.SpecifyClassName(), gp),
                    subject.SpecifyCustomMethods(gp),
                    subject.SpecifyConstructors(gp)
                    );

        /// <summary>
        /// Specifies the access of a type accoring to the supplied profile
        /// </summary>
        /// <param name="subject">The type for which access will be specified</param>
        /// <param name="gp">The generation profile</param>
        /// <returns></returns>
        public static ClrAccessKind SpecifyTypeAccess(this vSystemElement subject, SqlProxyGenerationProfile gp)
            => gp.Internalize 
            ? ClrAccessKind.Internal 
            : ClrAccessKind.Public;


        static IEnumerable<IClrMemberSpec> SpecifyInvocationMembers(this vProcedure subject, SqlProxyGenerationProfile gp)
        {
            foreach (var p in subject.Parameters.SpecifyProperties(subject.SpecifyClassName(), gp))
                yield return p;

            if (subject.Parameters.Count != 0)
            {
                foreach (var m in subject.SpecifyCustomMethods(gp))
                    yield return m;
            }

            foreach (var c in subject.SpecifyConstructors(gp))
                yield return c;

        }

        /// <summary>
        /// Specifies proxies for a stored procedure
        /// </summary>
        /// <param name="subject">The table whose proxies will be specified</param>
        /// <param name="gp">The generation profile</param>
        /// <returns></returns>
        public static IEnumerable<ClassSpec> SpecifyProxies(this vProcedure subject, SqlProxyGenerationProfile gp)
            => array(new ClassSpec
            (
                Name: subject.SpecifyClassName(),
                AccessLevel: gp.Internalize ? ClrAccessKind.Internal : ClrAccessKind.Public,
                Documentation: new ElementDescription(subject.Documentation),
                Members: subject.SpecifyInvocationMembers(gp),
                //Members: union(
                //    subject.Parameters.SpecifyProperties(subject.SpecifyClassName(), gp),
                //    subject.Parameters.Count != 0 ? subject.SpecifyCustomMethods(gp) : array<IClrMemberSpec>(),
                //    subject.SpecifyConstructors(gp)
                //    ),
                Attributions: subject.SpecifyAttributions(),
                BaseTypes: subject.SpecifyBaseTypes(gp),
                ImplicitRealizations: subject.SpecifyDataContractConformance(gp),
                IsPartial: true
            ));


        static IEnumerable<IClrMemberSpec> SpecifyInvocationMembers(this vTableFunction subject, SqlProxyGenerationProfile gp)
        {
            foreach (var p in map(subject.Parameters, p => p.SpecifyProperty(subject.SpecifyClassName(), gp)))
                yield return p;

            if (subject.Parameters.Count != 0)
            {
                foreach (var m in subject.SpecifyCustomMethods(gp))
                    yield return m;
            }

            foreach (var c in subject.SpecifyConstructors(gp))
                yield return c;

        }

        static IEnumerable<IClrMemberSpec> SpecifyResultMembers(this vTableFunction subject, SqlProxyGenerationProfile gp)
        {
            foreach (var p in mapi(subject.Columns, (i, c) => c.SpecifyProperty(subject.GetResultTypeName(gp), i, gp)))
                yield return p;

            foreach (var m in subject.SpecifyCustomMethods(gp))
                yield return m;

            foreach (var c in subject.SpecifyResultConstructors(gp))
                yield return c;

        }


        /// <summary>
        /// Specifies a table function proxy
        /// </summary>
        /// <param name="subject">The table function for which a proxy will be specified</param>
        /// <param name="gp">The generation profile</param>
        /// <returns></returns>
        public static IEnumerable<ClassSpec> SpecifyProxies(this vTableFunction subject, SqlProxyGenerationProfile gp)
        {
            var typeName = subject.SpecifyClassName();
            yield return new ClassSpec
            (
                Name: typeName,
                AccessLevel: gp.Internalize ? ClrAccessKind.Internal : ClrAccessKind.Public,
                Documentation: new ElementDescription(subject.Documentation),
                Members: subject.SpecifyInvocationMembers(gp),
                //Members: union(
                //    map(subject.Parameters, p => p.SpecifyProperty(typeName, gp)),
                //    subject.Parameters.Count != 0 ? subject.SpecifyCustomMethods(gp) : array<IClrMemberSpec>(),
                //    subject.SpecifyConstructors(gp)
                //    ),
                Attributions: subject.SpecifyAttributions(),
                BaseTypes: subject.SpecifyBaseTypes(gp),
                ImplicitRealizations: subject.SpecifyDataContractConformance(gp),
                IsPartial: true
            );

            if(!subject.ResultContractName)
            {
                var resultTypeName = subject.GetResultTypeName(gp);
                yield return new ClassSpec
                (
                    Name: resultTypeName,
                    AccessLevel: gp.Internalize ? ClrAccessKind.Internal : ClrAccessKind.Public,
                    Members: subject.SpecifyResultMembers(gp),
                    //Members: union(
                    //    mapi(subject.Columns, (i,c) => c.SpecifyProperty(resultTypeName, i, gp)), 
                    //    subject.SpecifyCustomMethods(gp),
                    //    subject.SpecifyResultConstructors(gp)
                    //    ),
                    Attributions: subject.SpecifyResultAttributions(gp),
                    BaseTypes: subject.SpecifyResultBaseTypes(gp),
                    IsPartial: true
                );
            }
        }

        /// <summary>
        /// Specifies a primary key proxy
        /// </summary>
        /// <param name="subject">The primary key for which a proxy will be specified</param>
        /// <param name="gp">The generation profile</param>
        /// <returns></returns>
        public static IEnumerable<ClassSpec> SpecifyProxies(this vPrimaryKey subject, SqlProxyGenerationProfile gp)
        {
            var name = subject.SpecifyClassName();
            var docs = new ElementDescription(subject.Documentation);
            var attributions = rolist(subject.SpecifyAttributions());
            var baseTypes = rolist(subject.SpecifyBaseTypes(gp));
            var spec = new ClassSpec
            (
                Name: name,
                AccessLevel: subject.SpecifyTypeAccess(gp),
                Documentation: docs,
                Members: subject.SpecifyProxyMembers(gp),
                Attributions: attributions,
                BaseTypes: baseTypes,
                IsPartial: true
            );
            return array(spec);
        }

        /// <summary>
        /// Specifies an index proxy
        /// </summary>
        /// <param name="subject">The index for which a proxy will be specified</param>
        /// <param name="gp">The generation profile</param>
        /// <returns></returns>
        public static IEnumerable<ClassSpec> SpecifyProxies(this vIndex subject, SqlProxyGenerationProfile gp)
        {
            var name = subject.SpecifyClassName();
            var docs = new ElementDescription(subject.Documentation);
            var attributions = rolist(subject.SpecifyAttributions());
            var baseTypes = rolist(subject.SpecifyBaseTypes(gp));
            var spec = new ClassSpec
            (
                Name: name,
                AccessLevel: subject.SpecifyTypeAccess(gp),
                Documentation: docs,
                Members: subject.SpecifyProxyMembers(gp),
                Attributions: attributions,
                BaseTypes: baseTypes,
                IsPartial: true
            );
            return array(spec);
        }

        static IEnumerable<IClrMemberSpec> SpecifyMembers(this vView subject, SqlProxyGenerationProfile gp)
        {
            foreach (var p in subject.Columns.SpecifyProperties(subject.SpecifyClassName(), gp))
                yield return p;

            foreach (var m in subject.SpecifyCustomMethods(gp))
                yield return m;

            foreach (var c in subject.SpecifyConstructors(gp))
                yield return c;

        }


        /// <summary>
        /// Specifies a view proxy
        /// </summary>
        /// <param name="subject">The view for which a proxy will be specified</param>
        /// <param name="gp">The generation profile</param>
        /// <returns></returns>
        public static IEnumerable<ClassSpec> SpecifyProxies(this vView subject, SqlProxyGenerationProfile gp)
            => array(new ClassSpec
            (
                Name: subject.SpecifyClassName(),
                AccessLevel: gp.Internalize ? ClrAccessKind.Internal : ClrAccessKind.Public,
                Documentation: new ElementDescription(subject.Documentation),
                Members: subject.SpecifyMembers(gp),
                Attributions: subject.SpecifyAttributions(),
                BaseTypes: subject.SpecifyBaseTypes(gp),
                ImplicitRealizations: subject.SpecifyDataContractConformance(gp),
                IsPartial: true
            ));

        static IEnumerable<IClrMemberSpec> SpecifyMembers(this vTableType subject, SqlProxyGenerationProfile gp)
        {
            foreach (var p in subject.Columns.SpecifyProperties(subject.SpecifyClassName(), gp))
                yield return p;

            foreach (var m in subject.SpecifyCustomMethods(gp))
                yield return m;

            foreach (var c in subject.SpecifyConstructors(gp))
                yield return c;

        }


        /// <summary>
        /// Specifies a table type proxy
        /// </summary>
        /// <param name="subject">The table type for which a proxy will be specified</param>
        /// <param name="gp">The generation profile</param>
        /// <returns></returns>
        public static IEnumerable<ClassSpec> SpecifyProxies(this vTableType subject, SqlProxyGenerationProfile gp)
            => array(new ClassSpec
            (
                Name: subject.SpecifyClassName(),
                AccessLevel: gp.Internalize ? ClrAccessKind.Internal : ClrAccessKind.Public,
                Documentation: new ElementDescription(subject.Documentation),
                Members: subject.SpecifyMembers(gp),
                Attributions: subject.SpecifyAttributions(),
                BaseTypes: subject.SpecifyBaseTypes(gp),
                ImplicitRealizations: subject.SpecifyDataContractConformance(gp),
                IsPartial: true
            ));

        static IEnumerable<IClrMemberSpec> SpecifyMembers(this vTable subject, SqlProxyGenerationProfile gp)
        {
            foreach (var p in subject.Columns.SpecifyProperties(subject.SpecifyClassName(), gp))
                yield return p;

            foreach (var m in subject.SpecifyCustomMethods(gp))
                yield return m;

            foreach (var c in subject.SpecifyConstructors(gp))
                yield return c;

        }

        /// <summary>
        /// Specifies a table proxy
        /// </summary>
        /// <param name="subject">The table for which a proxy will be specified</param>
        /// <param name="gp">The generation profile</param>
        /// <returns></returns>
        public static IEnumerable<ClassSpec> SpecifyProxies(this vTable subject, SqlProxyGenerationProfile gp)
            => array(new ClassSpec
            (
                Name: subject.SpecifyClassName(),
                AccessLevel: gp.Internalize ? ClrAccessKind.Internal : ClrAccessKind.Public,
                Documentation: new ElementDescription(subject.Documentation),
                Members: subject.SpecifyMembers(gp),
                Attributions: subject.SpecifyAttributions(),
                BaseTypes: subject.SpecifyBaseTypes(gp),
                ImplicitRealizations : subject.SpecifyDataContractConformance(gp),
                IsPartial: true
            ));

        public static IEnumerable<IClrTypeSpec> SpecifyProxyTypes(this vSystemElement subject, SqlProxyGenerationProfile gp)
        {
            foreach(var x in  SpecifyProxies((dynamic)subject, gp))
                yield return x;
        }

        public static ClrAccessKind SpecifyEffectiveAccessLevel(this SqlProxyGenerationProfile gp)
            => gp.Internalize  ? ClrAccessKind.Internal  : ClrAccessKind.Public;
    }
}
