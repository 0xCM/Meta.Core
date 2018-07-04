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
    using SqlT.Core;
    using SqlT.Syntax;
    using SqlT.Models;

    using static metacore;
    using static SqlSyntax;
    
    using static SqlFunctions;

    using sxc = contracts;
    using kwt = SqlKeywordTypes;
    using xpn = SqlT.Core.SqlExtendedPropertyName;

    using sx = SqlSyntax;
    using static sql;

    public static class SqlPropertyExtensions
    {
        public static xprop_value XProp(this kwt.DATABASE db, xpn xprop_name, SqlVariant xprop_value)
            => xprop(db, xprop_name, xprop_value);

        public static xprop_value XProp(this SqlDatabaseName db, xpn xprop_name, SqlVariant xprop_value)
            => kwt.DATABASE.get().XProp(xprop_name, xprop_value);

        public static xprop_value XProp(this SqlTableTypeName name, xpn xprop_name, SqlVariant xprop_value)
            => xprop(TABLETYPE, name, xprop_name, xprop_value);

        public static xprop_value XProp(this SqlTableName name, xpn xprop_name, SqlVariant xprop_value)
            => xprop(TABLE, name, xprop_name, xprop_value);

        public static xprop_value XProp(this SqlViewName name, xpn xprop_name, SqlVariant xprop_value)
            => xprop(VIEW, name, xprop_name, xprop_value);

        public static xprop_value XProp(this SqlFunctionName name, xpn xprop_name, SqlVariant xprop_value)
            => xprop(FUNCTION, name, xprop_name, xprop_value);

        public static xprop_value XProp(this SqlProcedureName name, xpn xprop_name, SqlVariant xprop_value)
            => xprop(PROCEDURE, name, xprop_name, xprop_value);
    }
}