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
    using SqlT.Templates;
    using static metacore;
    using sx = SqlT.Syntax.SqlSyntax;
    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    partial class TSqlFactory
    {
        static IEnumerable<TSql.BackupOption> GetOptions(this SqlDbBackupTemplate src)
        {
            if (src.CompressOption)
                yield return new TSql.BackupOption
                {
                    OptionKind = src.CompressOption.Value() 
                              ? TSql.BackupOptionKind.Compression 
                              : TSql.BackupOptionKind.NoCompression
                };


            if (src.InitMediaOption)
                yield return new TSql.BackupOption
                {
                    OptionKind = src.InitMediaOption.Value()
                              ? TSql.BackupOptionKind.Init
                              : TSql.BackupOptionKind.NoInit
                };

            if (src.FormatMediaOption)
                yield return new TSql.BackupOption
                {
                    OptionKind = src.FormatMediaOption.Value() 
                               ? TSql.BackupOptionKind.Format 
                               : TSql.BackupOptionKind.NoFormat
                };

            if (src.StatsOption)
                yield return new TSql.BackupOption
                {
                    OptionKind = TSql.BackupOptionKind.Stats,
                    Value = src.StatsOption.Value().TSqlIntegerLiteral()
                };

            if (src.SkipOption)
                yield return new TSql.BackupOption
                {
                    OptionKind = src.SkipOption.Value() 
                               ? TSql.BackupOptionKind.Skip 
                               : TSql.BackupOptionKind.NoSkip
                };

            if(src.BackupName)
                yield return new TSql.BackupOption
                {
                    OptionKind = TSql.BackupOptionKind.Name,
                    Value = src.BackupName.ValueOrDefault().TSqlStringLiteral()
                };
        }
        

        [TSqlBuilder]
        public static TSql.BackupDatabaseStatement TSqlStatement(this SqlDbBackupTemplate src)
        {
            var statement = new TSql.BackupDatabaseStatement
            {
                DatabaseName = src.DatabaseName.TSqlIdentifierOrValueExpression(),              
            };
            statement.Devices.Add(src.BackupFilePath.TSqlDevice());
            statement.Options.AddRange(src.GetOptions());

            return statement;
        }

        [TSqlBuilder]
        public static TSql.BackupDatabaseStatement TSqlStatement(this sx.backup_database src)
        {
            var statement = new TSql.BackupDatabaseStatement
            {
                DatabaseName = src.database_name.TSqlIdentifierOrValueExpression(),
            };
            statement.Devices.Add(src.target_path.TSqlDevice());            
            return statement;
        }

    }
}
