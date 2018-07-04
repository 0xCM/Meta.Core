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
    using SqlT.Syntax;
    using SqlT.Services;
    using SqlT.Templates;

    using static SqlT.Templates.SqlRestoreDatabase;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    using static metacore;

    public static partial class SqlTFactory
    {
        static Move Specify(TSql.MoveRestoreOption src)
            => new Move(src.LogicalFileName.LiteralValue(), src.OSFileName.LiteralValue());


        [SqlTBuilder]
        public static Option<SqlRestoreDatabase> Model(this TSql.RestoreStatement src)
        {
            var device = src.Devices.FirstOrDefault();
            if (device != null && device.DeviceType == TSql.DeviceType.Disk)
            {
                var movements = src.Options.OfType<TSql.MoveRestoreOption>()
                                            .Where(x => x.OSFileName.IsStringLiteral() && x.LogicalFileName.IsStringLiteral())
                                            .Map(Specify)
                                            .ToArray();
                return new SqlRestoreDatabase(
                   SourceFile: (device.PhysicalDevice as TSql.StringLiteral)?.Value,
                   DatabaseName: new SqlDatabaseName(src.DatabaseName.Value),
                   Movements: movements);
            }
            return none<SqlRestoreDatabase>();
        }


        public static Option<T> Model<T>(this IEnumerable<TSql.BackupOption> options, TSql.BackupOptionKind kind)
        {
            var spec = none<T>();
            var option = options.TryGetFirst(x => x.OptionKind == kind);
            if (option)
            {
                var optionValue = option.ValueOrDefault();
                switch (kind)
                {
                    case TSql.BackupOptionKind.Name:
                        spec = tryCast<TSql.StringLiteral>(optionValue.Value).MapValueOrDefault(s => (T)(object)(s.Value));
                        break;
                    case TSql.BackupOptionKind.Stats:
                        spec = try_parse<T>(optionValue.GetFragmentText());
                        break;
                    case TSql.BackupOptionKind.Compression:
                    case TSql.BackupOptionKind.NoCompression:
                    case TSql.BackupOptionKind.Skip:
                    case TSql.BackupOptionKind.NoSkip:
                    case TSql.BackupOptionKind.Format:
                    case TSql.BackupOptionKind.NoFormat:
                    case TSql.BackupOptionKind.Init:
                    case TSql.BackupOptionKind.NoInit:
                        spec = tryCast<T>(true);
                        break;
                }
            }
            return spec;
        }

        [SqlTBuilder]
        public static Option<SqlDbBackupTemplate> Model(this ISqlGenerationContext GC, TSql.BackupStatement src)
        {
            var device = src.Devices.FirstOrDefault();
            if (device != null && device.DeviceType == TSql.DeviceType.Disk)
            {
                var name = src.Options.Model<string>(TSql.BackupOptionKind.Name);
                return new SqlDbBackupTemplate(GC,
                    DatabaseName: new SqlDatabaseName(src.DatabaseName.Value),
                    BackupFilePath: (device.PhysicalDevice as TSql.StringLiteral)?.Value,
                    BackupName: name.ValueOrDefault(),
                    FormatMedia: src.Options.Model<bool?>(TSql.BackupOptionKind.Format).ValueOrDefault(),
                    InitMedia: src.Options.Model<bool?>(TSql.BackupOptionKind.Init).ValueOrDefault(),
                    Compress: src.Options.Model<bool?>(TSql.BackupOptionKind.Compression).ValueOrDefault(),
                    Skip: src.Options.Model<bool?>(TSql.BackupOptionKind.Skip).ValueOrDefault(),
                    Stats: src.Options.Model<int?>(TSql.BackupOptionKind.Stats).ValueOrDefault()
                    );
            }
            return none<SqlDbBackupTemplate>();
        }

        [SqlTBuilder]
        public static Option<SqlTruncateTable> Model(this TSql.TruncateTableStatement src)
            => new SqlTruncateTable(src.TableName.ToTableName());
    }
}
