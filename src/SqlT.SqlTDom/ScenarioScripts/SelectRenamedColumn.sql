SELECT max_degree_of_parallelism 
	= [value] 
from sys.configurations 
where 
	name = 'max degree of parallelism' 