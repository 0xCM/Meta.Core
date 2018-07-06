create table [SqlDom].[Collection]
(
	ElementName varchar(250) not null,
	CollectionName varchar(250) not null,	
	ItemType varchar(250) not null,
	IsReadOnly bit not null 
		constraint DF_Collection_IsReadOnly default(0),
			
	CreateTS datetime2(0) not null
		constraint DF_Collection_CreateTS default(getdate()),
	UpdateTS datetime2(0) null,
	
	constraint PK_Collection primary key(ElementName,CollectionName),
	
	constraint FK_Collection_DomElement foreign key(ElementName)
		references [SqlDom].[Element](ElementName)
			on delete cascade
			on update cascade
			,

	constraint FK_Collection_ItemType foreign key(ItemType)
		references [SqlDom].[Element](ElementName)
		
)
GO

