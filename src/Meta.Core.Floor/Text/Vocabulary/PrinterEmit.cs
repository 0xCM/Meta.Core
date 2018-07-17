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

    public abstract class PrinterEmit<T> : IPrenterEmit<T>
    {
        protected virtual string Separator { get; }
            = ",";

        public abstract string Print(T value);

        string IPrinterEmit.Print(object value)
            => Print((T)value);

        public virtual string PrintSequence(IEnumerable<T> values)
            => string.Join(Separator, values);

        string IPrinterEmit.PrintSequence(IEnumerable<object> values)
            => PrintSequence(values.Cast<T>());
    }

    public interface IPrinterEmit
    {
        string Print(object value);

        string PrintSequence(IEnumerable<object> values);
    }

    public interface IPrenterEmit<in T> : IPrinterEmit
    {
        string Print(T value);

        string PrintSequence(IEnumerable<T> values);
    }


    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class PrinterAttribute : Attribute
    {
        public PrinterAttribute(params Type[] Subjects)
        {
            this.Subjects = Subjects;
        }

        public IReadOnlyList<Type> Subjects { get; }

    }

}

