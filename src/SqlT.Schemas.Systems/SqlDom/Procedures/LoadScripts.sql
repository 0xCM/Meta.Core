create procedure [SqlDom].[LoadScripts](@Records [SqlDom].[ScriptDocument] readonly) as

	declare 
		@LoadTS datetime2(0) = getdate();

	merge into [SqlDom].[ScriptDocument] as Dst
		using @Records as Src on
			Src.ScriptName = Dst.ScriptName
	when not matched then insert
	(
		ScriptName,
		ScriptText
	)
	values
	(
		Src.ScriptName,
		Src.ScriptText
	)
	when matched and not exists
	(
		select
			Src.ScriptText

		
		intersect

		select
			Dst.ScriptText

	)
	then update set
		Dst.ScriptText = Src.ScriptText,
		Dst.UpdateTS = @LoadTS;
	