﻿create type [T0].[PlatformVariable] as table
(
	VariableName nvarchar(75) not null,
	VariableValue nvarchar(1024) not null
)