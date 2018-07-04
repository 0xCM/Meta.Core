//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{
    using System;
    using System.Text;

    using Meta.Models;
    using SqlT.Syntax;
    using SqlT.Services;
    
    using static SqlT.Syntax.SqlSyntax;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;
    using sxc = SqlT.Syntax.contracts;
    using static SqlT.Syntax.sql;

    class LiteralVisitor : TSqlVisitor<LiteralVisitor, TSql.Literal>
    {

        public LiteralVisitor()
        {

        }

        public LiteralVisitor(TSql.Literal Host, Action<IModel> Observer)
            : base(Host, Observer) { }
        
        public override sealed void Visit(TSql.BinaryLiteral node)
            => Observer(binary_literal(node.Value));

        public override sealed void Visit(TSql.DefaultLiteral node)
            => Observer(symbolic_literal(DEFAULT));

        public override sealed void Visit(TSql.IdentifierLiteral node)
            => Observer(identifier(node.Value));

        public override sealed void Visit(TSql.IntegerLiteral node)
            => Observer(integer_literal(node.Value));

        public override sealed void Visit(TSql.MaxLiteral node)
            => Observer(symbolic_literal(MAX));

        public override sealed void Visit(TSql.MoneyLiteral node)
            => Observer(money_literal(node.Value));

        public override sealed void Visit(TSql.NullLiteral node)
            => Observer(symbolic_literal( NULL));

        public override sealed void Visit(TSql.NumericLiteral node)
            => Observer(decimal_literal(node.Value));

        public override sealed void Visit(TSql.OdbcLiteral node)
        {
            switch(node.OdbcLiteralType)
            {
                case TSql.OdbcLiteralType.Date:
                    Observer(date_literal(node.Value));
                    break;
                case TSql.OdbcLiteralType.Guid:
                    Observer(unique_identifier_literal(node.Value));
                    break;
                case TSql.OdbcLiteralType.Time:
                    Observer(time_literal(node.Value));
                    break;
                case TSql.OdbcLiteralType.Timestamp:
                    Observer(date_time_literal(node.Value));
                    break;

            }
        }

        public override sealed void Visit(TSql.RealLiteral node)
            => Observer(float_literal(node.Value));

        public override sealed void Visit(TSql.StringLiteral node)
            => Observer(string_literal(node.Value));
    }

}
