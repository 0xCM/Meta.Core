//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://openData.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Workflow
{
    using System;
    using static metacore;

    public abstract class DataJunction : IDataJunction
    {
        public DataJunction(Type JunctionType, DataJunctionName Name = null)
        {
            this.Name = Name ?? DataJunctionName.Empty;
        }

        public DataJunctionName Name { get; }

        public Type NodeType { get; }

        public override string ToString()
            => Name;
    }

    public abstract class DataJunction<D> : DataJunction
    {
        public DataJunction()
            : base(typeof(D))
        {

        }

        public DataJunction(DataJunctionName Name = null)
            : base(typeof(D), Name)
        {


        }

        public override string ToString()
            => $"{typeof(D).Name}";
    }
}