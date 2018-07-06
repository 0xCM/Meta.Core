create function CommandExec.ParseCommandArguments(@ArgumentJson nvarchar(max)) returns table as return
	select * from openjson(@ArgumentJson)
		with
		(
			ArgName nvarchar(75) '$.Name',
			ArgValue nvarchar(250) '$.Value'
		)
GO
