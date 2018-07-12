create type [T0].[PlatformDacRegistration] as table
(
	SystemId nvarchar(75) not null,
	PackageName nvarchar(75) not null,
   	ComponentId nvarchar(75) not null,
	ComponentVersion nvarchar(75) not null,
	ComponentTS datetime2(0) not null

)
	
