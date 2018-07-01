//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Project
{


    public sealed class WorkspaceArea : WorkspaceArea<WorkspaceArea>
    {
        public WorkspaceArea(IWorkspaceArea area)
            : base(area.AreaName)
        {

        }
    }

    public sealed class WorkspaceAreas : TypedItemList<WorkspaceAreas, WorkspaceArea>
    {
        public static implicit operator WorkspaceAreas(WorkspaceArea[] areas)
            => Create(areas);

        public WorkspaceAreas()
        {

        }
    }


}