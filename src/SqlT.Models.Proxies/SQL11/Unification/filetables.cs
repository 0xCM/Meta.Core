//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem.SQL11.sys
{
    using static metacore;



    public partial class filetables : IFileTable
    {
        string ISystemElement.name
            => directory_name;

        int IFileTable.object_id
            => object_id;

        public override string ToString() 
            => directory_name;

    }
}