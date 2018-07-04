select 
	dbowner = suser_sname(owner_sid) 
from 
	sys.databases 
where 
	[name] = 'XDbName'