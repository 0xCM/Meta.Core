create table [SqlStore].[Server] 
(
	Id int not null 
		constraint DF_Server_ServerId default(next value for [SqlStore].[ServerSeq]),
    ServerName sysname not null,

	constraint PK_Server primary key(Id)

)

GO
create sequence [SqlStore].[ServerSeq] 
	as int start with 1 cache 5