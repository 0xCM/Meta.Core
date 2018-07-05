﻿//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dac
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Language;
    using SqlT.Services;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;
    using DacM = Microsoft.SqlServer.Dac.Model;
    using DacX = Microsoft.SqlServer.Dac.Extensions.Prototype;

    using static metacore;

    /// <summary>
    /// Defines operations that manipulate and project extended property specification information between alternate representations
    /// </summary>
    static class SqlPropertyTranslation
    {

        [SqlTBuilder]
        public static IReadOnlyList<SqlPropertyAttachment> ModelExtendedProperties(this SqlPropertyIndex index, DacM.ObjectIdentifier dsql) 
            => index.GetProperties(dsql.FormatName());

        [SqlTBuilder]
        public static IReadOnlyList<SqlPropertyAttachment> ModelExtendedProperties(this SqlPropertyIndex index, DacX.TSqlModelElement dsql) 
            => index.ModelExtendedProperties(dsql.Name);

        [SqlTBuilder]
        public static SqlPropertyIndex SpecifyExtendedPropertyIndex(this DacX.TSqlTypedModel dsql)
        {
            var q = from property in dsql.GetObjects<DacX.TSqlExtendedProperty>(DacM.DacQueryScopes.Default)
                    let subject = property.GetReferenced().First()
                    let lineage = rolist(subject.GetSqlElementLineage().Reverse())
                    select new SqlPropertyAttachment
                        (
                            SubjectLineage: lineage ?? rolist<SqlElementDescriptor>(),
                            PropertyName: property.GetLocalName(),
                            PropertyValue: property.FormatLiteralValue()
                         );
            return SqlPropertyIndex.Create(q);
        }
        
        public static IEnumerable<(T, string)> FindMarkedElements<T>(this DacX.TSqlTypedModel dsql, string xpname)
            where T : DacX.TSqlModelElement
        {
            foreach (var xprop in dsql.GetObjects<DacX.TSqlExtendedProperty>(DacM.DacQueryScopes.Default))
            {
                var name = xprop.GetLocalName();
                if (name == xpname)
                {
                    var subjectName = xprop.GetReferenced().FirstOrDefault().Name;
                    var subject = dsql.GetObject<T>(subjectName, DacM.DacQueryScopes.Default);
                    yield return (subject, xprop.FormatLiteralValue());
                }
            }
        }

    }
}
