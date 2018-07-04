//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using SqlT.Core;
    using System.Collections;
    using System.Collections.Generic;

    using Meta.Models;
    using Meta.Syntax;


    public static partial class contracts
    {
        public interface from_clause : clause
        {

        }

        public interface dboption : IModel
        {

        }

        public interface rowset_provider
        {

        }

        public interface rowset_provider<t> : rowset_provider
        {

        }

        public interface formattable
        {
            string FormatSyntax();
        }

        public interface augmentation : IModel
        {
            IModel subject { get; }

            IEnumerable<IModel> additions { get; }
        }

        public interface parameter_declaration : IModel<SqlParameterName>
        {            
            data_type_ref parameter_type { get; }
        }

        public interface parameter_declaration<r> : parameter_declaration
            where r : data_type_ref
        {
            new r parameter_type { get; }
        }

        public interface variable_declaration : IModel<SqlVariableName>
        {

            data_type_ref variable_type { get; }
        }

     
        public interface variable_declaration<r> : variable_declaration
            where r : data_type_ref
        {
            new r variable_type { get; }
        }

        public interface routine_argument_list : IModelList<routine_argument>
        {

        }

        public interface keyword_list : IModelList<IKeyword>
        {

        }

        public interface variable : IModel
        {
            SqlVariableName name { get; }

        }


        public interface scalar_variable : variable
        {

        }   

        public interface native_model : IModel
        {

        }
       

        public interface table_source : IModel
        {

        }

        public interface column_name_provider : IModel
        {
            IReadOnlyList<SqlColumnName> ColumnNames { get; }
        }

    }

}
