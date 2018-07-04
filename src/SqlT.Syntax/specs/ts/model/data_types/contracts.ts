namespace c
{
    export interface data_type
        extends syntax_model { }

    export interface native_type
        extends data_type { }    

    export interface chronology_type
        extends data_type { }

    export interface numeric_type
        extends data_type { }

    export interface sqlclr_type
        extends data_type{ }
    
    export interface date_type
        extends chronology_type,
            native_type { }

    export interface time_type
        extends chronology_type,
            native_type { }

    export interface datetime_type
        extends chronology_type,
            native_type { }

    export interface datetime2_type
        extends chronology_type,
            native_type { }

    export interface datetimeoffset_type
        extends chronology_type,
            native_type { }

    export interface integer_type
        extends numeric_type { }

    export interface bit_type
        extends integer_type,
            native_type { }

    export interface int_type
        extends integer_type,
            native_type { }

    export interface bigint_type
        extends integer_type,
            native_type { }

    export interface tinyint_type
        extends integer_type,
            native_type { }

    export interface smallint_type
        extends integer_type,
            native_type { }

    export interface fractional_type
        extends numeric_type{ }

    export interface precise_fractional_type
        extends fractional_type{ }

    export interface floating_fractional_type
        extends fractional_type{ }

    export interface decimal_type
        extends precise_fractional_type, native_type{ }

    export interface float_type
        extends floating_fractional_type,
            native_type{ }

    export interface real_type
        extends floating_fractional_type,
            native_type{ }

    export interface text_type
        extends data_type { }

    export interface unicode_text_type
        extends text_type{ }

    export interface ansi_text_type
        extends text_type{ }

    export interface variable_length_text_type
        extends text_type{ }

    export interface fixed_length_text_type
        extends text_type{ }

    export interface nvarchar_type
        extends unicode_text_type,
            variable_length_text_type,
            native_type { }

    export interface varchar_type
        extends ansi_text_type,
            variable_length_text_type,
            native_type { }

    export interface nchar_type
        extends unicode_text_type,
            fixed_length_text_type,
            native_type { }

    export interface char_type
        extends ansi_text_type,
            fixed_length_text_type,
            native_type { }
    
    export interface currency_type
        extends data_type { }

    export interface smallmoney_type
        extends currency_type,
            native_type{ }

    export interface money_type
        extends currency_type,
            native_type{ }


}