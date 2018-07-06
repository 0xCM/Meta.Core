create table [SqlDom].[ElementAttribute]
(
	ElementName varchar(250) not null,
	AttributeName varchar(250) not null,
	DataType varchar(250) not null,
	Infrastructure bit not null
		constraint DF_ElementAttribute_Infrastructure default(0),
	IsReadOnly bit not null 
		constraint DF_ElementAttribute_IsReadOnly default(0),

	CreateTS datetime2(0) not null
		constraint DF_ElementAttribute_CreateTS default(getdate()),
	UpdateTS datetime2(0) null,

	constraint PK_ElementAttribute primary key(ElementName,AttributeName),

	constraint FK_ElementAttribute_Element foreign key(ElementName)
		references [SqlDom].[Element](ElementName)
			on delete cascade
			on update cascade,			
	--constraint FK_ElementAttribute_AttributeType foreign key(DataType)
	--	references [SqlDom].[DataType](TypeName)
		
		

)
		

GO
