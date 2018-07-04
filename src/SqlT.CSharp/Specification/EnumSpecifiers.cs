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

        static ISqlClientBroker SourceBroker(this SqlProxyGenerationProfile gp)
            => SqlConnectionString.Parse(gp.ConnectionString).GetClientBroker();

        static IReadOnlyList<SqlColumnName> EnumSourceColumns
            = roitems<SqlColumnName>("TypeCode", "Identifier", "Label", "Description");

        static IEnumerable<EnumLiteralSpec> SpecifyEnumLiterals(ClrEnumName EnumName, SqlDataFrame DataSource, SqlProxyGenerationProfile gp)
            => from row in DataSource.Rows
               let code = CoreDataValue.FromObject(row[0])
               where code.IsSome()
               let literalName = row[1] as string
               let label = row[2]
               let desc = isBlank(row[3] as string) ? null : new ElementDescription(row[3] as string)

               select new EnumLiteralSpec
               (
                   DeclaringTypeName: EnumName,
                   Name: literalName,
                   LiteralValue: code.Require(),
                   DeclarationOrder: null,
                   Documentation: desc,
                   Attributions: desc?.SpecifyAttributions(gp)
               );
               

        static EnumSpec SpecifyEnum(ClrEnumName EnumName, ClrTypeReference UnderlyingType, SqlDataFrame DataSource, SqlProxyGenerationProfile gp)
            => new EnumSpec
            (
                EnumName, 
                ClrAccessKind.Public,                
                UnderlyingType, 
                rolist(SpecifyEnumLiterals(EnumName, DataSource,gp))
            );


        public static Option<EnumSpec> SpecifyEnum(this vTable EnumTable, SqlEnumProviderProperty Property, SqlProxyGenerationProfile gp)
            => from property in some(Property)
               let enumKind = property.PropertyValue
               let broker = gp.SourceBroker()
               let ult = EnumTable.Columns[0].SpecifyTypeReference(gp)
               from frame in broker.Table(EnumTable.TableName).Select(EnumSourceColumns)
               let e = SpecifyEnum(EnumTable.SpecifyEnumName(Property), ult, frame,gp)
               select e;

        public static Option<EnumSpec> SpecifyEnum(this vTable EnumTable, SqlProxyGenerationProfile gp)
            => from property in EnumTable.SqlEnumProvider()
               from e in EnumTable.SpecifyEnum(property, gp)
               select e;

        public static IEnumerable<EnumSpec> SpecifyEnums(this IEnumerable<vTable> Candidates, SqlProxyGenerationProfile gp)
            => from p in Candidates.SqlEnumProviders()
               let ul = p.Subject.Columns[0].DataType
               let spec = p.Subject.SpecifyEnum(p.Property, gp)
               where spec.IsSome()
               select spec.ValueOrDefault();
              

    }


}