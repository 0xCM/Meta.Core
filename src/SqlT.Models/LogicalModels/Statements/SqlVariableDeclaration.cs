//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using SqlT.Core;
    using SqlT.Syntax;
    using static metacore;
    using sx = SqlT.Syntax.SqlSyntax;
    using sxc = SqlT.Syntax.contracts;
    using sxf = Syntax.SqlSyntaxFormatters;

    using static SqlT.Syntax.SqlSyntax;


    public class SqlVariableDeclaration : SqlStatement<SqlVariableDeclaration>
    {

        public static implicit operator SqlVariableDeclaration((SqlVariableName VariableName, typeref VariableType, SqlVariableInitializer Initializer) x)
            => new SqlVariableDeclaration(x.VariableName, x.VariableType,x.Initializer);

        public static implicit operator SqlVariableDeclaration((SqlVariableName VariableName, typeref VariableType, CoreDataValue Initializer) x)
            => new SqlVariableDeclaration(x.VariableName, x.VariableType, x.Initializer);

        public static implicit operator SqlVariableDeclaration((SqlVariableName VariableName, typeref VariableType) x)
            => new SqlVariableDeclaration(x.VariableName, x.VariableType);


        SqlVariableDeclaration()
            : base(sx.DECLARE, statement_kind.DeclareVariable)
        {

        }

        public SqlVariableDeclaration(SqlVariableName VariableName, typeref VariableType, SqlVariableInitializer Initializer = null)
            : base(sx.DECLARE, statement_kind.DeclareVariable)
        {
            this.VariableName = VariableName;
            this.VariableType = VariableType;
            this.Initializer = Initializer;

        }



        public SqlVariableDeclaration(SqlVariableName VariableName, typeref VariableType)
            : this()
        {
            this.VariableName = VariableName;
            this.VariableType = VariableType;

        }


        public SqlVariableDeclaration(SqlVariableName VariableName, typeref VariableType, CoreDataValue InitialValue)
            : this(VariableName, VariableType, InitialValue != null ? new SqlVariableInitializer(VariableType, InitialValue.ToSqlLiteral()) : null)
        {

        }


        public SqlVariableName VariableName { get; }

        public typeref VariableType { get; }

        public Option<SqlVariableInitializer> Initializer { get; }






    }
}
