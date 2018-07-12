create table [PF].[MessageFormatDefinition]
(
  	SystemKey int not null 
		constraint DF_MessageFormat_SystemKey default(next value for [PF].[SystemKeySequence]),

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
 	CreateTS datetime2(0) not null 
		constraint DF_MessageFormat_CreateTS default(getdate()),
	UpdateTS datetime2 (0) null,
	
	constraint PK_MessageFormat primary key(SystemKey),
	constraint UQ_MessageFormat unique(SchemaName,TypeName),
	constraint FK_MessageFormatDefinition_MessageTypeRegistry foreign key(SchemaName,TypeName)
		references [PF].[MessageTypeRegistry](SchemaName,TypeName)
			on update cascade
			on delete cascade


)
	
GO

create trigger [PF].[OnMessageFormatUpdated] 
	on [PF].[MessageFormatDefinition] after update as
		update [PF].[MessageFormatDefinition] set 
			UpdateTS = getdate()
	from 
		[PF].[MessageFormatDefinition] x 
			inner join inserted on 
				inserted.SystemKey = x.SystemKey

GO

create trigger [PF].[OnMessageFormatDeleted]
	on [PF].[MessageFormatDefinition] after delete as
		insert [PF].[MessageFormatArchive]
		(			
			SystemKey,
			SchemaName,
			TypeName,
			FormatTemplate,
			P1, P2, P3,
			P4, P5, P6,
			P7, P8, P9
		)
		select 
			SystemKey,
			SchemaName,
			TypeName,
			FormatTemplate,
			P1, P2, P3,
			P4, P5, P6,
			P7, P8, P9
		from		
			deleted

		
	
