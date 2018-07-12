create function [PF].[PlatformReleases]() returns table as return
	select 
		StreamId = f.stream_id, 
		[FileName] = f.[name], 
		FileType = f.file_type,
		FileSize = f.cached_file_size, 
		ReceivedTime = f.creation_time,
		LastWriteTime = f.last_write_time,
		PathLocator = f.path_locator,
		ParentPathLocator = f.parent_path_locator,
		UncPath = FileTableRootPath() + f.file_stream.GetFileNamespacePath()
	from 
		[PF].[SystemDistribution] f
	where 
		is_directory = 0
	
