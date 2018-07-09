//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
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