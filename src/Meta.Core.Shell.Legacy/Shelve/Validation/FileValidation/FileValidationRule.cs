//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{

    public abstract class FileValidationRule<R,S> : ValidationRule<R,S>
        where R : FileValidationRule<R,S>
        where S : IFileSystemObject
    {

        protected FileValidationRule(string RuleName)
            : base(RuleName)
        {


        }


        public abstract bool Satisfies(S Subject);
    }

}
