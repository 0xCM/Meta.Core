create procedure [PF].[DefineSqlMessages](@Definitions [T0].[SqlMessageSpec] readonly) as
	merge into [PF].[SqlMessageDefinition] as Dst 
		using @Definitions as Src 
			on Src.MessageNumber = Dst.MessageNumber
	when not matched then insert
	(
		MessageNumber,
		SystemId,
		MessageName,
		Severity,
		FormatString
	)
	values
	(

		Src.MessageNumber,
		Src.SystemId,
		Src.MessageName,
		Src.Severity,
		Src.FormatString
	)
	when matched and not exists 
	(
		select 
			Src.SystemId,
			Src.MessageName,
			Src.Severity,
			Src.FormatString

		intersect

		select 
		
			Dst.SystemId,
			Dst.MessageName,
			Dst.Severity,
			Dst.FormatString

	
	)
	then update set
		Dst.SystemId = Src.SystemId,
		Dst.MessageName = Src.MessageName,
		Dst.Severity = Src.Severity,
		Dst.FormatString = Src.FormatString;
	




	
	
