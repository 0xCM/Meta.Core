//https://docs.microsoft.com/en-us/sql/t-sql/data-types/constants-transact-sql
namespace expressions {

    export abstract class literal_expression<t> implements c.literal_expression
    {
        protected constructor(value : t)
        {
            this.literal_value = value
        }

        readonly literal_value : t
    }

    export class date_literal extends literal_expression<Date>
    {
        constructor(value : Date)
        {
            super(value);
        }
    }

    

    
    export class binary_literal
        implements c.literal_expression { }

    export class bit_literal
        implements c.literal_expression { }

    export class date_time_literal
        implements c.literal_expression { }

    export class decimal_literal
        implements c.literal_expression { }

    export class float_literal
        implements c.literal_expression { }

    export class integer_literal
        implements c.literal_expression { }

    export class string_literal
        implements c.literal_expression { }

    export class money_literal
        implements c.literal_expression { }

    export class time_literal
        implements c.literal_expression { }

    export class uniqueidentifier_literal
        implements c.literal_expression { }

    export type constant =
        binary_literal
        | bit_literal
        | date_literal
        | date_time_literal
        | decimal_literal
        | float_literal
        | integer_literal
        | string_literal
        | money_literal
        | string_literal
        | time_literal
        | uniqueidentifier_literal;    
}