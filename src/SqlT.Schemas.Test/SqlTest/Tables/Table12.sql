CREATE TABLE [SqlTest].[Table12]
(
	Col01 int not null,
	Col02 bigint not null,
	Col03 varchar(50) not null,
	Col04 bit not null,
	Col05 nvarchar(150) not null,
	Col06 date not null,
	Col07 int not null,
	Col08 int not null,
	DbCreateTime datetime2(3) constraint DF_Table12_DbCreateTime default(getdate()),
	
	constraint PK_Table12 primary key(Col01, Col02, Col03)
	
)
