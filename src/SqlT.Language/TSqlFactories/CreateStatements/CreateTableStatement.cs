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
    using SqlT.Language;
    using static metacore;
    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    public static partial class TSqlFactory
    {
        public static TSql.DeleteUpdateAction TSqlEnum(this SqlForeignKeyAction src)
        {
            switch(src)
            {
                case SqlForeignKeyAction.Cascade:
                    return TSql.DeleteUpdateAction.Cascade;
                case SqlForeignKeyAction.SetNull:
                    return TSql.DeleteUpdateAction.SetNull;
                case SqlForeignKeyAction.SetDefault:
                    return TSql.DeleteUpdateAction.SetDefault;
                default:
                    return TSql.DeleteUpdateAction.NoAction;
            }
        }

        public static TSql.CreateTableStatement TSqlCreate(this SqlTable src)
        {
            var tdef = new TSql.TableDefinition();
            foreach (var col in src.Columns)
                tdef.ColumnDefinitions.Add(col.TSqlColumnDef());

            if (src.PrimaryKey)
            {
                var xpk = src.PrimaryKey.Require();
                var tpk = new TSql.UniqueConstraintDefinition()
                {
                    ConstraintIdentifier = xpk.ObjectName.UnqualifiedName.TSqlIdentifier(),
                    IsPrimaryKey = true,
                };

                if (xpk.IgnoreDuplicateKeys)
                    tpk.IndexOptions.Add(new TSql.IndexStateOption
                    {
                        OptionKind = TSql.IndexOptionKind.IgnoreDupKey,
                        OptionState = TSql.OptionState.On
                    });

                tdef.TableConstraints.Add(tpk);
                foreach (var xKeyCol in xpk.KeyColumns)
                {
                    tpk.Columns.Add(new TSql.ColumnWithSortOrder()
                    {
                        Column = xKeyCol.TSqlColumnRef()
                    });
                }
            }

            var indexes = map(src.Indexes, i => i.TSqlDefine());
            tdef.Indexes.AddRange(indexes);
            
            foreach(var fk in src.ForeignKeys)
            {
                var fkDef = new TSql.ForeignKeyConstraintDefinition()
                {
                  ConstraintIdentifier = fk.Name.UnquotedLocalName.TSqlIdentifier(),
                  ReferenceTableName = fk.SupplierTableName.TSqlSchemaObjectName(),
                  DeleteAction = fk.OnSupplierDelete.TSqlEnum(),
                  UpdateAction = fk.OnSupplierUpdate.TSqlEnum()                                                     
                };
                iter(fk.KeyColumns, fkCol =>
                {
                    fkDef.Columns.Add(fkCol.ClientColumn.Name.TSqlIdentifier());
                    fkDef.ReferencedTableColumns.Add(fkCol.SupplierColumn.Name.TSqlIdentifier());
                });
                tdef.TableConstraints.Add(fkDef);
            }

            var table = new TSql.CreateTableStatement
            {
                SchemaObjectName = src.TSqlSchemaObjectName(true),
                Definition = tdef,
                OnFileGroupOrPartitionScheme = new TSql.FileGroupOrPartitionScheme
                {
                    Name = new TSql.IdentifierOrValueExpression
                    {
                        Identifier = new TSql.Identifier
                        {
                            Value = TSql.Identifier.EncodeIdentifier(src.FileGroupName.UnqualifiedName)
                        }
                    }
                },
            };

            return table;
        }
    }
}