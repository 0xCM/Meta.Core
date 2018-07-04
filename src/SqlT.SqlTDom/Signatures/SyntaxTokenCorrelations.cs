//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dom
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Meta.Core;
    using Meta.Models;

    using SqlT.Core;
    using SqlT.Services;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    using static metacore;

    using static SyntaxTokenCorrelations.StatementCorrelations;

    static class SyntaxTokenCorrelations
    {
        static string uri(this string s)
            => $"{s}:";
        static string xpression(this string s)
            => $"X/{s}".uri();
        static string alter(this string s)
            => $"alter/{s}".uri();
        static string create(this string s)
            => $"create/{s}".uri();

        static string drop(this string s)
            => $"drop/{s}".uri();

        static string literal(this string s)
            => $"L/{s}".uri();

        static string option(this string s)
            => $"O/{s}".uri();

        static string call(this string s)
            => $"call/{s}".uri();

        static string reference(this string s)
            => $"ref/{s}".uri();

        static string specify(this string s)
            => $"spec/{s}".uri();

        static string identify(this string s)
            => $"id/{s}".uri();

        static string contain(this string s)
            => $"{s}".uri();

        static string declare(this string s)
            => $"declare/{s}".uri();


        static (string, string) correlate<tSql, sqlT>()
            where tSql : TSql.TSqlFragment
            where sqlT : IModel => (typeof(tSql).Name, typeof(sqlT).Name);

        static (string, string) correlate<tSql>(string sqlT)
            where tSql : TSql.TSqlFragment
            => (typeof(tSql).Name, sqlT);

        static ClrProperty property<T>(Expression<Func<T, object>> selector)
            => selector.GetProperty();

        static PropertyToken name(this ClrProperty p, string assignment)
            => (p, assignment);

        public static class StatementCorrelations
        {
            static IEnumerable<(string, string)> AlterStatements()
            {
                yield return correlate<TSql.AlterTableStatement>("table".alter());
                yield return correlate<TSql.AlterSequenceStatement>("sequence".alter());
                yield return correlate<TSql.AlterSchemaStatement>("schema".alter());
            }

            static IEnumerable<(string, string)> CreateStatements()
            {
                yield return correlate<TSql.CreateTriggerStatement>("trigger".create());
                yield return correlate<TSql.CreateTableStatement>("table".create());
                yield return correlate<TSql.CreateProcedureStatement>("proc".create());
            }

            static IEnumerable<(string, string)> DropStatements()
            {
                yield return correlate<TSql.DropTableStatement>("table".drop());
                yield return correlate<TSql.DropSequenceStatement>("sequence".drop());
                yield return correlate<TSql.DropViewStatement>("view".drop());
            }

            static IEnumerable<(string, string)> DeleteStatements()
            {
                yield return correlate<TSql.DeleteStatement>("delete");

            }

            public static IEnumerable<(string, string)> Statements()
            {
                yield return correlate<TSql.SelectStatement>("select");
                yield return correlate<TSql.TruncateTableStatement>("truncate");

                var statements = unionize(
                    CreateStatements(), 
                    DropStatements(), 
                    DeleteStatements(), 
                    AlterStatements()
                    );

                foreach (var s in statements)
                    yield return s;
            }
        }

        static IEnumerable<(string, string)> Literals()
        {
            yield return correlate<TSql.MaxLiteral>("MAX".literal());
            yield return correlate<TSql.IntegerLiteral>("int".literal());
            yield return correlate<TSql.StringLiteral>("string".literal());
            yield return correlate<TSql.BinaryLiteral>("binary".literal());
            yield return correlate<TSql.DefaultLiteral>("default".literal());
            yield return correlate<TSql.MoneyLiteral>("money".literal());
            yield return correlate<TSql.IdentifierLiteral>("identifier".literal());
            yield return correlate<TSql.NumericLiteral>("numeric".literal());
        }

        static IEnumerable<(string, string)> Expressions()
        {
            
            yield return correlate<TSql.SelectScalarExpression>("select_scalar".xpression());
            yield return correlate<TSql.IdentifierOrValueExpression>("(id|val)".xpression());
            yield return correlate<TSql.BooleanComparisonExpression>("boolean/comparison".xpression());
            yield return correlate<TSql.BooleanBinaryExpression>("boolean/bininary".xpression());
            yield return correlate<TSql.BooleanParenthesisExpression>("boolean/parenthesis".xpression());
        }

        static IEnumerable<(string, string)> Options()
        {
            yield return correlate<TSql.FileTableDirectoryTableOption>("file_table_dir".option());
            yield return correlate<TSql.FileTableConstraintNameTableOption>("file_table_constraint".option());
        }

        static IEnumerable<(string, string)> Definitions()
        {
            yield return correlate<TSql.ColumnDefinition>("define_column");
            yield return correlate<TSql.TableDefinition>("define_table");
            yield return correlate<TSql.NullableConstraintDefinition>("define_nullability");
        }

        static IEnumerable<(string, string)> Clauses()
        {
            yield return correlate<TSql.WhereClause>("where");
            yield return correlate<TSql.FromClause>("from");
        }

        static IEnumerable<(string, string)> Declarations()
        {
            yield return correlate<TSql.DeclareVariableElement>("variable".declare());
        }


        static IEnumerable<(string, string)> Calls()
        {
            yield return correlate<TSql.ConvertCall>("convert".call());
            yield return correlate<TSql.FunctionCall>("function".call());
        }

        static IEnumerable<(string, string)> References()
        {
            yield return correlate<TSql.SqlDataTypeReference>("sqltype".reference());
            yield return correlate<TSql.NamedTableReference>("table".reference());
            yield return correlate<TSql.ColumnReferenceExpression>("column".reference());

        }

        static IEnumerable<(string, string)> Specifications()
        {
            yield return correlate<TSql.DeleteSpecification>("delete".specify());
            yield return correlate<TSql.QuerySpecification>("query".specify());
        }

        static IEnumerable<(string, string)> Identifications()
        {
            yield return correlate<TSql.SchemaObjectName>("object_name");
            yield return correlate<TSql.Identifier>("simple".identify());
            yield return correlate<TSql.MultiPartIdentifier>("composite".identify());

        }

        static IEnumerable<(string, string)> Containers()
        {
            yield return correlate<TSql.TSqlScript>("script".contain());
            yield return correlate<TSql.TSqlBatch>("batch".contain());
        }

        static IEnumerable<PropertyToken> Properties()
        {
            yield return property<TSql.CreateTriggerStatement>(x => x.TriggerType).name("type");
        }

        public static IEnumerable<(string, string)> Define()
        {
            foreach (var c in Containers()) yield return c;
            foreach (var i in Identifications()) yield return i;
            foreach (var l in Literals()) yield return l;
            foreach (var x in Expressions()) yield return x;
            foreach (var o in Options()) yield return o;
            foreach (var d in Declarations()) yield return d;
            foreach (var s in Specifications()) yield return s;
            foreach (var d in Definitions()) yield return d;
            foreach (var c in Clauses()) yield return c;
            foreach (var c in Calls()) yield return c;
            foreach (var s in Statements()) yield return s;
            foreach (var r in References()) yield return r;

        }

        static IReadOnlyDictionary<X, IReadOnlyDictionary<Y, Z>> 
            ToDictionary<X, Y, Z>(this IEnumerable<(X x, Y y, Z z)> coordinates)
        {
            
            var outerKeys = coordinates.Select(c => c.x).Distinct();
            var outerIndex = new Dictionary<X, IReadOnlyDictionary<Y, Z>>();
            var innerIndex = MutableList.Create<IReadOnlyDictionary<Y, Z>>();
            foreach(var f in outerKeys)
            {
                var inner = 
                    (from c in coordinates
                    where c.x.Equals(f)
                    select (c.y, c.z)).ToReadOnlyDictionary();

                outerIndex[f] = inner;
            }
            return outerIndex;
        }

        static IReadOnlyDictionary<string, IReadOnlyDictionary<string, PropertyToken>> CreatePropertyTokenIndex()
            => (from token in Properties()
                let type = token.TSqlProperty.DeclaringType.Name
                let propertyTuple = (token.TSqlProperty.Name, token)
                select (type, token.TSqlProperty.Name, token)).ToDictionary();

        static readonly IReadOnlyDictionary<string, string> fragIndex 
            = Define().ToReadOnlyDictionary();

        public static string TokenName(this TSql.TSqlFragment tSql)
            => fragIndex.TryFind(tSql.GetType().Name).ValueOrDefault(tSql.GetType().Name);
    }

    class PropertyToken
    {

        public static implicit operator PropertyToken((ClrProperty TSqlProperty, string TokenName) x)
            => new PropertyToken(x.TSqlProperty, x.TokenName);

        public PropertyToken(ClrProperty TSqlProperty, string TokenName)
        {
            this.TSqlProperty = TSqlProperty;
            this.TokenName = TokenName;
        }

        public ClrProperty TSqlProperty { get; }

        public string TokenName { get; }
        
    }
}