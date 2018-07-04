//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Bindings
{
    using SqlT.Models;
    

    public sealed class SqlSpace 
    {

        public SqlSpace()
        {
            this.Name = "sql";                    
        }

        public SqlSpace(string InstanceName)
        {
            this.Name = InstanceName;
        }

        public string Name { get; }
    }    

}
