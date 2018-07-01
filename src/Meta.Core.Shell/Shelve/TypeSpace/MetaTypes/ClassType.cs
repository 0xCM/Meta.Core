//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Types
{
    /// <summary>
    /// Represents a Class type relative to a <see cref="TypeSpace{S}"/>
    /// </summary>
    /// <typeparam name="S">The defining space</typeparam>
    /// <typeparam name="X"></typeparam>
    public sealed class ClassType<S, X> :  MetaBase<S,X>
        where S : TypeSpace<S>, new()
    {

        public static implicit operator MetaType<ClassType<S,X>, S>(ClassType<S,X> x)
            => new MetaType<ClassType<S, X>, S>(x.Space);

        public ClassType(S Space)
            : base(Space)
        {
            
        }
    }
}