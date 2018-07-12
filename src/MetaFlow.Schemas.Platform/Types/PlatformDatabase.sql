create type [PF].[PlatformDatabase] as table
(
	ServerId nvarchar(75) not null,
	DatabaseName nvarchar(75) not null,
	DatabaseType nvarchar(75) not null,
	IsPrimary bit not null,
	IsEnabled bit not null,
	IsModel bit not null, 
	IsRestore bit not null

)
