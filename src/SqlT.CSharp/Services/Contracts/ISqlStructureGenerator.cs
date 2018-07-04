//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.CSharp
{
    using System.Collections.Generic;
    using SqlT.Core;

    using GP = Core.SqlMetadataStructureProfile;
    public interface ISqlStructureGenerator : ICSharpGenerator
    {
        IReadOnlyList<FilePath> GenerateTableStructures(GP gp, IEnumerable<SqlTableName> tables);
        IReadOnlyList<FilePath> GenerateDatabaseStructures(GP gp, IEnumerable<SqlDatabaseName> databases);
        IReadOnlyList<FilePath> GenerateMessageTypeStructures(GP gp, IEnumerable<SqlMessageTypeName> messageTypes);
    }

}
