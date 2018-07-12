create table [PF].[DatabaseVersionStore]
(
	VersionKey int not null 
		constraint DF_PlatformDatabaseVersion_VersionKey 
			default(next value for [PF].[SystemKeySequence]),	
	DatabaseName nvarchar(128) not null,
	MajorVersion int not null,
	MinorVersion int not null,
	BuildVersion int not null,
	RevisionVersion int not null,
	BuildTS datetime2(0) not null,
	EffectiveDate datetime2 (0) generated always as row start not null,
	ExpirationDate datetime2 (0) generated always as row end not null,
	period for system_time (EffectiveDate, ExpirationDate),

	constraint PK_DatabaseVersion primary key(VersionKey),
	constraint UQ_DatabaseVersion
		unique(DatabaseName, MajorVersion, MinorVersion, BuildVersion, RevisionVersion)
) 
with (system_versioning = on(history_table = 
	[PF].[PlatformDatabaseVersionHistory], data_consistency_check=ON))
GO
