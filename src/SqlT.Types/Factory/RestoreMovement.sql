create type [Factory].[RestoreMovement] as table
(
	LogicalSourceName nvarchar(128) not null,
	PhysicalTargetName nvarchar(250) not null
)

	
