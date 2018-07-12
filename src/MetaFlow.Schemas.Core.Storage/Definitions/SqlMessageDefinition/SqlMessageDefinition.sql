create table [PF].[SqlMessageDefinition]
(
	MessageNumber int not null, 
	SystemId nvarchar(75) not null,
	MessageName nvarchar(75) not null,
	Severity int not null,
	FormatString nvarchar(255) not null,	
	CreateTS datetime2(0) 
		constraint DF_SqlMessageDefinition_CreateTS default(getdate()),
	UpdateTS datetime2 (0) null,

	constraint PK_SqlMessageDefinition primary key(SystemId,MessageName)

)
GO
create trigger [PF].[SqlMessageDefinitionUpdated] 
	on [PF].[SqlMessageDefinition] after update as
		update [PF].[SqlMessageDefinition] set 
			UpdateTS = getdate()
	from 
		[PF].[SqlMessageDefinition] x 
			inner join inserted on 
				inserted.MessageNumber = x.MessageNumber

