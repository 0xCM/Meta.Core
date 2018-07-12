create procedure [PF].[SyncMessageFormats](@Formats [T0].[MessageFormat] readonly ) as
	
	merge into [PF].[MessageFormatDefinition] as Dst
		using @Formats as Src on 
			Src.SchemaName = Dst.SchemaName 
		and Src.TypeName = Dst.TypeName
	when not matched then insert
	(
		SchemaName,
		TypeName,
		FormatTemplate,
		P1, P2, P3,
		P4, P5, P6,
		P7, P8, P9
	)
	values
	(
		Src.SchemaName,
		Src.TypeName,
		Src.FormatTemplate,
		Src.P1, Src.P2, Src.P3,
		Src.P4, Src.P5, Src.P6,
		Src.P7, Src.P8, Src.P9
	)
	when matched and not exists 
	(
		select 

			Src.FormatTemplate,
			Src.P1, Src.P2, Src.P3,
			Src.P4, Src.P5, Src.P6,
			Src.P7, Src.P8, Src.P9

		intersect

		select
			Dst.FormatTemplate,
			Dst.P1, Dst.P2, Dst.P3,
			Dst.P4, Dst.P5, Dst.P6,
			Dst.P7, Dst.P8, Dst.P9
	)
	then update set
		Dst.FormatTemplate = Src.FormatTemplate,
		Dst.P1 = Src.P1, 
		Dst.P2 = Src.P2, 
		Dst.P3 = Src.P3,
		Dst.P4 = Src.P4,
		Dst.P5 = Src.P5, 
		Dst.P6 = Src.P6,
		Dst.P7 = Src.P7, 
		Dst.P8 = Src.P8, 
		Dst.P9 = Src.P9
	when not matched by source then delete;
