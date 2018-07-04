//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    public static partial class contracts
    {
        public interface column_name : ISimpleSqlName { }

        public interface ISqlObjectName : ICompositeSqlName
        {

            bool IsSystemObject { get; }

            string ServerNamePart { get; }

            string DatabaseNamePart { get; }

            string SchemaNamePart { get; }

            string UnqualifiedName { get; }

            bool quoted { get; }
        }

        public interface tabular_name : ISqlObjectName { }

        public interface type_name : ISqlObjectName { }

        public interface sequence_name : ISqlObjectName { }

    }

}