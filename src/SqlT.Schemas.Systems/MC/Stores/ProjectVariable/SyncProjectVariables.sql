create procedure [MC].[SyncProjectVariables](@ProjectId nvarchar(75), @Variables [MC].[ProjectVariable] readonly) as
	with Dst as
	(
		select
			*
		from
			[MC].[ProjectVariableDefinition]
		where
			ProjectId = @ProjectId
	)
	merge into Dst using @Variables as Src 
		on
			Dst.ProjectId = @ProjectId
		and Dst.VariableName = Src.VariableName
	when not matched then insert
	(
		ProjectId,
		VariableName,
		VariableValue
	)
	values
	(
		Src.ProjectId,
		Src.VariableName,
		Src.VariableValue
	)
	when matched and not exists
	(
		select

		Src.VariableValue

		intersect

		select

		Dst.VariableValue


	)
	then update set
		Dst.VariableValue = Src.VariableValue
	when not matched by source then delete;
