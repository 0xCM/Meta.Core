//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using SqlT.Core;
    using static metacore;

    public class vExtendedProperty : vSystemElement, IExtendedProperty
    {

        public vExtendedProperty(IExtendedProperty property)
            : base(property.name, true)
        {
            this._property = property;
        }

        IExtendedProperty _property { get; }

        public byte @class 
            => _property.@class;

        public string class_desc 
            => _property.class_desc;

        public int major_id 
            => _property.major_id;

        public int minor_id 
            => _property.minor_id;

        public object value 
            => _property.value;
    }

}
