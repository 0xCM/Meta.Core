//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System.ComponentModel;

    [Description("Defines structural field list generation settings")]
    public class SqlFieldListGenerationProfile : CodeGenerationProfile
    {

        public SqlFieldListGenerationProfile()
        {
            this.EmitListedTypes = true;
            this.FieldLists = new SqlFieldListDescription[] { };
            this.ExcludeSystemObjects = true;
            ProfileType = CodeGenerationProfileKind.FieldList;
        }

        /// <summary>
        /// Specifies whether to enable field list generation
        /// </summary>
        [
            Description("Specifies whether to enable field list generation"), 
            DefaultValue(true)
        ]
        public bool EmitListedTypes { get; set; }

        public SqlFieldListDescription[] FieldLists { get; set; }

        /// <summary>
        /// Specifies whether system objects, such as catalog views and other intrinsics should be ignored
        /// </summary>
        [
            Description("Specifies whether system objects, such as catalog views and other intrinsics should be ignored"),
            DefaultValue(true)

        ]
        public bool ExcludeSystemObjects { get; set; }

    }

}