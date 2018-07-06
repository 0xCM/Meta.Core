CREATE TYPE [SqlTestResult].[SqlVisitedNodeRecord] AS TABLE
(
	ScriptName nvarchar(128) not null,
	StepNumber int not null,
	NodeDescription nvarchar(250) not null,
	NodeValue nvarchar(max) not null	
)
