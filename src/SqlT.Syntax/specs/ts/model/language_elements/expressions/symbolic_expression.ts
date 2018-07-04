// See: https://docs.microsoft.com/en-us/sql/t-sql/language-elements/expressions-transact-sql
namespace expressions {

    import a = atoms

    export type single_quoted<t> = [a.single_quote, t, a.single_quote]
    export type double_quoted<t> = [a.double_quote, t, a.double_quote]
    export type bracketed<t> = [a.left_bracket, t, a.right_bracket]
    export type parenthetical<t> = [a.left_paren, t , a.right_paren]
    export type comparison<t> = [t, op.comparison_operator, t]
}