create procedure [MC].[StoreXsdDocuments](@Documents [MC].[XsdDocument] readonly) as

	merge into [MC].[XsdDocumentStore] as Dst
		using @Documents as Src on
			Dst.SourcePath = Src.SourcePath
		when not matched then insert
		(
			SourcePath,
			DocumentName,
			Processed,
			ProcessingError,
			XmlContent
		)
		values
		(
			Src.SourcePath,
			Src.DocumentName,
			Src.Processed,
			Src.ProcessingError,
			Src.XmlContent
		)
		when matched and not exists
		(
			select 
			
			Src.SourcePath,
			Src.Processed,
			Src.ProcessingError,
			cast(Src.XmlContent as nvarchar(max))

			intersect

			select 

			Dst.SourcePath,
			Dst.Processed,
			Dst.ProcessingError,
			cast(Dst.XmlContent as nvarchar(max))
		)
		then update set
			Dst.SourcePath = Src.SourcePath,
			Dst.XmlContent = Src.XmlContent,
			Dst.Processed = Src.Processed,
			Dst.ProcessingError = Src.ProcessingError,
			Dst.UpdateTS = getdate();

