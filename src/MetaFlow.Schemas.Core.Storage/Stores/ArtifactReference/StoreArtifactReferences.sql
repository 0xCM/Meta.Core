create procedure [PF].[StoreArtifactReferences](@Specs [T0].[ArtifactReferenceSpec] readonly) as
	merge into [PF].[ArtifactReferenceStore] as Dst
		using @Specs as Src on
			Src.SpecFileName = Dst.SpecFileName
		when not matched then insert
		(
			SpecFileName,
			SpecLabel,
			AreaName,
			SectionName,
			ReferenceType,
			SpecContent
		)
		values
		(

			Src.SpecFileName,
			Src.SpecLabel,
			Src.AreaName,
			Src.SectionName,
			Src.ReferenceType,
			Src.SpecContent
		)
		when matched and not exists	
		(
			select
				Src.SpecLabel,
				Src.AreaName,
				Src.SectionName,
				Src.ReferenceType,
				Src.SpecContent

			intersect 

			select
				Dst.SpecLabel,
				Dst.AreaName,
				Dst.SectionName,
				Dst.ReferenceType,
				Dst.SpecContent
		)
		then update set
			Dst.SpecLabel = Src.SpecLabel,
			Dst.AreaName = Src.AreaName,
			Dst.SectionName = Src.SectionName,
			Dst.ReferenceType = Src.ReferenceType,
			Dst.SpecContent = Src.SpecContent;

	
