create table [SqlStore].[Element] 
(
    Id int not null 
		constraint DF_Element_Id 
			default(next value for [SqlStore].[ElementSeq]),
    DatabaseId int not null,
    
	constraint PK_Element primary key(Id),
    
	constraint FK_Element_Database foreign key (DatabaseId) 
		references [SqlStore].[Database] (Id)

)
GO

create sequence [SqlStore].[ElementSeq] 
	as int start with 1 cache 10
GO
