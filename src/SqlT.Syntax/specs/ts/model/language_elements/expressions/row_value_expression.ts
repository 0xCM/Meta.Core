// See: https://docs.microsoft.com/en-us/sql/t-sql/language-elements/expressions-transact-sql
namespace expressions {

    export type row_value_expression = 
        | kw.DEFAULT
        | kw.NULL
        | expression

    export type row_value_expression_list = 
        one_or_more<row_value_expression>
    

}