create type [T0].[DatabaseVersion] as table
(
	DatabaseName nvarchar(128) not null,
	MajorVersion int not null,
	MinorVersion int not null,
	BuildVersion int not null,
	RevisionVersion int not null,
	BuildTS datetime2(0) not null
)
GO
