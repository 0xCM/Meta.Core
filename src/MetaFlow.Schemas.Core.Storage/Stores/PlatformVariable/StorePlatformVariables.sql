create procedure [PF].[StorePlatformVariables](@Records [T0].[PlatformVariable] readonly) as
	
	merge into [PF].[PlatformVariableStore] as Dst
		using @Records as Src on 
			Src.VariableName = Dst.VariableName
		when not matched then insert
		(
			VariableName,
			VariableValue
		)
		values
		(
			Src.VariableName,
			Src.VariableValue
		)
		when matched and not exists
		(
			
			select Src.VariableName intersect
			select Dst.VariableName
		)
		then update set
			Dst.VariableName = Src.VariableName;
GO



	
	