create procedure [PF].[StorePlatformEntity]
(
	@EntityName nvarchar(75),
	@TypeUri nvarchar(250),
	@Body nvarchar(max)
) as
	declare @Entity as [T0].[PlatformEntity];
	insert @Entity
	(
		EntityName,
		TypeUri,
		Body
	)
	select 
		@EntityName,
		@TypeUri,
		@Body

	exec [PF].[StorePlatformEntities] @Entity
