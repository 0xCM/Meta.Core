create procedure [SqlDocs].[SyncMarkdownFiles](@SegmentName nvarchar(75), @Descriptions [SqlDocs].[MarkdownFileInfo] readonly) as
	
	declare @LoadTS datetime2(0)  = getdate();
	
	with Dst as
	(
		select
			*
		from
			[SqlDocs].[MarkdownFile]
		where
			SegmentName = @SegmentName
	)
	merge into Dst using @Descriptions as Src
		on Src.FileLocation = Dst.FileLocation
	when not matched then insert
	(
		SegmentName,
		DocumentTitle,
		FileLocation,
		ModifiedDate,
		FileSize,
		CreateTS
	)
	values
	(
		Src.SegmentName,
		Src.DocumentTitle,
		Src.FileLocation,
		Src.ModifiedDate,
		Src.FileSize,
		@LoadTS
	)
	when matched and not exists
	(
		select
			Src.SegmentName,
			Src.DocumentTitle,
			Src.ModifiedDate,
			Src.FileSize

		intersect

		select
			Dst.SegmentName,
			Dst.DocumentTitle,
			Dst.ModifiedDate,
			Dst.FileSize

	)
	then update set
		Dst.SegmentName = Src.SegmentName,
		Dst.DocumentTitle = Src.DocumentTitle,
		Dst.ModifiedDate = Src.ModifiedDate,
		Dst.FileSize = Src.FileSize,
		Dst.UpdateTS = @LoadTS
	when not matched by source then delete;

