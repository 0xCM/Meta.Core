//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem.SQL13.sys
{
    using static metacore;



    public partial class tables : ITable
    {
        bool ISystemObject.is_user_defined => not(is_ms_shipped);

        public override string ToString() => name;

    }
}