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
    using System.Reflection;

   
    public abstract class TypeDocSet
    {

        protected static VE entry<U, T>()
            => new VE(typeof(U), typeof(T));

        protected static VC cat<U, T>()
            => new VC(typeof(U), typeof(T));

        public class VE : VocabEntry
        {
            public VE(Type TypeUri, Type TargetType)
                : base(TypeUri, TargetType)
            {
            }

        }

        public class VC : VocabCategory
        {
            public VC(Type TypeUri, Type TargetType)
            : base(TypeUri, TargetType)
            { }
            public VCI item(object item)
                => new VCI(this, item);

        }

        public class VCI : VocabCategoryItem
        {
            public VCI(VC Category, object Item)
                : base(Category, Item)
            { }
        }


    }


}