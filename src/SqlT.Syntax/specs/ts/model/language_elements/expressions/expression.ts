// See: https://docs.microsoft.com/en-us/sql/t-sql/language-elements/expressions-transact-sql
namespace expressions {
    
    import f = functions;

    const expresssion_syntax = `{ 
        constant 
        | scalar_function 
        | [ table_name. ] column 
        | variable   
        | ( expression ) 
        | ( scalar_subquery )   
        | { unary_operator } expression   
        | expression { binary_operator } expression   
        | ranking_windowed_function 
        | aggregate_windowed_function  
    }  `

    export class variable 
        implements c.expression {}

    export class scalar_subquery 
        implements c.expression {}

    export class scalar_function {}

    export type expression =
        constant
        | scalar_function
        | column_name
        | variable
        | parenthetical_expression
        | subquery_expression
        | unary_expression
        | binary_expression
        | f.ranking_window_function
        | f.aggregate_window_function







}