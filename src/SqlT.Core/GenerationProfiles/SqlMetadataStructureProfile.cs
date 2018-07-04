//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    public class SqlMetadataStructureProfile : CodeGenerationProfile
    {

        public SqlMetadataStructureProfile()
        {
       
            GenerateDatabaseStructures = true;
            GenerateTableStructures = true;
            ProfileType = CodeGenerationProfileKind.MetadataStructure;

        }
       
        /// <summary>
        /// Specifies whether types corresponding to databases should be emitted
        /// </summary>
        public bool GenerateDatabaseStructures { get; set; }

        /// <summary>
        /// Specifies whether types corresponding to tables should be emitted
        /// </summary>
        public bool GenerateTableStructures { get; set; }

        /// <summary>
        /// Specifies the location of a file containing server-qualified 
        /// database names that may be utilized during the structural
        /// generation process depending on the chosen options
        /// </summary>
        public string DatabaseNameFile { get; set; }

        /// <summary>
        /// Specifies the location of a file containing 4-part table names
        /// that may be utilized during the structural generation process 
        /// depending on the chosen options
        /// </summary>
        public string TableNameFile { get; set; }

    }

}



