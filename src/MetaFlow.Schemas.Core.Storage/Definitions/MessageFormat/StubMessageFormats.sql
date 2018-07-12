create procedure [PF].[StubMessageFormats] as

	insert [PF].[MessageFormatDefinition]
	(
		SchemaName,
		TypeName,
		FormatTemplate
	)
	select
		SchemaName,
		TypeName,
		'@Placeholder'
	from
		[PF].[MessageTypeRegistry]
	where not exists
	(
		select 	SchemaName, TypeName from [PF].[MessageTypeRegistry]
		intersect
		select SchemaName, TypeName from [PF].[MessageFormatDefinition]
	)

	
	
