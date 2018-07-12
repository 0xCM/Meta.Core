create table [PF].[MessageFormatArchive]
(
  	SystemKey int not null, 
	SchemaName nvarchar(128) not null,
	TypeName nvarchar(128) not null,
	FormatTemplate nvarchar(250) not null,
	P1 nvarchar(20) null,
	P2 nvarchar(20) null,
	P3 nvarchar(20) null,
	P4 nvarchar(20) null,
	P5 nvarchar(20) null,
	P6 nvarchar(20) null,
	P7 nvarchar(20) null,
	P8 nvarchar(20) null,
	P9 nvarchar(20) null,
 	ArchiveTS datetime2(0) not null 
		constraint DF_MessageFormat_ArchiveTS default(getdate()),
	UpdateTS datetime2 (0) null,	
	constraint PK_MessageFormatArchive primary key(SystemKey),


)
	
GO

