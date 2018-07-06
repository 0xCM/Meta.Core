CREATE TABLE [SqlTestResult].[SqlVisitedNode]
(
	ScriptName nvarchar(128) not null,
	StepNumber int not null,
	NodeDescription nvarchar(250) not null,
	NodeValue nvarchar(max) not null

	constraint PK_SqlVisitedNode primary key (ScriptName, StepNumber)
)
