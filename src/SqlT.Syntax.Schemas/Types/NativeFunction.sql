create type [Syntax].[NativeFunction] as table
(
	FunctionName nvarchar(128) not null,	
	[Description] nvarchar(250) null
)
GO



