//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Models
{

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;



    public static class ModelOption
    {
        public static ModelOption<m> decide<m>(m maybe)
            where m : IModel
                => ModelOption<m>.decide(maybe);

        public static ModelOption<k> some<k>(k value)
            where k : IModel
                 => new ModelOption<k>(value);

        public static ModelOption<k> none<k>()
            where k : IModel
                => new ModelOption<k>();
    }

    public struct ModelOption<k> : IModelOption
        where k : IModel
    {
        public static ModelOption<k> none = new ModelOption<k>(false);

        public static bool operator true(ModelOption<k> o)
            => o.exists;

        public static bool operator false(ModelOption<k> o)
            => not(o.exists);

        static IModelType model_type
            = ModelTypeInfo.Get<ModelOption<k>>();

        public static implicit operator ModelOption<k>(k value)
            => new ModelOption<k>(value);

        public static explicit operator k(ModelOption<k> maybe)
            => maybe.value;

        public static ModelOption<k> decide(k maybe)
            => new ModelOption<k>(maybe);

        ModelOption(bool exists)
        {
            this.exists = false;
            this.value = default(k);
        }

        public ModelOption(k value)
        {
            this.value = value;
            this.exists = value != null;

        }

        public bool exists { get; }

        IModel IModelOption.value
            => exists
            ? value
            : empty_model<k>.empty;

        public k value { get; }

        public k valueOrElse(k @else)
            => exists ? value : @else;

        IModelType IModel.ModelType
            => model_type;

        public t map<t>(Func<k, t> ifExists, Func<t> ifNotExists)
            => exists
            ? ifExists(value)
            : ifNotExists();

        public void onValue(Action<k> act)
        {
            if (exists)
                act(value);
        }

        public override string ToString()
            => exists
            ? (value?.ToString() ?? string.Empty)
            : string.Empty;
    }

    public static class optX
    {
        public static IModelOption FirstValue(this IEnumerable<IModelOption> potentialValues)
            => potentialValues.Where(x => x.exists).First();

    }

}