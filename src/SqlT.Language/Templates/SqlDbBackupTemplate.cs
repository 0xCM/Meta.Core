//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{
    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Services;

    using static metacore;

    public class SqlDbBackupTemplate : SqlModel<SqlDbBackupTemplate> 
    {



        public SqlDbBackupTemplate
            (
            ISqlGenerationContext GC,
            SqlDatabaseName DatabaseName, 
            FilePath BackupFilePath, 
            string BackupName = null,
            bool? FormatMedia = null,
            bool? InitMedia = null,
            bool? Compress = null,
            int? Stats = null,
            bool? Skip = null
            ) 
        {

            this.DatabaseName = DatabaseName;
            this.BackupFilePath = BackupFilePath;
            this.BackupName = isBlank(BackupName) ? null : BackupName;
            this.FormatMedia = FormatMedia ?? GC.GetTemplateParameterOption(this, x => x.FormatMedia).ValueOrDefault();
            this.InitMedia = InitMedia ?? GC.GetTemplateParameterOption(this, x => x.InitMedia).ValueOrDefault();
            this.Compress = Compress ?? GC.GetTemplateParameterOption(this, x => x.Compress).ValueOrDefault();
            this.Stats = Stats ?? GC.GetTemplateParameterOption(this, x => x.Stats).ValueOrDefault();
            this.Skip = Skip ?? GC.GetTemplateParameterOption(this, x => x.Skip).ValueOrDefault();
        }

        /// <summary>
        /// The server-relative name of the source database
        /// </summary>
        [SqlTemplateParameter]
        public SqlDatabaseName DatabaseName { get; }

        /// <summary>
        /// The server-relative path to the target backup file
        /// </summary>
        [SqlTemplateParameter]
        public FilePath BackupFilePath { get; }

        /// <summary>
        /// The logical name of the backup
        /// </summary>
        [SqlTemplateParameter]
        public Option<string> BackupName { get; }

        /// <summary>
        /// Specifies whether the media header should be written on the volumes used for this backup operation, 
        /// overwriting any existing media header and backup sets.
        /// </summary>
        [SqlTemplateParameter(false)]
        public bool? FormatMedia { get; }

        /// <summary>
        /// Controls whether the backup operation appends to or overwrites the existing backup sets on the backup media. 
        /// The default is to append to the most recent backup set on the media (NOINIT)
        /// </summary>
        [SqlTemplateParameter(false)]
        public bool? InitMedia { get; }

        /// <summary>
        /// Sspecifies whether backup compression is performed on this backup, overriding the server-level default if supplied
        /// </summary>
        [SqlTemplateParameter]
        public bool? Compress { get; }

        /// <summary>
        /// Raises a message each time another percentage completes, and is used to gauge progress. 
        /// If percentage is omitted, SQL Server displays a message after each 10 percent is completed
        /// </summary>
        [SqlTemplateParameter(10)]
        public int? Stats { get; }

        /// <summary>
        /// Controls whether a backup operation checks the expiration date and time 
        /// of the backup sets on the media before overwriting them
        /// </summary>
        [SqlTemplateParameter(false)]
        public bool? Skip { get; }

        public Option<bool?> FormatMediaOption{ get; private set; }            

        public Option<bool?> InitMediaOption { get; private set; }

        public Option<bool?> CompressOption { get; private set; }
            
        public Option<int?> StatsOption { get; private set; }
        

        public Option<bool?> SkipOption { get; private set; }
            

    }
}
