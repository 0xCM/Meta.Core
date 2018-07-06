create view [SqlDom].[ElementMember] as
	with Members as
	(
		select 
			e.ElementName, 
			MemberName = AssociationName, 
			MemberType = AssociationType,
			IsAttribute = 0,
			IsAssociation = 1,
			IsCollection = 0,
			IsEnumLiteral = 0,
			IsReadOnly
		from 
			[SqlDom].[Association] a 
				inner join [SqlDom].[Element] e on 
					e.ElementName = a.ElementName 
		
		

		union all

		select 
			e.ElementName, 
			MemberName = AttributeName, 
			MemberType = DataType,
			IsAttribute = 1,
			IsAssociation = 0,
			IsCollection = 0,
			IsEnumLiteral = 0,
			IsReadOnly

			
		from 
			[SqlDom].[ElementAttribute] a 
				inner join [SqlDom].[Element] e on 
					e.ElementName = a.ElementName
		where	
			a.Infrastructure = 0

		union all

		select 
			e.ElementName, 
			MemberName = CollectionName, 
			MemberType = ItemType,
			IsAttribute = 0,
			IsAssociation = 0,
			IsCollection = 1,
			IsEnumLiteral = 0,
			IsReadOnly
		from 
			[SqlDom].[Collection] c 
				inner join [SqlDom].[Element] e 
					on e.ElementName = c.ElementName

		union all

		select 
			e.ElementName, 
			MemberName = LiteralName, 
			MemberType = null,
			IsAttribute = 0,
			IsAssociation = 0,
			IsCollection = 0,
			IsEnumLiteral = 1,
			IsReadOnly = 0

		from 
			[SqlDom].[EnumElement] n 
				inner join [SqlDom].[Element] e 
					on e.ElementName = n.EnumName
	)
	select 
		ElementName, 
		MemberIndex = row_number() over(partition by ElementName order by MemberName),
		MemberName, 
		MemberType,
		IsAttribute,
		IsAssociation,
		IsCollection,
		IsEnumLiteral,
		IsReadOnly
	from 
		Members


	
