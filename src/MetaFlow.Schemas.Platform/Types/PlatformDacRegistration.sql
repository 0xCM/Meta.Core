create type [PF].[PlatformDacRegistration] as table
(
	SystemId nvarchar(75) not null,
	PackageName nvarchar(75) not null,
	RegisteredVersion nvarchar(75) not null

)
	
