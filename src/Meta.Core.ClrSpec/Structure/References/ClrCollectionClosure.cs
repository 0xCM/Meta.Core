//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

using static metacore;

public static partial class ClrStructureSpec
{
    /// <summary>
    /// Defines the type over which a collection will close
    /// </summary>
    public class ClrCollectionClosure : ClrTypeClosure
    {

        /// <summary>
        /// Defines an <see cref="IEnumerable{T}"/> closure over a specified item type
        /// </summary>
        /// <param name="ItemTypeName">The item type name</param>
        /// <returns></returns>
        public static ClrCollectionClosure Enumerable(IClrTypeName ItemTypeName)
            => new ClrCollectionClosure(new ClrInterfaceName("IEnumerable"), ItemTypeName);

        /// <summary>
        /// Defines an <see cref="IReadOnlyList{T}"/> closure over a specified item type
        /// </summary>
        /// <param name="ItemTypeName">The item type name</param>
        /// <returns></returns>
        public static ClrCollectionClosure ReadOnlyList(IClrTypeName ItemTypeName)
            => new ClrCollectionClosure(new ClrInterfaceName("IReadOnlyList"), ItemTypeName);

        /// <summary>
        /// Defines an array for a specified item type
        /// </summary>
        /// <param name="ItemTypeName">The item type name</param>
        /// <returns></returns>
        public static ClrCollectionClosure Array(IClrTypeName ItemTypeName)
            => new ClrArrayClosure(ItemTypeName);

        public ClrCollectionClosure(IClrTypeName ArrayItemTypeName)
            : base(ArrayItemTypeName) { }

        public ClrCollectionClosure(IClrTypeName CollectionTypeName, IClrTypeName ItemTypeName)
            : base(CollectionTypeName, new TypeArgument(new TypeParameter("T", 0), ItemTypeName))
        { }

    }


}