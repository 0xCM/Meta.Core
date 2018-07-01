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
        /// Records well-known item types specific to SSDT projects
        /// </summary>
        public sealed class StandardSqlItemTypes : TypedItemList<StandardSqlItemTypes , ProjectItemType>
        {
            /// <summary>
            /// Identifies the path to the emitted DAC file
            /// </summary>
            public static readonly ProjectItemType Build = new ProjectItemType("SqlTarget");

            /// <summary>
            /// Identifies a refactor log
            /// </summary>
            public static readonly ProjectItemType RefactorLog = new ProjectItemType("RefactorLog");

            /// <summary>
            /// Identifies a script that is executed prior to deployment
            /// </summary>
            public static readonly ProjectItemType PreDeploy = new ProjectItemType("PreDeploy");

            /// <summary>
            /// Identifies a script that is executed following deployment
            /// </summary>
            public static readonly ProjectItemType PostDeploy = new ProjectItemType("PostDeploy");

        }


    }
}