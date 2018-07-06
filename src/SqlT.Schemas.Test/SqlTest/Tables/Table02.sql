CREATE TABLE SqlTest.Table02
(
	Col01 INT NOT NULL,
	Col02 datetime2(7) not null,
	Col03 bigint not null,
	constraint PK_Table02 primary key(Col01)
) on FileGroupA
