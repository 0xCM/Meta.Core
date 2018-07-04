//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Syntax;
    using SqlT.Language;
    

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
