create table [PF].[VirtualDisk]
	as filetable with 
	(
		filetable_directory = 'vhdx',
		filetable_primary_key_constraint_name = PK_VirtualDisk,
		filetable_streamid_unique_constraint_name = UQ_VirtualDisk_StreamId,
		filetable_fullpath_unique_constraint_name = UQ_VirtualDisk_FullPath
	);
