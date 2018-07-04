//See: https://docs.microsoft.com/en-us/sql/t-sql/functions/ranking-functions-transact-sql
//See: https://docs.microsoft.com/en-us/sql/t-sql/functions/aggregate-functions-transact-sql
module functions {

    export type DEFAULT = "DEFAULT";
    export type DENSE_RANK = "DENSE_RANKE"
    export type NTILE = "NTILE"
    export type ROW_NUMBER = "ROW_NUMBER"

    export type ranking_window_function =
        | DENSE_RANK
        | NTILE
        | ROW_NUMBER
        | DEFAULT

    export type AVG = "AVG"
    export type CHECKSUM_AGG = "CHECKSUM_AGG"
    export type COUNT = "COUNT";
    export type COUNT_BIG = "COUNT_BIG";
    export type GROUPING = "GROUPING"
    export type GROUPING_ID = "GROUPING_ID"
    export type MAX = "MAX"
    export type MIN = "MIN"
    export type SUM = "SUM"
    export type STDDEV = "STDDEV"
    export type STDDEVP = "STDDEVP"
    export type VAR = "VAR"
    export type VARP = "VARP"

    export type aggregate_window_function =
        | AVG
        | CHECKSUM_AGG
        | COUNT
        | COUNT_BIG
        | GROUPING
        | GROUPING_ID
        | MAX
        | MIN
        | SUM
        | STDDEV
        | STDDEVP
        | VAR
        | VARP

    export type native_window_function =
        | aggregate_window_function
        | ranking_window_function
}