create function [PF].[HostFiles](@SrcPath nvarchar(4000), @Filter nvarchar(250) = null)
	returns table as return
	select 
		HostId = (select top(1) NodeId from  [PF].[ExecutingNode]),
		FilePath, 
		CreateTS = CreationTime, 
		UpdateTS = LastWriteTime,
		Size,
		SizeMB = cast(Size/1000000.0000 as decimal(19,4)),
		SizeGB = cast(Size/1000000000.0000 as decimal(19,4))
	from 
		SqlT.Dir(@SrcPath, @Filter)
	where
		IsDirectory = 0
GO

exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[T0].[HostFileInfo]',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'FUNCTION',
    @level1name = N'HostFiles',
    @level2type = NULL,
    @level2name = NULL
	
