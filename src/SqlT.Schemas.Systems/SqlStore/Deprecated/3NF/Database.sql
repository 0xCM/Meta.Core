create table [SqlStore].[Database] 
(    
	Id int not null 
		constraint DF_Database_Id 
			default(next value for [SqlStore].[DatabaseSeq]),
    DatabaseName sysname not null,
	DatabaseVersion nvarchar (25) not null,
	IsModel bit not null,
    ModelName nvarchar(128),
    Documentation nvarchar(250) null, 
    
	constraint PK_Database primary key clustered(Id),
	constraint UQ_Database unique(DatabaseName, DatabaseVersion)

)

GO

create sequence [SqlStore].[DatabaseSeq] 
	as int start with 1 cache 5

GO


