//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Workflow
{

    public sealed class Splitter<S, T1, T2>
        where S : DataSource<S>
        where T1 : DataTarget<T1>
        where T2 : DataTarget<T2>
    {

        public Splitter(S Source, DataTransformer<S, T1> T1, DataTransformer<S, T2> T2, string Name = null)
        {
            this.Source = Source;
            this.Target1 = T1;
            this.Target2 = T2;
            this.Name = Name;
        }

        public string Name { get; }

        public S Source { get; }

        public DataTransformer<S, T1> Target1 { get; }

        public DataTransformer<S, T2> Target2 { get; }
    }




}