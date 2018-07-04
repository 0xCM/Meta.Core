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
    using SqlT.SqlTDom;

    using SqlT.Types.SqlDom;

    using static metacore;



    public class SqlDomMetamodelViews
    {
        IEnumerable<SqlDomTypeDescriptor> Descriptors { get; }
        public SqlDomMetamodelViews(IEnumerable<SqlDomTypeDescriptor> Descriptors)
        {
            this.Descriptors = Descriptors;
        }
        public IEnumerable<SqlDomTypeDescriptor> EnumTypes
            => from t in Descriptors
               where t.IsEnum
               select t;


        public IEnumerable<SqlDomTypeDescriptor> AlterStatements
            => from t in Descriptors
               where t.DomElementKind == ElementKind.AlterStatement
               select t;

        public IEnumerable<SqlDomTypeDescriptor> CreateStatements
            => from t in Descriptors
               where t.DomElementKind == ElementKind.CreateStatement
               select t;

        public IEnumerable<SqlDomTypeDescriptor> DropStatements
            => from t in Descriptors
               where t.DomElementKind == ElementKind.DropStatement
               select t;

        public IEnumerable<SqlDomTypeDescriptor> DefinitionTypes
            => from t in Descriptors
               where t.DomElementKind == ElementKind.Definition
               select t;

        public IEnumerable<SqlDomTypeDescriptor> OptionTypes
            => from t in Descriptors
               where t.DomElementKind == ElementKind.Option
               select t;

        public IEnumerable<SqlDomTypeDescriptor> ReferenceTypes
            => from t in Descriptors
               where t.DomElementKind == ElementKind.ElementReference
               select t;

        public IEnumerable<SqlDomTypeDescriptor> NonScalarExpressionTypes
            => from t in Descriptors
               where t.DomElementKind == ElementKind.NonscalarExpression
               select t;

        public IEnumerable<SqlDomTypeDescriptor> ScalarExpressionTypes
            => from t in Descriptors
               where t.DomElementKind == ElementKind.ScalarExpression
               select t;

        public IEnumerable<SqlDomTypeDescriptor> LiteralTypes
            => from t in Descriptors
               where t.DomElementKind == ElementKind.Literal
               select t;

        public IEnumerable<SqlDomTypeDescriptor> PredicateTypes
            => from t in Descriptors
               where t.DomElementKind == ElementKind.Predicate
               select t;


    }



}