CREATE TABLE [SqlTest].[Table0E]
(
	DbCreateTime datetime2 not null constraint DF_Table0E_DbCreateTime default(sysdatetime()),
	DbCreateUser datetime2 not null constraint DF_Table0E_DbCreateUser default(suser_sname())
)
