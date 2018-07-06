CREATE PROCEDURE [SqlT].[GoOffline](@DbName sysname) as
	exec('ALTER DATABASE [' + @DbName + '] SET OFFLINE WITH ROLLBACK IMMEDIATE')


