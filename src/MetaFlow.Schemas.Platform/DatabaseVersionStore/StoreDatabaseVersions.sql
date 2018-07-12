create procedure [PF].[StoreDatabaseVersions](@Records [T0].[DatabaseVersion] readonly) as
	merge into [PF].[DatabaseVersionStore] as Dst
		using @Records as Src on
			Dst.DatabaseName = Src.DatabaseName
		and Dst.MajorVersion = Src.MajorVersion
		and Dst.MinorVersion = Src.MinorVersion
		and Dst.BuildVersion = Src.BuildVersion
		and Dst.RevisionVersion = Src.RevisionVersion
	when not matched then insert
	(
		DatabaseName,
		MajorVersion,
		MinorVersion,
		BuildVersion,
		RevisionVersion,
		BuildTS
	)
	values
	(

		Src.DatabaseName,
		Src.MajorVersion,
		Src.MinorVersion,
		Src.BuildVersion,
		Src.RevisionVersion,
		Src.BuildTS
	)
	when matched and not exists
	(
		select
			Src.BuildTS

		intersect

		select
			Dst.BuildTS
	)
	then update set
		Dst.BuildTS = Src.BuildTS;
GO

