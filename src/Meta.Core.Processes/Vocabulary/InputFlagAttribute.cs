//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Shell
{

    using System;

    using static metacore;


    [AttributeUsage(AttributeTargets.Property)]
    public class InputFlagAttribute : Attribute
    {


        public InputFlagAttribute()           
        {

        }

        public InputFlagAttribute(string RenderAs, string ArgName, string Description)
        {
            this.RenderAs = RenderAs;
            this.ArgName = ArgName;
            this.Description = Description;
        }

        public string RenderAs { get; }

        public string ArgName { get; }

        public string Description { get; }

        public override string ToString()
            => isBlank(RenderAs) 
            ? string.Empty 
            : concat(RenderAs, ifBlank(ArgName,string.Empty));

    }

}