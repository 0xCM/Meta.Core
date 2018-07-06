create type [MC].[Facet] as table
(
	FacetName nvarchar(128) not null,
	FacetValue nvarchar(250) null
)

