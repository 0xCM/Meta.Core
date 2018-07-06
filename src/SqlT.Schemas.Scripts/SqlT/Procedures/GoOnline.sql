CREATE PROCEDURE SqlT.[GoOnline](@DbName sysname) as
	exec('alter database [' + @DbName + '] set online')


