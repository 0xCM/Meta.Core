//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.DTO
{

    public sealed class DtoModel
    {
        public DtoModel(string ModelName, DtoTypes DefinedTypes)
        {
            this.ModelName = ModelName;
            this.DefinedTypes = DefinedTypes;
        }

        public string ModelName { get; }

        public DtoTypes DefinedTypes { get; }

        public override string ToString()
            => ModelName;
    }


}