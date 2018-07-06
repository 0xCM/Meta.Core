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


    public abstract class vSystemElement : IExtensibleElement
    {
        
        protected vSystemElement(string name, IReadOnlyDictionary<string, IExtendedProperty> properties, bool userDefined)
        {
            this.Name = name;
            this._Properties = properties;
            this.IsUserDefined = userDefined;
            this.Documentation =
                _Properties.TryFind(SqlPropertyNames.Documentation)
                           .MapValueOrDefault(p => toString(p.value), String.Empty);                    
        }

        protected vSystemElement(string name, IReadOnlyDictionary<string,IExtendedProperty> properties)
            : this(name, properties, true)
        {

        }


        protected vSystemElement(string name, bool userDefined)
            : this(name, new Dictionary<string,IExtendedProperty>(), userDefined)
        {
            
        }

        IReadOnlyDictionary<string, IExtendedProperty> _Properties { get; }

        /// <summary>
        /// The name of the element
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Specifies whether the element is user-defined
        /// </summary>
        public bool IsUserDefined { get; }

        /// <summary>
        /// Documentation for the element if available
        /// </summary>
        public string Documentation { get; }

        /// <summary>
        /// The extended properties applied to the element
        /// </summary>
        public IReadOnlyDictionary<string, IExtendedProperty> Properties 
            => _Properties;

        string ISystemElement.name 
            => Name;

        public override string ToString() 
            => Name;        
    }

}