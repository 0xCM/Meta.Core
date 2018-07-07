//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{
    using System;
    using System.Linq;

    using SqlT.Core;
    using SqlT.Models;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    using static metacore;

    public static class SqlVariableDeclaratonTranslation
    {
        [SqlTBuilder]
        public static Option<SqlVariableDeclaration> Model(this TSql.DeclareVariableElement src)
            => new SqlVariableDeclaration(
                    src.VariableName.ToVariableName(),
                    src.DataType.ModelReference(new SqlDataFacets(false)),
                    (src.Value as TSql.Literal)?.ToCoreDataValue().ValueOrDefault()
                    );

        [SqlTBuilder]
        public static Option<SqlVariableDeclaration> Model(this TSql.DeclareVariableStatement src)
            => from x in src.Declarations.TryGetFirst()
               from y in x.Model()
               select y;           
    }
}
