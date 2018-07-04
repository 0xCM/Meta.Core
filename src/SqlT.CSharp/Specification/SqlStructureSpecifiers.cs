//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;
    using static metacore;

    using ClrModel;
    using static ClrStructureSpec;
    using static ClrBehaviorSpec;

    static class SqlStructureSpecifiers
    {
        public static SystemUri ToUri(this SqlMessageTypeName message, CodeGenerationProfile gp)
            => new SystemUri("sql:brokeredMessages", "localhost", new SystemUri.PathSegment(string.Join("/", message.UriSegments)));

        public static ClassSpec SpecifySqlStructure(this SqlMessageTypeName message, CodeGenerationProfile gp)
            => message.ToUri(gp).SpecifyStructure();

        public static IEnumerable<ClassSpec> SpecifySqlStructures(this IEnumerable<SqlMessageTypeName> messages, CodeGenerationProfile gp)
            => messages.Select(x => x.SpecifySqlStructure(gp));

        public static IEnumerable<ClassSpec> SpecifySqlStructures(this IEnumerable<SqlDatabaseName> databases, CodeGenerationProfile gp)
        {
            var dbFields = new List<FieldSpec>();
            foreach (var serverIndex in databases.GroupBy(x => x.ServerName.UnqualifiedName))
            {
                var fields = new List<FieldSpec>();
                var serverClassName = new ClrClassName(serverIndex.Key);
                foreach (var db in serverIndex)
                {
                    var init = db.SpecifyConstructorInvocation();
                    var dbField = serverClassName.SpecifyField<SqlDatabaseName>(db.UnqualifiedName, init);
                    dbFields.Add(dbField);
                    fields.Add(dbField);
                }
                yield return new ClassSpec(serverClassName, Members: fields);
            }

            yield return new ClassSpec("Databases", Members: dbFields);

        }

        public static IEnumerable<ClassSpec> SpecifySqlStructures(this IEnumerable<SqlTableName> objects, CodeGenerationProfile gp)
        {            
            foreach(var serverIndex in objects.GroupBy(x => x.ServerName))
            {
                var serverClassName = new ClrClassName(serverIndex.Key.UnqualifiedName);
                var dbClasses = new List<ClassSpec>();
                foreach (var dbIndex in serverIndex.GroupBy(x => x.DatabaseName.UnqualifiedName))
                {
                    var dbClassName = new ClrClassName(dbIndex.Key);

                    var schemaClasses = new List<ClassSpec>();
                    foreach (var schemaIndex in dbIndex.GroupBy(x => x.SchemaName.UnqualifiedName))
                    {
                        var schemaClassName = new ClrClassName(schemaIndex.Key);
                        var fields = new List<FieldSpec>();
                        foreach (var schemaObject in schemaIndex)
                        {

                            var init = schemaObject.SpecifyConstructorInvocation();
                            var field = schemaClassName.SpecifyField<SqlTableName>(schemaObject.UnqualifiedName, init);
                            fields.Add(field);
                            fields.Add(field);
                        }

                        schemaClasses.Add(new ClassSpec(schemaClassName, Members: fields));                        
                    }

                    dbClasses.Add(new ClassSpec(dbClassName, DeclaredTypes: schemaClasses));
                   
                }
                yield return new ClassSpec(serverClassName, DeclaredTypes: dbClasses);
            }                        
        }

    }




}