create view [SqlDom].[EnumElement] as
	select 
		l.EnumName,
		l.LiteralName,
		e.ElementType,
		IsNaturalDefault = cast(case l.LiteralValue when 0 then 1 else 0 end as bit)
	from 
		[SqlDom].[Element] e 
			inner join [SqlDom].[EnumLiteral] l on 
				l.EnumName = e.ElementName
	where 
		e.ElementType = 'Enum'
