create procedure [SqlDom].[LoadScriptXml](@ScriptXml [SqlDom].[ScriptXml] readonly) as
	
	declare 
		@LoadTS datetime2(0) = getdate();

	merge into [SqlDom].[ScriptXml] as Dst
		using @ScriptXml as Src on
			Src.ScriptName = Dst.ScriptName
	when not matched then insert
	(
		ScriptName,
		SourceText,
		XmlFormat
	)
	values
	(
		Src.ScriptName,
		Src.SourceText,
		Src.XmlFormat
	)
	when matched and not exists
	(
		select
			Src.SourceText,
			cast(Src.XmlFormat as nvarchar(max))

		
		intersect

		select
			Dst.SourceText,
			cast(Dst.XmlFormat as nvarchar(max))

	)
	then update set
		Dst.SourceText = Src.SourceText,
		Dst.XmlFormat = Src.XmlFormat,
		Dst.UpdateTS = @LoadTS;
	