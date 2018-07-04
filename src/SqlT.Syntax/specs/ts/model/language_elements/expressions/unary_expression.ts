// See: https://docs.microsoft.com/en-us/sql/t-sql/language-elements/expressions-transact-sql
namespace expressions {

    export type unary_expression = 
        op.unary_operator & c.expression

}        