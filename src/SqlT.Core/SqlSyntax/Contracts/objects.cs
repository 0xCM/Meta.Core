//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using Meta.Models;
    using SqlT.Core;

    public static partial class contracts
    {
        public interface element : IModel
        {
            /// <summary>
            /// The name of the element
            /// </summary>
            IName ElementName { get; }
        }

        public interface element<n> : element, IModel<n>
            where n : IName, new() { }

        public interface sql_object : element { }

        public interface sql_object<n> : sql_object, element<n>
            where n : ISqlObjectName, new() { }

        public interface table : sql_object<SqlTableName> { }

        public interface file_table : table { }

        public interface constraint : sql_object { }

        public interface constraint<n> : constraint, sql_object<n>
            where n : SqlConstraintName<n>, new() { }

        public interface default_constraint : constraint<SqlDefaultConstraintName> { }

        public interface foreign_key : constraint<SqlForeignKeyName> { }

        public interface unique_constraint : constraint<SqlUniqueConstraintName> { }

        public interface primary_key : constraint<SqlPrimaryKeyName> { }

        public interface function : sql_object<SqlFunctionName> { }

        public interface function<v> : function { }

        public interface scalar_function : function { }

        public interface scalar_function<r> : scalar_function, function<r>
            where r : scalar_type { }

        public interface aggregate_function : function { }

        public interface native_function : function, native_model { }

        public interface native_function<v> : native_function, function<v> { }

        interface ranking_windowed_function : function { }

        public interface native_scalar_function : native_function, scalar_function { }

        public interface native_scalar_function<r> : native_scalar_function, scalar_function<r>, native_function<r>
            where r : scalar_type { }

        public interface rowset_function : function, rowset_provider { }

        public interface table_function : function, rowset_provider { }

        public interface table_function<v> : table_function, function<v>, rowset_provider<v> { }

        public interface procedure : sql_object<SqlProcedureName> { }

        public interface procedure<r> : procedure, rowset_provider<r> { }

        public interface native_procedure : procedure, native_model { }

    }

}