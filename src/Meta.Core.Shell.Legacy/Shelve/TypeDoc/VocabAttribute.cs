//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;


    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class VocabAttribute : Attribute
    {
        public VocabAttribute(string Term, string Description, [CallerFilePath] string SourcePath = null)
        {
            this.Term = Term;
            this.SourcePath = SourcePath;
        }

        public string Term { get; }

        public string Description { get; }

        public string SourcePath { get; }
    }

}