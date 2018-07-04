//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Patterns
{
    using SqlT.Core;
    using SqlT.Models;
    using sxc = SqlT.Syntax.contracts;

    public abstract class CreateTabular<M, T, N> : CreateObject<M, T, N>
        where N : sxc.tabular_name, new()
        where T : ISqlObject, ISqlColumnProvider
        where M : CreateTabular<M,T,N>
    {

        protected CreateTabular()
        {

        }

        protected CreateTabular(N Name)
            : base(Name)
        {


        }


    }



}