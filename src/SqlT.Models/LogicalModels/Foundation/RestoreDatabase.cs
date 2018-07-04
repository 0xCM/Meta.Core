//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;
    using SqlT.Core;

    using static metacore;


    /// <summary>
    /// Describes the movement of a logical backup file to a physical file during the course
    /// of restoring a database
    /// </summary>
    public class RestorationMovement
    {

        public RestorationMovement() { }

        public RestorationMovement(SqlFileName MoveFrom, FilePath MoveTo)
        {
            this.MoveFrom = MoveFrom;
            this.MoveTo = MoveTo;
        }

        /// <summary>
        /// The logical source file name
        /// </summary>
        public SqlFileName MoveFrom { get; set; }

        /// <summary>
        /// The physical destination path
        /// </summary>
        public FilePath MoveTo { get; set; }

    }

    public class RestoreDatabase
    {
        public RestoreDatabase()
        {

        }

        public RestoreDatabase(FilePath SourceFile, SqlDatabaseName TargetDatabase, params RestorationMovement[] Movements)
        {
            this.SourceFile = SourceFile;
            this.TargetDatabase = TargetDatabase;
            this.Movements = Movements;
        }


        /// <summary>
        /// The server-relative path to the BAK file
        /// </summary>
        public FilePath SourceFile { get; set; }

        /// <summary>
        /// The server-relative name of the destination database
        /// </summary>
        public SqlDatabaseName TargetDatabase { get; set; }

        /// <summary>
        /// specifies the physical destinations of the logical files in the backup set
        /// </summary>
        public IReadOnlyList<RestorationMovement> Movements { get; set; }


    }
}