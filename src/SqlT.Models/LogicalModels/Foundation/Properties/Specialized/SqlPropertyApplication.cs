//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using static metacore;

    using SqlT.Core;
    using SqlT.SqlSystem;



    public abstract class SqlPropertyApplication : ISqlPropertyApplication
    {
        public static SqlPropertyApplication<P, V, E> ApplyTo<P, V, E>(P Property, E Element)
            where P : ISqlCustomProperty<V>
            where E : IExtensibleElement
                => new SqlPropertyApplication<P, V, E>(Property, Element);

        ISqlCustomProperty Property { get; }

        IExtensibleElement Element { get; }

        protected SqlPropertyApplication(ISqlCustomProperty Property, IExtensibleElement Element)
        {
            this.Property = Property;
            this.Element = Element;
        }

        ISqlCustomProperty ISqlPropertyApplication.Property { get; }

        IExtensibleElement ISqlPropertyApplication.Element { get; }

    }


    public class SqlPropertyApplication<P, V, E> : SqlPropertyApplication, ISqlPropertyApplication<P,V,E>
        where P : ISqlCustomProperty<V>
        where E : IExtensibleElement
    {
        public SqlPropertyApplication(P Property, E Element)
            : base(Property, Element)
        {

            this.Element = Element;
            this.Property = Property;
        }

        public E Element { get; }


        public P Property { get; }


    }




}