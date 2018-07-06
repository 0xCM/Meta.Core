create table [SqlDom].[Association]
(
	ElementName varchar(250) not null,
	AssociationName varchar(250) not null,	
	AssociationType varchar(250) not null,
	IsReadOnly bit not null 
		constraint DF_Association_IsReadOnly default(0),

	CreateTS datetime2(0) not null
		constraint DF_Association_CreateTS default(getdate()),
	UpdateTS datetime2(0) null,
	constraint PK_Association primary key(ElementName,AssociationName),
	
	constraint FK_Association_DomElement foreign key(ElementName)
		references [SqlDom].[Element](ElementName)
			on delete cascade
			on update cascade			
		,

	constraint FK_Association_AssociationType foreign key(AssociationType)
		references [SqlDom].[Element](ElementName)
		

)
GO

