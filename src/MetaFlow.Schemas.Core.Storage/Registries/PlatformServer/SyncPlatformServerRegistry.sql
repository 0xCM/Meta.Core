create procedure [PF].[SyncPlatformServerRegistry](@Nodes [T0].[PlatformNode] readonly) as
	merge into [PF].[PlatformServerRegistry] as Dst
		using @Nodes as Src on
			Src.NodeId = Dst.NodeId
		when not matched then insert
		(
			NodeId,
			NodeName,
			HostName,
			HostIP,
			NetworkName,
			WinOperatorName,
			WinOperatorPass
		)
		values
		(

			Src.NodeId,
			Src.NodeName,
			Src.HostName,
			Src.HostIP,
			Src.NetworkName,
			Src.WinOperatorName,
			Src.WinOperatorPass
		)
		when matched and not exists
		(
			select 
				Src.NodeName,
				Src.HostName,
				Src.HostIP,
				Src.NetworkName,
				Src.WinOperatorName,
				Src.WinOperatorPass

			intersect
			
			select 
				Dst.NodeName,
				Dst.HostName,
				Dst.HostIP,
				Dst.NetworkName,
				Dst.WinOperatorName,
				Dst.WinOperatorPass

	
		)
		then update set
				Dst.NodeName = Src.NodeName,
				Dst.HostName = Src.HostName,
				Dst.HostIP = Src.HostIP,
				Dst.NetworkName = Src.NetworkName,
				Dst.WinOperatorName = Src.WinOperatorName,
				Dst.WinOperatorPass = Src.WinOperatorPass
		when not matched by source then delete;
