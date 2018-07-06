create table [MC].[ProjectVariableDefinition]
(
 	StoreKey bigint not null 
		constraint DF_ProjectVariable_SystemKey default(next value for [SqlStore].[StoreKeySequence]),
	ProjectId nvarchar(75) not null,
	VariableName nvarchar(75) not null,
	VariableValue nvarchar(1024) not null,
	CreateTS datetime2(0) not null 
		constraint DF_ProjectVariable_CreateTS default(getdate()),
	UpdateTS datetime2 (0) null,

	constraint PK_ProjectVariable primary key(StoreKey),
	constraint UQ_ProjectVariable unique(ProjectId,VariableName),
	--constraint FK_ProjectVariable_PlatformProject foreign key(ProjectId)
	--	references [MC].[PlatformProjectRegistry](ProjectId)

)
GO
create trigger [MC].[ProjectVariableUpdated] 
	on [MC].[ProjectVariableDefinition] after update as
		update [MC].[ProjectVariableDefinition] set 
			UpdateTS = getdate()
	from 
		[MC].[ProjectVariableDefinition] x 
			inner join inserted on 
				inserted.StoreKey = x.StoreKey


	
