## Metagloss

### A

### B


### C

##### Chain
The result (or action) of concatenating the content of two or more
[container](#Container) instances over the same underlying type.

##### Combinator (Pattern)
A complexity control device that leverages swarms of relatively simple 
constructs to produce a structure of higher complexity or accomplish 
a more involved goal. 

##### Container
A data structure that contains zero or more elements of either 
homogenous or heterogeneous type. Note that this definition characterizes 
common collection types such as lists and trees as *containers* but does 
not exclude data  structures - such as tuples and records - that are not
generally considered to be "containers".

##### Computational Context
An homogenous [container](#Container) C over a specified type X,
denoted C[X].

### E

##### Equator
A function that determines whether two elements of the same type are
identical. A *canonical* equauator for a given type **X** is specified
by a boolean binary function: **X** -> **X** -> *true* | *false*

### F

##### Factored Container

A [container](#Container) that holds values of types structurally 
isomorphic to *n*-tuples. For example, a list of 2-tuples of string/integer 
pairs is a container factored over (string,string). Similarly, an associative
array that correlates keys of type K with values of type V 
is a factored container over (K,V). The case where n=1 is considered
degenerate and uninteresting since the resulting container
is identical to an unfactored container.

### L

##### Lift
To raise a base value of type X into a context C[X] over X by some
function **X -> C[X]**

##### Type Constructor

A function that, given types C and X, produces a new type C[X]
