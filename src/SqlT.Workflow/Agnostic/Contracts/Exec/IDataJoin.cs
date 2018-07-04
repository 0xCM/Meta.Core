//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Workflow
{

    public interface IDataJoin : IDataJunction
    {

    }

    public interface IDataJoin<L, R> : IDataJoin
        where L : IDataSource
        where R : IDataSource
    {

        L Left { get; }

        R Right { get; }


    }

    public interface IDataJoin<L, R, T> : IDataJoin<L, R>
        where L : IDataSource
        where R : IDataSource
        where T : IDataTarget
    {

        T Target { get; }

    }

}