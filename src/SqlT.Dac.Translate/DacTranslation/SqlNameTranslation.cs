//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dac
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;

    using SqlT.Core;

    using DacM = Microsoft.SqlServer.Dac.Model;
    using DacX = Microsoft.SqlServer.Dac.Extensions.Prototype;
    using sxc = SqlT.Syntax.contracts;

    public static class SqlNameTranslation
    {

        [SqlTBuilder]
        public static SqlName SpecifyElementName(this DacM.ObjectIdentifier src)
            => new SqlName(src.Parts.ToArray());

        [SqlTBuilder]
        public static sxc.ISqlObjectName SpecifyObjectName(this DacM.ObjectIdentifier src)
        {
            var parts = src.Parts;
            switch (parts.Count)
            {
                case 0:
                    //Handles the case when objects are anonymous, such as when a primary key or default constrained is defined
                    //in-line anonymously
                    return new SqlObjectName(String.Empty);
                case 1: return new SqlObjectName(parts[0]);
                case 2: return new SqlObjectName(parts[0], parts[1]);
                case 3: return new SqlObjectName(parts[0], parts[1], parts[2]);
                case 4: return new SqlObjectName(parts[0], parts[1], parts[2], parts[2]);
                default:
                    throw new NotSupportedException();
            }
        }

        [SqlTBuilder]
        public static SqlTypeName SpecifyTypeName(this DacM.ObjectIdentifier src)
            => new SqlTypeName(src.SpecifyObjectName());

        [SqlTBuilder]
        public static SqlDataTypeName SpecifyDataTypeName(this DacM.ObjectIdentifier src)
            => new SqlDataTypeName(src.SpecifyObjectName());


        [SqlTBuilder]
        public static SqlFunctionName SpecifyFunctionName(this DacM.ObjectIdentifier src)
            => new SqlFunctionName(src.SpecifyObjectName());

        [SqlTBuilder]
        public static sxc.ISqlObjectName SpecifyObjectName(this DacX.ISqlModelElement element)
            => element.Name.SpecifyObjectName();

        [SqlTBuilder]
        public static SqlPrimaryKeyName SpecifyPrimaryKeyName(this DacX.ISqlModelElement element)
            => new SqlPrimaryKeyName(element.Name.SpecifyObjectName());

        [SqlTBuilder]
        public static SqlTypeName SpecifyTypeName(this DacX.ISqlModelElement element)
            => new SqlTypeName(element.SpecifyObjectName());

        [SqlTBuilder]
        public static SqlTableTypeName SpecifyTableTypeName(this DacX.ISqlModelElement element)
            => new SqlTableTypeName(element.SpecifyObjectName());

        [SqlTBuilder]
        public static SqlProcedureName SpecifyProcedureName(this DacX.ISqlModelElement element)
            => new SqlProcedureName(element.SpecifyObjectName());

        [SqlTBuilder]
        public static SqlFunctionName SpecifyFunctionName(this DacX.ISqlModelElement element)
            => new SqlFunctionName(element.SpecifyObjectName());

        public static string FormatName(this DacM.ObjectIdentifier dsql, bool quoted = true)
        {
            var sb = new StringBuilder();
            var parts = dsql.Parts;
            for (int i = 0; i < parts.Count; i++)
            {
                var part = parts[i];
                if (quoted)
                    sb.AppendFormat("[{0}]", part);
                else
                    sb.Append(part);

                if (i != parts.Count - 1)
                    sb.Append('.');
            }
            return sb.ToString();
        }

        public static string GetLocalName(this DacX.TSqlExtendedProperty dsql)
            => dsql.Name.Parts.Last();

        public static string GetLocalName(this DacX.TSqlModelElement dsql)
            => dsql.Name.HasName ? dsql.Name.Parts.Last() : String.Empty;

        public static string GetFullNameText(this DacX.TSqlModelElement dsql)
            => dsql.Name.FormatName();
    }


}