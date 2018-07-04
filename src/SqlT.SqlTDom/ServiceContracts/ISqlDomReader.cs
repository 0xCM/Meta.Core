//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dom
{
    using System;
    using System.Collections.Generic;

    using SqlT.Models;
    using SqlT.Language;
    using SqlT.Core;
    using SqlT.Services;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    public interface ISqlDomReader
    {
        IEnumerable<SqlDomAttributeValue> AttributeValues(TSql.TSqlFragment tSql, SqlDomElementValue parent = null);

        IEnumerable<SqlDomAssociationValue> AssociationValues(TSql.TSqlFragment tSql, SqlDomElementValue parent = null);

        IEnumerable<SqlDomCollectionValue> CollectionValues(TSql.TSqlFragment tSql, SqlDomElementValue parent = null);

        IEnumerable<SqlDomElementValue> Deconstruct(TSql.TSqlFragment tSql, SqlDomElementValue parent = null);

        SqlDomRoot DomRoot(TSql.TSqlFragment tSql);
    }



}