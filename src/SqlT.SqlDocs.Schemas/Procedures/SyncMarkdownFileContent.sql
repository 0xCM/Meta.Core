create procedure [SqlDocs].[SyncMarkdownFileContent](@SegmentName nvarchar(75), @Content [SqlDocs].[MarkdownFileContent] readonly) as
	
	declare @LoadTS datetime2(0)  = getdate();
	
	with Dst as
	(
		select
			*
		from
			[SqlDocs].[MarkdownFileContent]
		where
			SegmentName = @SegmentName
	)
	merge into Dst using @Content as Src
		on Src.FileLocation = Dst.FileLocation
	when not matched then insert
	(
		SegmentName,
		FileLocation,
		DocumentTitle,
		ModifiedDate,
		FileSize,
		FileContent,
		CreateTS
	)
	values
	(
		Src.SegmentName,
		Src.FileLocation,
		Src.DocumentTitle,
		Src.ModifiedDate,
		Src.FileSize,
		Src.FileContent,
		@LoadTS
	)
	when matched and not exists
	(
		select
			Src.DocumentTitle,
			Src.ModifiedDate,
			Src.FileSize,
			Src.FileContent

		intersect

		select
			Dst.DocumentTitle,
			Dst.ModifiedDate,
			Dst.FileSize,
			Dst.FileContent

	)
	then update set
		Dst.DocumentTitle = Src.DocumentTitle,
		Dst.ModifiedDate = Src.ModifiedDate,
		Dst.FileSize = Src.FileSize,
		Dst.FileContent = Src.FileContent,
		Dst.UpdateTS = @LoadTS
	when not matched by source then delete;

