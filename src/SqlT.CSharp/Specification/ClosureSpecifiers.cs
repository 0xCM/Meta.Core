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
    using SqlT.Syntax;
    using SqlT.SqlSystem;

    using static metacore;
    using static ClrStructureSpec;
    using ClrModel;

    /// <summary>
    /// Defines factory methods for <see cref="ClrTypeClosure"/>
    /// </summary>
    public static partial class SqlProxySpecifier
    {
        static readonly ClrTypeParameterName TParam = "TParam";
        static readonly ClrTypeParameterName TResult = "TResult";

        static readonly ClrClassName SqlProcedureProxyBaseTypeName = nameof(SqlProcedureProxy);
        static readonly ClrClassName SqlTableFunctionProxyBaseTypeName = nameof(SqlTableFunctionProxy);
        static readonly ClrClassName SqlTableProxyBaseTypeName = nameof(SqlTableProxy);
        static readonly ClrClassName SqlTableTypeProxyBaseTypeName = nameof(SqlTableTypeProxy);
        static readonly ClrClassName SqlPrimaryKeyProxyBaseTypeName = nameof(SqlPrimaryKeyProxy);
        static readonly ClrClassName SqlIndexProxyBaseTypeName = nameof(SqlIndexProxy);
        static readonly ClrClassName SqlTabularProxyBaseTypeName = nameof(SqlTabularProxy);
        static readonly ClrClassName SqlViewProxyBaseTypeName = nameof(SqlViewProxy);
        static readonly ClrClassName SqlSequenceProxyBaseTypeName = nameof(SqlSequenceProxy);

        /// <summary>
        /// Specifies the base type for a procedure proxy
        /// </summary>
        /// <param name="subject">The procedure for which a base type will be specified</param>
        /// <param name="gp">The generation profile</param>
        /// <returns></returns>
        public static IEnumerable<ClrTypeClosure> SpecifyBaseTypes(this vProcedure subject, SqlProxyGenerationProfile gp)
            => array(
                    subject.ResultContractName.Map(
                        record => SqlProcedureProxyBaseTypeName.SpecifyTypeClosure(
                                subject.SpecifyClassName().TypeArgument(TParam, 0),
                                record.SpecifyClassName().TypeArgument(TResult, 1)
                                ),
                        () => new ClrTypeClosure(SqlProcedureProxyBaseTypeName)
                ));

        public static IEnumerable<ClrTypeClosure> SpecifyBaseTypes(this vTableFunction subject, SqlProxyGenerationProfile gp)
            => array(SqlTableFunctionProxyBaseTypeName.SpecifyTypeClosure(
                            new TypeArgument("TParam".SpecifyTypeParameter(0), subject.SpecifyClassName()),
                            new TypeArgument("TResult".SpecifyTypeParameter(1), subject.GetResultTypeName(gp))
                            ));

        public static IEnumerable<ClrTypeClosure> SpecifyBaseTypes(this vIndex subject, SqlProxyGenerationProfile gs)
            => array(SqlIndexProxyBaseTypeName.SpecifyTypeClosure
                (new TypeArgument("TTable".SpecifyTypeParameter(), subject.ParentName.SpecifyClassName())));

        public static IEnumerable<ClrTypeClosure> SpecifyBaseTypes(this vPrimaryKey subject, SqlProxyGenerationProfile gs)
            => array(SqlPrimaryKeyProxyBaseTypeName.SpecifyTypeClosure
                (new TypeArgument("TTable".SpecifyTypeParameter(), subject.TableName.SpecifyClassName())));

        public static IEnumerable<ClrTypeClosure> SpecifyResultBaseTypes(this vTableFunction subject, SqlProxyGenerationProfile gs)
            => array(SqlTabularProxyBaseTypeName.SpecifyTypeClosure());

        public static IEnumerable<ClrTypeClosure> SpecifyBaseTypes(this vTable subject, SqlProxyGenerationProfile gs)
            => array(SqlTableProxyBaseTypeName.SpecifyTypeClosure
                    (new TypeArgument("TTable".SpecifyTypeParameter(), subject.TableName.SpecifyClassName())));

        public static IEnumerable<ClrTypeClosure> SpecifyBaseTypes(this vView subject, SqlProxyGenerationProfile gs)
            => array(SqlViewProxyBaseTypeName.SpecifyTypeClosure());

        static IEnumerable<ClrTypeClosure> SpecifyBaseTypes(this vTableType subject, SqlProxyGenerationProfile gs)
            => array(SqlTableTypeProxyBaseTypeName.SpecifyTypeClosure
                    (new TypeArgument("TType".SpecifyTypeParameter(), subject.TypeName.SpecifyClassName())));            
    }

}