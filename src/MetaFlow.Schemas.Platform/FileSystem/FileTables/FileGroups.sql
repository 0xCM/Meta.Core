/*
Do not change the database path or name variables.
Any sqlcmd variables will be properly substituted during 
build and deployment.
*/
ALTER DATABASE [$(DatabaseName)]
	ADD FILEGROUP [MetaFlowShare] contains filestream 
GO

ALTER DATABASE [$(DatabaseName)]
    ADD FILE 
		(NAME = MetaFlowShare_Data, 
			FILENAME = '$(DefaultDataPath)$(DefaultFilePrefix).MetaFlowShare.mdf') 
		to filegroup [MetaFlowShare];
