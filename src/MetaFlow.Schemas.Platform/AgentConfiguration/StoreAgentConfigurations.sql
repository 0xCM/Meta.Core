create procedure [WF].[StoreAgentConfigurations](@Configs [WF].[AgentConfiguration] readonly) as
	
	merge into [WF].[AgentConfigurationStore] as Dst
		using @Configs as Src on
			Src.AgentId = Dst.AgentId
		when not matched then insert
		(
			AgentId,
			IsEnabled,
			SpinFrequency
		)
		values
		(
			Src.AgentId,
			Src.IsEnabled,
			Src.SpinFrequency
		)
		when matched and not exists 
		(

			select 
				Src.IsEnabled,
				Src.SpinFrequency
			
			intersect

			select 
				Dst.IsEnabled,
				Dst.SpinFrequency


		)
		then update set
			Dst.IsEnabled = Src.IsEnabled,
			Dst.SpinFrequency = Src.SpinFrequency,
			Dst.UpdateTS = getdate();

					
	
