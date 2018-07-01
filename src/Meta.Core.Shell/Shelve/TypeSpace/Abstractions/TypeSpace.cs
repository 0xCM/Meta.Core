//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Types
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    using static metacore;

    public abstract class TypeSpace<S> : ITypeSpace<S>
        where S : TypeSpace<S>, new()
    {

        public static readonly S Default = new S();

        MutableSet<ITypeAssociation<S>> arrows;
        MutableSet<IMetaType<S>> points;

        public TypeSpace(string Name)
        {
            this.Name = Name;
            this.arrows = new MutableSet<ITypeAssociation<S>>();
            this.points = new MutableSet<IMetaType<S>>();
        }

        public string Name { get; }

        public override string ToString()
            => Name.ToString();

        public ClassType<S, X> Class<X>()
        {
            var x = new ClassType<S, X>((S)this);
            points.Add(x);
            return x;
        }

        public IMetaType<S> Class(Type type)
        {
            var metaTypeType = typeof(ClassType<,>).GetGenericTypeDefinition().MakeGenericType(typeof(S), type);
            var x = Activator.CreateInstance(metaTypeType, (S)this);
            return cast<IMetaType<S>>(x);
        }


        public InterfaceType<S, X> Interface<X>()
        { 
            var x =  new InterfaceType<S, X>((S)this);
            points.Add(x);
            return x;
        }

        public EnumType<S, X> Enum<X>()
        {
            var x = new EnumType<S, X>((S)this);
            points.Add(x);
            return x;
        }

        public IMetaType<S> Enum(Type type)
        {
            var metaTypeType = typeof(EnumType<,>).GetGenericTypeDefinition().MakeGenericType(typeof(S), type);
            var x = Activator.CreateInstance(metaTypeType, (S)this);
            return cast<IMetaType<S>>(x);
        }

        public IEnumerable<IMetaType<S>> Enums(IEnumerable<Type> types)
            => from t in types
               select Enum(t);


        public RecordType<S, X> Record<X>()
        {
            var x = new RecordType<S, X>((S)this);
            points.Add(x);
            return x;
        }

        public PrimitiveType<S, X> Primitive<X>()
        {
            var x = new PrimitiveType<S, X>((S)this);
            points.Add(x);
            return x;
        }

        public SetType<S, X> Set<X>()
        {
            var x = new SetType<S, X>((S)this);
            points.Add(x);
            return x;
        }

        public TypeAssociation<S, X, Y> Arrow<X, Y>(X x, Y y)
        {
            var association = new TypeAssociation<S, X, Y>((S)this, x, y);
            arrows.Add(association);
            return association;
        }
    }




}
