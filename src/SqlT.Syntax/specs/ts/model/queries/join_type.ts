//https://docs.microsoft.com/en-us/sql/t-sql/queries/from-transact-sql 
namespace queries {


   type outer_join_type =
        | kw.LEFT
        | kw.RIGHT
        | kw.FULL

    type join_qualification =
        | kw.INNER
        | outer_join_type

    type join_hint =
        | kw.LOOP
        | kw.HASH
        | kw.MERGE
        | kw.REMOTE

    type join_hint_option = join_hint | null        

    type join_type = 
        [join_qualification, join_hint_option]
        
}