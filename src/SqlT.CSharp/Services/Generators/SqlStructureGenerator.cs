//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.CSharp
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;
    using static metacore;

    using static ClrStructureSpec;

    class SqlStructureGenerator : ApplicationService<SqlStructureGenerator, ISqlStructureGenerator>, ISqlStructureGenerator
    {
        public SqlStructureGenerator(IApplicationContext C)
            : base(C)
        { }

        IReadOnlyList<FilePath> EmitStructures(SqlMetadataStructureProfile gp, IEnumerable<ClassSpec> structures )
        {
            var usings = gp.SpecifyUsings();
            var nsname = gp.SpecifyNamespaceName();
            var ns = new NamespaceSpec(nsname, structures, usings);
            var filespec = gp.SpecifyCodeFile(gp.Name, ns, true);
            return gp.Emit(array(filespec));

        }

        public IReadOnlyList<FilePath> GenerateDatabaseStructures(SqlMetadataStructureProfile gp, IEnumerable<SqlDatabaseName> databases)
        {
            var structures = databases.SpecifySqlStructures(gp);
            return EmitStructures(gp, structures);
        }

        public IReadOnlyList<FilePath> GenerateTableStructures(SqlMetadataStructureProfile gp, IEnumerable<SqlTableName> objects)
        {
            var structures = objects.SpecifySqlStructures(gp);
            return EmitStructures(gp, structures);
        }

        public IReadOnlyList<FilePath> GenerateMessageTypeStructures(SqlMetadataStructureProfile gp, IEnumerable<SqlMessageTypeName> objects)
        {
            var structures = objects.SpecifySqlStructures(gp);
            return EmitStructures(gp, structures);
        }

    }
}
