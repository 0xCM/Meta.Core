create function [PF].[XEventDataBlocks](@SrcFile nvarchar(500), @MaxCount int = 500, @MinOffset int = 0) returns table as return
	select top(@MaxCount)

		[object_name],
		[file_name] = @SrcFile,
		[file_offset],
		[event_data] = cast(event_data as xml)
	from 
		sys.fn_xe_file_target_read_file(@SrcFile, null, null, null)
	where 
		[file_offset] >= @MinOffset
	order by 
		[file_offset]
GO


exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[PF].[XEventDataBlock]',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'FUNCTION',
    @level1name = N'XEventDataBlocks',
    @level2type = NULL,
    @level2name = NULL
GO
