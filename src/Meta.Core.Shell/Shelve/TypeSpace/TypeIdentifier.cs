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

    /// <summary>
    /// Defines a tuple that identifies a type relative to its class and space
    /// </summary>
    public struct TypeIdentifier
    {
        public static implicit operator TypeIdentifier((Type TypeSpace, Type TypeClass, string TypeName) coordinate)
            => new TypeIdentifier(coordinate);

        public static implicit operator (Type TypeSpace, Type TypeClass, string TypeName) (TypeIdentifier x)
            => (x.MetaType, x.MetaType, x.TypeName);

        public TypeIdentifier((Type TypeSpace, Type TypeClass, string TypeName) coordinate)
        {
            this.TypeSpace = coordinate.TypeSpace;
            this.MetaType = coordinate.TypeClass;
            this.TypeName = coordinate.TypeName;
        }

        public TypeIdentifier(Type TypeSpace, Type TypeClass, string TypeName)
        {
            this.TypeSpace = TypeSpace;
            this.MetaType = TypeClass;
            this.TypeName = TypeName;
        }

        public Type TypeSpace { get; }

        public Type MetaType { get; }

        public string TypeName { get; }

        public override string ToString()
            => (TypeSpace, MetaType, TypeName).Format();

    }


}