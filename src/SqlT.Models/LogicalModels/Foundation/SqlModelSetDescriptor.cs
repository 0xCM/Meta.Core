//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    public class SqlModelSetDescriptor : ValueObject<SqlModelSetDescriptor>
    {
        public readonly string ModelIdentifier;
        public readonly SemanticVersion ModelVersion;
        public readonly string Description;

        public SqlModelSetDescriptor
        (
            string ModelIdentifier, 
            SemanticVersion ModelVersion, 
            string Description
        )  
        {
            this.ModelIdentifier = ModelIdentifier;
            this.ModelVersion = ModelVersion;
            this.Description = Description;
        }

    }
}
