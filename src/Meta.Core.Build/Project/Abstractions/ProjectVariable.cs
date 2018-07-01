//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Project
{


    public abstract class ProjectVariable<B, V> : ProjectVariable<V>
       where B : ProjectVariable<B, V>
    {
        protected ProjectVariable()
            : base(typeof(B).Name)
        { }

        protected ProjectVariable(V Value)
            : base(typeof(B).Name, Value)
        { }


        protected ProjectVariable(string Name)
            : base(Name)
        { }

        protected ProjectVariable(string Name, V Value)
            : base(Name, Value)
        { }

    }


}