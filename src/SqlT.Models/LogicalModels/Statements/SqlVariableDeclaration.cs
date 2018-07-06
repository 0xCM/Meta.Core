//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Linq;
    using SqlT.Core;
    using SqlT.Syntax;
    using static metacore;

    using static SqlT.Syntax.SqlSyntax;

    using sx = SqlT.Syntax.SqlSyntax;

    /// <summary>
    /// Characterizes a variable declaration
    /// </summary>
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

        public string FormatSyntax()
            => concat($"{DECLARE} {VariableName}", " ",
                $"{Initializer.MapValueOrDefault(s => s.FormatSyntax(), string.Empty)}");
    }
}
