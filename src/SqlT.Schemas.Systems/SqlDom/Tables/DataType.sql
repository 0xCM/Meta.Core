create table [SqlDom].[DataType]
(
	ElementId int not null,
	TypeName varchar(250) not null,	
	CreateTS datetime2(0) not null
		constraint DF_DataType_CreateTS default(getdate()),
	UpdateTS datetime2(0) null,
	constraint PK_DataType primary key(ElementId),
	constraint UQ_DataType unique(TypeName),

	constraint FK_DataType_Element_Id foreign key(ElementId)
		references [SqlDom].[Element](ElementId),

	constraint FK_DataType_Element_Name foreign key(TypeName)
		references [SqlDom].[Element](ElementName)
			on delete cascade
			on update cascade
		
	


)
GO
