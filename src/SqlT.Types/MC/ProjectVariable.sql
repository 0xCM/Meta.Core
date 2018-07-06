create type [MC].[ProjectVariable] as table
(
	ProjectId nvarchar(75) not null,
	VariableName nvarchar(75) not null,
	VariableValue nvarchar(1024) not null
)
