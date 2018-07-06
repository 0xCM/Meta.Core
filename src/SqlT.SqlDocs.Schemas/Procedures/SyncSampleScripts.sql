create procedure [SqlDocs].[SyncSampleScripts](@SegmentName nvarchar(75), @Scripts [SqlDocs].[TextFileDescription] readonly) as
	
	declare @LoadTS datetime2(0)  = getdate();
	
	with Dst as
	(
		select
			*
		from
			[SqlDocs].[SampleScript]
		where
			SegmentName = @SegmentName
	)
	merge into Dst using @Scripts as Src
		on Src.SourcePath = Dst.FileLocation
	when not matched then insert
	(
		SegmentName,		
		FileLocation,
		ModifiedDate,
		FileSize,
		ScriptText,
		CreateTS
	)
	values
	(
		Src.SegmentName,
		Src.SourcePath,
		Src.ModifiedDate,
		Src.FileSize,
		Src.FileContent,
		@LoadTS
	)
	when matched and not exists
	(
		select
			Src.SegmentName,
			Src.ModifiedDate,
			Src.FileSize,
			Src.FileContent

		intersect

		select
			Dst.SegmentName,
			Dst.ModifiedDate,
			Dst.FileSize,
			Dst.ScriptText

	)
	then update set
		Dst.SegmentName = Src.SegmentName,
		Dst.ModifiedDate = Src.ModifiedDate,
		Dst.FileSize = Src.FileSize,
		Dst.ScriptText = Src.FileContent,
		Dst.UpdateTS = @LoadTS
	when not matched by source then delete;

