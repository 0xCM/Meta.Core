create procedure [PF].[StoreTableMonitorLogEntries](@Entries [T0].[TableMonitorLogEntry] readonly) as

	merge into [PF].[TableMonitorLog] as Dst
		using @Entries as Src on
			Src.HostId = Dst.HostId
		and	Src.DatabaseName = Dst.DatabaseName
		and Src.SchemaName = Dst.SchemaName
		and Src.TableName = Dst.TableName
		when not matched then insert
		(
			HostId,
			DatabaseName,
			SchemaName,
			TableName,
			LastObservedVersion,
			ObservationTS,
			LastProcessedVersion,
			ProcessedTS,
			LoggedTS
		)
		values
		(
			Src.HostId,
			Src.DatabaseName,
			Src.SchemaName,
			Src.TableName,
			Src.LastObservedVersion,
			Src.ObservationTS,
			Src.LastProcessedVersion,
			Src.ProcessedTS,
			Src.LoggedTS
		)
		when matched then update set			
			Dst.LastObservedVersion = Src.LastObservedVersion,
			Dst.ObservationTS = Src.ObservationTS,
			Dst.LastProcessedVersion = Src.LastProcessedVersion,
			Dst.ProcessedTS = Src.ProcessedTS,
			Dst.LoggedTS = Src.LoggedTS;

			

	
