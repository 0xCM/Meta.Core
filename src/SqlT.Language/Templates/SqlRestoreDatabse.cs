//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{
    using System;
    using System.Collections.Generic;

    using SqlT.Core;
    using SqlT.Syntax;
    using SqlT.Models;

    using static metacore;

    /// <summary>
    /// Represents the intent to restore a database from a BAK file
    /// </summary>
    public class SqlRestoreDatabase : SqlCommandAction<SqlRestoreDatabase>
    {
        public class Move : ValueObject<Move>
        {
            /// <summary>
            /// The logical source file name
            /// </summary>
            public readonly string MoveFrom;

            /// <summary>
            /// The physical destination path
            /// </summary>
            public readonly FilePath MoveTo;

            public Move(string MoveFrom, FilePath MoveTo)
            {
                this.MoveFrom = MoveFrom;
                this.MoveTo = MoveTo;
            }
        }


        public SqlRestoreDatabase(FilePath SourceFile, SqlDatabaseName DatabaseName, params Move[] Movements)
            : base(nameof(SqlRestoreDatabase))
        {
            this.SourceFile = SourceFile;
            this.DatabaseName = DatabaseName;
            this.Movements = rovalues(Movements);
        }

        /// <summary>
        /// The server-relative path to the BAK file
        /// </summary>
        [SqlTemplateParameter]
        public FilePath SourceFile { get; private set; }

        /// <summary>
        /// The server-relative name of the destination database
        /// </summary>
        [SqlTemplateParameter]
        public SqlDatabaseName DatabaseName { get; private set; }

        /// <summary>
        /// specifies the physical destinations of the logical files in the backup set
        /// </summary>
        [SqlTemplateParameter]
        public IReadOnlyList<Move> Movements { get; private set; }
    }

}
