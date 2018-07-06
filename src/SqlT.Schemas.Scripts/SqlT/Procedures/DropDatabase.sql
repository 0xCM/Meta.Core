CREATE PROCEDURE [SqlT].[DropDatabase](@DbName sysname) as
	exec('alter database [' + @DbName + '] set offline with rollback immediate')
	exec('DROP database [' + @DbName + ']')

