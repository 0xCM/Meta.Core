CREATE TABLE SqlTest.[Table04]
(
	[Id] INT NOT NULL, 
	Code nvarchar(10) not null,
	StartDate date not null,
	EndDate date not null
	constraint PK_Table04 primary key(Id)
)
