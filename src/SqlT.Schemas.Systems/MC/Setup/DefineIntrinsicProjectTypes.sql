create procedure [MC].[DefineIntrinsicProjectTypes] as
	set nocount on

	merge into [MC].[ProjectType] as Dst
	using (values 
		(0, 'None', 'None', 'Specifies the absence of classification'),
		(1, 'Library', 'Library', 'Identifies a class library project'),
		(2, 'Console', 'Console', 'Identifies a console project'),
		(3, 'Sql', 'Sql', 'Identifies a sql project')
	) as Src(TypeCode,Identifier,Label, [Description])
		on Src.TypeCode = Dst.TypeCode
	when not matched then insert
	(
		TypeCode,
		Identifier,
		Label,
		[Description]
	)
	values
	(
		Src.TypeCode,
		Src.Identifier,
		Src.Label,
		Src.[Description]
	)
	when matched and not exists
	(
		select
			Src.Identifier,
			Src.Label,
			Src.[Description]

		intersect

		select
			Dst.Identifier,
			Dst.Label,
			Dst.[Description]

	)
	then update set
		Dst.Identifier = Src.Identifier,
		Dst.Label = Src.Label,
		Dst.[Description] = Src.[Description];
