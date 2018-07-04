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


    using SqlT.Core;
    using SqlT.Models;
    using SqlT.CSharp;
    using SqlT.Services;

    using static metacore;

    using DomTypes = SqlT.Types.SqlDom;
    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;



    public static class VocabX
    {
        public static string Identifier(this DomTypes.ElementKind kind)
            => kind.ToString();

        public static DomTypes.ElementAttribute ToRecord(this SqlDomAttribute a)
            => new DomTypes.ElementAttribute
               (
                    ElementName: a.ElementName,
                    AttributeName: a.MemberName,
                    DataType: a.MemberType.Name,
                    Infrastructure: a.SupportsInfrastructure,
                    IsReadOnly: a.IsReadOnly
               );

        public static DomTypes.Association ToRecord(this SqlDomAssociation a)
            => new DomTypes.Association
               (
                    ElementName: a.ElementName,
                    AssociationName: a.MemberName,
                    AssociationType: a.MemberType.Name,
                    IsReadOnly: a.IsReadOnly
               );

        public static DomTypes.Collection ToRecord(this SqlDomCollection c)
            => new DomTypes.Collection
               (
                    ElementName: c.ElementName,
                    CollectionName: c.MemberName,
                    ItemType: c.ItemType.Name,
                    IsReadOnly: c.IsReadOnly
               );


    }



}