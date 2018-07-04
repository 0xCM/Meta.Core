CREATE PROCEDURE [Core].[RestoreDatabase] as

restore database [$(DbName)] from disk ='$(BackupPath)'
with
	move '$(LogicalDataFileName)' to '$(DataFilePath)',
	move '$(LogicalLogFileName)' to '$(LogFilePath)',
	stats = 10;