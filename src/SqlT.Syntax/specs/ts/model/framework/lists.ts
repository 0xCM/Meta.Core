
type ZeroOrOne = "0..1"
type ZeroToMany = "0..*"
type OneToMany = "1..*"

type Cardinality =
    | a.Zero
    | a.One
    | ZeroOrOne
    | ZeroToMany
    | OneToMany
    
type ordered_list<T> = Cardinality & T[] 
type zero_or_more<T> = ZeroToMany & T[]
type one_or_more<T> = OneToMany & T[]
type zero_or_one<T> = ZeroOrOne & T[]


