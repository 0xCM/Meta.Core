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

    public static partial class contracts
    {

        

        public interface data_string_type : ISqlType
        {
            bool IsFixedLength { get; }
        }

        public interface numeric_type : scalar_type { }

        public interface text_type : scalar_type, data_string_type { }

        public interface nvarchar_type : text_type { }
       
        public interface scalar_type : ISqlDataType { }

        public interface clr_type : ISqlDataType { }        

        public interface binary_type : scalar_type { }

        public interface fixed_binary_type : binary_type { }

        public interface fixed_text_type : text_type { }

        public interface chronology_type : scalar_type { }

        public interface currency_type : scalar_type {}

        public interface fractional_type : numeric_type { }

        public interface precise_fractional_type : fractional_type { }

        public interface floating_fractional_type : fractional_type { }

        public interface integer_type : numeric_type { }

        public interface int_type : integer_type { }

        public interface native_type : ISqlDataType, native_model{}

    }

}

