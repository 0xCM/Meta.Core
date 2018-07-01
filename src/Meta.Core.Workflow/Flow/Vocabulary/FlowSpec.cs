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
    using static FlowTypes;

    using static metacore;       

    public sealed class FlowSpec<S, T> : IFlowSpec<S, T>
        where S : class, new()
    {

        public FlowSpec(string CommandName, IFlowArgs Arguments, IEnumerable<Source<S>> Sources,
            Projector<S, T> Transformer, Target<T> Sink, FlowInitializer Initializer = null) 
        {
            this.CommandName = CommandName;
            this.Arguments = Arguments;
            this.Sources = rolist(Sources);
            this.Transformer = Transformer;
            this.Sink = Sink;
            this.Initializer = Initializer ?? new FlowInitializer(s => 0);
            this.CorrelationToken = CorrelationToken.Empty;


        }

        IReadOnlyList<Source<S>> Sources { get; }

        Projector<S, T> Transformer { get; }

        Target<T> Sink { get; }

        FlowInitializer Initializer { get; }

        string CommandName { get; }

        IFlowArgs Arguments { get; }

        CorrelationToken CorrelationToken;
        Type IFlowSpec.SrcType 
            => typeof(S);

        Type IFlowSpec.DstType 
            => typeof(T);

        IFlowArgs IFlowSpec.Arguments 
            => Arguments;

        FlowInitializer IFlowSpec.Initializer 
            => Initializer;

        Target<T> IFlowSpec<S, T>.Target 
            => Sink;

        IEnumerable<Source<S>> IFlowSpec<S, T>.Sources
            => Sources;

        Projector<S, T> IFlowSpec<S, T>.Projector 
            => Transformer;

        Projector IFlowSpec.Projector
            => src => from t in Transformer(from s in src select (S)s)
                      select (object)t;

        IEnumerable<Source> IFlowSpec.Sources
            => from source in Sources
               select new Source(() => from item in source() select box(item));

        Target IFlowSpec.Sink
            => items => Sink(from item in items select (T)item);

        public Option<NamedValue> this[string argname]
            => Arguments.GetArgumentValue(argname);

        public override string ToString()
            => $"{CommandName}:{typeof(S).Name} => {typeof(T).Name}";
    }

}
