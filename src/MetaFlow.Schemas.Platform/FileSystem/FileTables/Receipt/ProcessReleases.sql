create procedure [PF].[ProcessReleases](@streamIds [T0].[FileStreamIdentifier] readonly)
as	
    insert [PF].[ReceivedFile]
	(
		FileId,
		[FileName],
		[FileSize],
		[ReceivedTime],
		[LastWriteTime],
		[ReceiptPath]
	)
    select 
		FileId = ft.stream_id,
		[FileName] = ft.[name],
		FileSize = cached_file_size, 
		ReceivedTime = creation_time,
		LastWriteTime = last_write_time,
		ReceiptPath = FileTableRootPath() + file_stream.GetFileNamespacePath()			
    from 
		@streamIds tvp
		 inner join [PF].[SystemDistribution] ft 
			on tvp.stream_id=ft.stream_id
	where
		ft.is_directory = 0            
