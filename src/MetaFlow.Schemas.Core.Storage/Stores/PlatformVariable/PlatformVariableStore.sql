create table [PF].[PlatformVariableStore]
(
	SystemKey bigint not null 
		constraint DF_PlatformVariable_SystemKey 
			default(next value for [PF].[SystemKeySequence]),
	VariableName nvarchar(75) not null,
	VariableValue nvarchar(1024) not null,
	CreateTS datetime2(0) not null
		constraint  DF_PlatformVariable_CreateTS default(getdate()),
	UpdateTS datetime2(0) null,
	constraint PK_PlatformVariable primary key(SystemKey),
	constraint UQ_PlatformVariable unique(VariableName)
)
GO
