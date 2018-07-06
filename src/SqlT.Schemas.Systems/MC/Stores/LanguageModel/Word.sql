create table [MC].[Word] 
(	
	Identifier nvarchar(75) not null,
	CreateTS  datetime2(0) not null
		constraint DF_Word_CreateTS default (getdate()),
	UpdateTS  datetime2(0) null,
	
	constraint PK_Word primary key(Identifier)

)
GO

	
