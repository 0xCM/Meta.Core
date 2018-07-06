create table [SqlDom].[Element]
(
	ElementId int not null
		constraint DF_Element_ElementId default(next value for [SqlDom].[ElementSequence]),		
	ElementName varchar(250) not null,	
	ParentName varchar(250) null,
	IsAbstract bit not null,
	ElementType nvarchar(75) not null
		constraint DF_Element_ElementType default('None'),
	CreateTS datetime2(0) not null
		constraint DF_Element_CreateTS default(getdate()),
	UpdateTS datetime2(0) null,
	constraint PK_Element primary key(ElementId),
	constraint UQ_Element unique(ElementName),
	constraint FK_Element_ElementType foreign key(ElementType)
		references [SqlDom].[ElementType](Identifier)

)
GO
create sequence [SqlDom].[ElementSequence]
	as int start with 1 cache 10;


	
