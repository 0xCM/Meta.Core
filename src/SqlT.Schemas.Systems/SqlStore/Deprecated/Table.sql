create table [SqlStore].[Table]
(
    ObjectId int not null,

	constraint PK_Table primary key(ObjectId),

	constraint FK_Table_Object foreign key(ObjectId)
		references [SqlStore].[SchemaObject](ObjectId)
)
GO


GO
