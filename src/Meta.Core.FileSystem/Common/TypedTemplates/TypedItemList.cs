//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Namespace
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Collections;


    [TypedTemplate(typeof(TypedItemList<,>))]
    public class TypedItemListTemplate : TypedTemplate<TypedItemListTemplate, TypedItemListTemplate.TypeName>
    {



        [TypedTemplate(ElementRole.SyntaxName)]
        public class ItemType { }

        //TemplatedType-Begin
        public class TypeName : TypedItemList<TypeName, ItemType>
        {
            public static implicit operator TypeName(ItemType[] Items)
                => Create(Items);

            public TypeName() { }

        }
        //TemplatedType-End

    }
}
