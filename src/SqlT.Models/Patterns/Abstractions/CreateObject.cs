//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Patterns
{
    using SqlT.Models;
    using SqlT.Core;

    using sxc = SqlT.Syntax.contracts;


    public abstract class CreateObject<M, O, N> : SqlModelFactory<M,O>
        where N : sxc.ISqlObjectName, new()
        where O : ISqlObject
        where M : CreateObject<M,O,N>
    {

        protected CreateObject(N Name)
        {
            this.Name = Name;

        }

        protected CreateObject()
        {
            

        }

        public N Name { get; set; }

        

    }
}
