//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Build
{
    partial class BuildSyntax
    {
        /// <summary>
        /// Records common and well-known project item types
        /// </summary>
        public sealed class StandardItemTypes : TypedItemList<StandardItemTypes, ProjectItemType>
        {

            /// <summary>
            /// Identifies a file in a project that is to be included in the build
            /// </summary>
            public static readonly ProjectItemType Build = new ProjectItemType("Build");

            /// <summary>
            /// Identifies a file in a project that is to be compiled
            /// </summary>
            public static readonly ProjectItemType Compile = new ProjectItemType("Compile");

            /// <summary>
            /// Identifies a file in a project that is not to be included in the build
            /// </summary>
            public static readonly ProjectItemType None = new ProjectItemType("None");

            /// <summary>
            /// Identifies a folder in a project
            /// </summary>
            public static readonly ProjectItemType Folder = new ProjectItemType("Folder");

            /// <summary>
            /// Identifes an asembly reference
            /// </summary>
            public static readonly ProjectItemType Reference = new ProjectItemType("Reference");

            public static ProjectItemType InferItemType(FileName ItemName)
            {
                string extension = ItemName.Extension.Value.ToLower();
                switch (extension)
                {
                    case "cs": return Compile;
                    case "sql": return Build;
                    case "dll": return Reference;
                    default:
                        return None;
                }
            }
        }


    }
}