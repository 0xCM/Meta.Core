EXEC sp_addmessage 
	@msgnum = 125000, 
	@severity = 11, 
	@msgtext =N'%s records for transactions created between %s and %s already exist.'