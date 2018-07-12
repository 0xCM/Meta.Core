create table [PF].[TypeSystemType]
(
	TypeCode int not null,			
	Identifier nvarchar(75) not null,
	Label nvarchar(75) not null,
	[Description] nvarchar(250) null,
	CreateTS datetime2(0) not null 
		constraint DF_TypeSystem_CreateTS default(getdate()),
	UpdateTS datetime2 (0) null,
	
	constraint PK_TypeSystem primary key(TypeCode),
	constraint UQ_TypeSystem unique(Identifier),
	constraint UQ_TypeSystem_Label unique(Label)


)
GO
