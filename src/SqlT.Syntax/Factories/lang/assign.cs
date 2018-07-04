//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Syntax;
    using SqlT.Core;

    using static SqlSyntax;

    using static metacore;
    using sxc = contracts;
    
    using kwt = SqlKeywordTypes;

    partial class sql
    {
        public static variable_assignment assign(SqlVariableName name, ISyntaxExpression value)
            => new variable_assignment(name, value);

        public static variable_assignment assign(SqlVariableName name, CoreDataValue value)
            => new variable_assignment(name, value.ToSqlLiteral());
    }
}
 