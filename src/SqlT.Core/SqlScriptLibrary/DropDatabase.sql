create procedure [Core].[DropDatabase] as
	IF EXISTS (SELECT 1 FROM [sys].[databases] WHERE [name] = '$(DbName)') 
	BEGIN
		alter database [$(DbName)] set read_write;
		alter database [$(DbName)] set single_user with rollback immediate;
		drop database [$(DbName)]
	END
