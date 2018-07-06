create table [SqlStore].[ObjectColumn]
(
	ElementId int not null,
	ObjectId int not null,

	constraint PK_ObjectColumn primary key(ElementId),
	
	constraint FK_ObjectColumn_Element foreign key(ObjectId)
		references [SqlStore].[Element](Id),

	constraint FK_ObjectColumn_Object foreign key(ObjectId)
		references [SqlStore].[SchemaObject](ObjectId)

)
	
