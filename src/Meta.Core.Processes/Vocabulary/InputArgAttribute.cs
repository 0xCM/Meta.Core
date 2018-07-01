//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Shell
{

    using System;


    [AttributeUsage(AttributeTargets.Property)]
    public class InputArgAttribute : Attribute
    {


        public InputArgAttribute()
            : this(string.Empty)
        { }


        public InputArgAttribute(int position, string description = null, string identifier = null)
            : this(description, identifier)
        {
            this.position = position;

        }

        public InputArgAttribute(string description)
            : this(description, string.Empty)
        {


        }

        public InputArgAttribute(string description, string identifier)
        {
            this.identifier = identifier ?? string.Empty;
            this.description = description ?? string.Empty;

        }

        public string identifier { get; }

        public string description { get; }

        public int? position { get; }

        public override string ToString()
            => string.IsNullOrEmpty(identifier) ? description : $"{identifier} {description}";

    }

}