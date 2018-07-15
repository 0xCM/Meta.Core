//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{

    public interface IValueConverter
    {
        object Convert(object x);
    }

    public interface IValueConverter<in S, out T> : IValueConverter
        where S : struct
        where T : struct
    {
        T Convert(S x);
    }

    public abstract class ValueConverter<S, T> : IValueConverter<S,T>
        where S: struct
        where T: struct
    {

        protected ValueConverter(TransformationName Name = null)
        {
            this.Name = Name ?? string.Empty;

        }

        public TransformationName Name { get; }

        public abstract T Convert(S value);

        public object Convert(object x)
            => Convert((S)x);
    }

}
