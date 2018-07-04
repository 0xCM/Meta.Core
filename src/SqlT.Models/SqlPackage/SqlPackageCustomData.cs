//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
 
    public class SqlPackageCustomData
    {
        List<NamedValue> storage;

        public SqlPackageCustomData(string Category, string Type)
        {
            this.Category = Category;
            this.Type = Type;
            this.storage = new List<NamedValue>();

        }

        public string Category { get; }

        public string Type { get; }

        public void AddProperty((string Name, string Value) Property)
        {
            storage.Add(new NamedValue(Property.Name, Property.Value));
        }

        public void AddProperty(string Name, string Value)
        {
            storage.Add(new NamedValue(Name, Value));
        }

        public IReadOnlyList<NamedValue> Properties
            => storage;

        public override string ToString()
            => (Category, Type).Format();

    }






}