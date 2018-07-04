insert [A0].[TableA]
(
	Col01,
	Col02,
	Col03
)
select
	ColA,
	ColB,
	ColC
from
	@TableVariable;
		