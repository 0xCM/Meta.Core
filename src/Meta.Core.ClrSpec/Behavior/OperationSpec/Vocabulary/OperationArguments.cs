//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;
    public sealed class OperationArguments : TypedItemList<OperationArguments, OperationArgument>
    {

        public static OperationArguments FromDictionary(IReadOnlyDictionary<string, string> args)
            => FromTuples(args.Select(a => (a.Key, a.Value)));

        public static OperationArguments FromTuples(IEnumerable<(string, string)> args)
            => Create(args.Select(a => new OperationArgument(a.Item1, a.Item2)));


        public static implicit operator OperationArguments(OperationArgument[] args)
            => Create(args);

        public OperationArguments()
            : base(',')
        { }

        public IReadOnlyDictionary<string, string> ToDictionary()
            => map(this, arg => (arg.Name, arg.Value)).ToDictionary(x => x.Name, x => x.Value);
    }

}