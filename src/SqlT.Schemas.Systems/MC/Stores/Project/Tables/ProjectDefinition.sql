create table [MC].[ProjectDefinition]
(
 	StoreKey int not null
		constraint DF_ProjectDefinition_StoreKey 
			default(next value for [SqlStore].[StoreKeySequence]),

	AreaId nvarchar(75) not null,
	SystemId nvarchar(75) not null,
	ProjectId nvarchar(75) not null,
	ProjectName nvarchar(250) not null,
	ProjectType nvarchar(75) not null,

	CreateTS datetime2(0) not null
		constraint DF_ProjectDefinition_CreateTS default(getdate()),	
	UpdateTS datetime2(0) null,

	constraint FK_ProjectDefinition_DevArea foreign key(AreaId)
		references [MC].[DevArea](Identifier),
	
	constraint FK_ProjectDefinition_DevSystem foreign key(SystemId)
		references [MC].[DevSystem](Identifier),
	
	constraint FK_ProjectDefinition_ProjectType foreign key(ProjectType)
		references [MC].[ProjectType](Identifier),

	
	constraint PK_ProjectDefinition primary key(StoreKey),
	constraint UQ_ProjectDefinition unique(ProjectId)

)
	
