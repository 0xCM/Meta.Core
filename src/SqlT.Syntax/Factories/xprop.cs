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

    using static SqlSyntax;

    using static metacore;
    using sxc = contracts;
    
    using kwt = SqlKeywordTypes;
    using sx = SqlSyntax;
    using xpn = SqlT.Core.SqlExtendedPropertyName;
    using kpt = SqlKeyPhraseTypes;
    using static xprop_level_types;

    static class xprop_level_types
    {
        public static xprop_level0_type XPL0 = new xprop_level0_type();
        public static xprop_level1_type XPL1 = new xprop_level1_type();
        public static xprop_level2_type XPL2 = new xprop_level2_type();
    }

    partial class sql
    {

        public static procedure_call sp_addextendedproperty(string name, SqlVariant? value = null,
            string level0Type = null, string level0Name = null,
            string level1Type = null, string level1Name = null,
            string level2Type = null, string level2Name = null) 
                => new procedure_call(nameof(sp_addextendedproperty),
                    sql.args((nameof(name), value),
                        (nameof(level0Type), level0Name),
                        (nameof(level1Type), level1Name),
                        (nameof(level2Type), level2Name)));
       
        static xprop_path xpropPath(xpn xprop_name)
            => new xprop_path(xprop_name,new xprop_segment());

        static xprop_path xpropPath(this SqlFunctionName f, xpn xprop_name)
            => new xprop_path(xprop_name,
                    new xprop_segment(XPL0.Schema, f.SchemaName),
                    new xprop_segment(XPL1.Function, f.UnquotedLocalName));

        static xprop_path xpropPath(this SqlTableName t, xpn xprop_name)
            => new xprop_path(xprop_name,
                    new xprop_segment(XPL0.Schema, t.SchemaName),
                    new xprop_segment(XPL1.Table, t.UnquotedLocalName));

        static xprop_path xpropPath(this SqlViewName t, xpn xprop_name)
            => new xprop_path(xprop_name,
                    new xprop_segment(XPL0.Schema, t.SchemaName),
                    new xprop_segment(XPL1.View, t.UnquotedLocalName));

        static xprop_path xpropPath(this SqlIndexName i, SqlTableName t, xpn xprop_name)
            => new xprop_path(xprop_name,
                    new xprop_segment(XPL0.Schema, t.SchemaName),
                    new xprop_segment(XPL1.Table, t.UnquotedLocalName),
                    new xprop_segment(XPL2.Index, i.UnquotedLocalName));

        static xprop_path xpropPath(this SqlColumnName c, SqlTableName t, xpn xprop_name)
            => new xprop_path(xprop_name,
                    new xprop_segment(XPL0.Schema, t.SchemaName),
                    new xprop_segment(XPL1.Table, t.UnquotedLocalName),
                    new xprop_segment(XPL2.Column, c.UnquotedLocalName));

        static xprop_path xpropPath(this SqlColumnName i, SqlTableTypeName t, xpn xprop_name)
            => new xprop_path(xprop_name,
                    new xprop_segment(XPL0.Schema, t.SchemaName),
                    new xprop_segment(XPL1.TableType, t.UnquotedLocalName),
                    new xprop_segment(XPL2.Index, i.UnquotedLocalName));

        static xprop_path xpropPath(this SqlTableTypeName t, xpn xprop_name)
            => new xprop_path(xprop_name,
                    new xprop_segment(XPL0.Schema, t.SchemaName),
                    new xprop_segment(XPL1.TableType, t.UnquotedLocalName));

        static xprop_path xpropPath(this SqlProcedureName p, xpn xprop_name)
            => new xprop_path(xprop_name,
                    new xprop_segment(XPL0.Schema, p.SchemaName),
                    new xprop_segment(XPL1.Procedure, p.UnquotedLocalName));

        static xprop_path xpropPath(this SqlTypeName t, xpn xprop_name)
            => new xprop_path(xprop_name,
                    new xprop_segment(XPL0.Schema, t.SchemaName),
                    new xprop_segment(XPL1.Procedure, t.UnquotedLocalName));

        static xprop_path xpropPath(this SqlMessageTypeName t, xpn xprop_name)
            => new xprop_path(xprop_name, 
                    new xprop_segment(XPL0.MessageType, t.UnquotedLocalName));

        static xprop_path xpropPath(this SqlSchemaName t, xpn xprop_name)
            => new xprop_path(xprop_name, 
                    new xprop_segment(XPL0.Schema, t.UnquotedLocalName));

        public static xprop_value xprop(kwt.FUNCTION FUNCTION, 
            SqlFunctionName function, xpn xprop_name,SqlVariant xprop_value) 
                => new xprop_value(function.xpropPath(xprop_name), xprop_value);

        public static xprop_value xprop(kwt.TABLE TABLE, 
            SqlTableName table_name, xpn xprop_name, SqlVariant xprop_value)
                => new xprop_value(table_name.xpropPath(xprop_name), xprop_value);

        public static xprop_value xprop(kwt.VIEW TABLE, 
            SqlViewName view_name, xpn xprop_name, SqlVariant xprop_value)
                => new xprop_value(view_name.xpropPath(xprop_name), xprop_value);

        public static xprop_value xprop(kwt.PROCEDURE PROCEDURE, 
            SqlProcedureName procedure, xpn xprop_name, SqlVariant xprop_value)
                => new xprop_value(procedure.xpropPath(xprop_name), xprop_value);

        public static xprop_value xprop(kpt.TABLETYPE TABLETYPE, 
            SqlTableTypeName type_name, xpn xprop_name, SqlVariant xprop_value)
                => new xprop_value(type_name.xpropPath(xprop_name), xprop_value);

        public static xprop_value xprop(kpt.MESSAGETYPE MESSAGETYPE, 
            SqlMessageTypeName message_type, xpn xprop_name, SqlVariant xprop_value)
                => new xprop_value(message_type.xpropPath(xprop_name), xprop_value);

        public static xprop_value xprop(kwt.SCHEMA SCHEMA, 
            SqlSchemaName schema, xpn xprop_name, SqlVariant xprop_value)
                => new xprop_value(schema.xpropPath(xprop_name), xprop_value);

        public static xprop_value xprop(kwt.INDEX INDEX, 
            SqlTableName table, SqlIndexName index, xpn xprop_name, SqlVariant xprop_value)
                => new xprop_value(index.xpropPath(table, xprop_name), xprop_value);

        public static xprop_value xprop(kwt.COLUMN COLUMN, 
            SqlTableName table, SqlColumnName column, xpn xprop_name, SqlVariant xprop_value)
                => new xprop_value(column.xpropPath(table, xprop_name), xprop_value);

        public static xprop_value xprop(kwt.COLUMN COLUMN, 
            SqlTableTypeName table_type, SqlColumnName column, xpn xprop_name, SqlVariant xprop_value)
                => new xprop_value(column.xpropPath(table_type, xprop_name), xprop_value);

        public static xprop_value xprop(kwt.DATABASE DATABASE, 
            xpn xprop_name, SqlVariant xprop_value)
                => new xprop_value(xpropPath(xprop_name), xprop_value);
    }

}