create procedure [SqlT].[DescribeBackup](@BackupPath nvarchar(256)) as
	restore filelistonly from disk = @BackupPath
GO

EXEC sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[SqlT].[BackupDescription]',
    @level0type = N'SCHEMA',
    @level0name = N'SqlT',
    @level1type = N'PROCEDURE',
    @level1name = N'DescribeBackup'
GO


