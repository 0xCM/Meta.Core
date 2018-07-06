CREATE PROCEDURE [SqlTestResult].[pSqlVisitedNodeMerge](@Records SqlTestResult.SqlVisitedNodeRecord readonly) as
with Dst as(
select 
	[ScriptName], 
	[StepNumber], 
	[NodeDescription], 
	[NodeValue] 
from 
	SqlTestResult.SqlVisitedNode
where
	ScriptName in (select ScriptName from @Records)
)
merge into Dst using @Records as Src
on 
	Dst.ScriptName = Src.ScriptName and
	Dst.StepNumber = Src.StepNumber
when not matched then
	insert(ScriptName, StepNumber, NodeDescription, NodeValue)
	values(Src.ScriptName, Src.StepNumber, Src.NodeDescription, Src.NodeValue)
when matched and not exists
(
	select		
		Src.NodeDescription,
		Src.NodeValue

	intersect

	select
		Dst.NodeDescription,
		Dst.NodeValue
) then update set
	Dst.NodeDescription = Src.NodeDescription,
	Dst.NodeValue = Src.NodeValue
when not matched by source then delete;