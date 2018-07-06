create procedure SqlTest.pTable03Insert(
	@Col01 tinyint, 
	@Col02 smallint, 
	@Col03 int, 
	@Col04 bigint
) as
	insert 
		SqlTest.Table03(Col01, Col02, Col03, Col04) 
	values 
		(@Col01, @Col02, @Col03, @Col04)
	
	--Return the value inserted into the identity column
	return scope_identity();	