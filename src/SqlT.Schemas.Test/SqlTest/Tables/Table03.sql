create table SqlTest.Table03(
Id int not null identity(1,1),
Col01 tinyint not null,
Col02 smallint not null,
Col03 int not null,
Col04 bigint not null

constraint PK_Table03 primary key(Id)
) on FileGroupB