create procedure [Factory].[SpecifyRestoreDatabase]
(
	@FactoryIdentifier nvarchar(75),
	@Restore [Factory].[RestoreDatabase] readonly, 
	@Movements [Factory].[RestoreMovement] readonly
) as
	
	begin transaction

		insert [Factory].[RestoreDatabase]
		(
			 Identifier,
			 DatabaseName,
			 SourceFilePath,
			 [NoUnload],
			 [Replace],
			 [Stats] 
		)
		select
			@FactoryIdentifier,
			DatabaseName,
			 SourceFilePath,
			 [NoUnload],
			 [Replace],
			 [Stats] 
		from
			@Restore;

		insert [Factory].[RestoreMovement]
		(
			 RestoreIdentifier,
			 LogicalSourceName,
			 PhysicalTargetName
		)
		select
			@FactoryIdentifier,
			LogicalSourceName,
			PhysicalTargetName
		from
			@Movements

	
	commit transaction