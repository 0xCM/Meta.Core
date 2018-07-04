//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System.ComponentModel;

    /// <summary>
    /// Enumerates common/well-known classes of tables and defines the allowable values 
    /// for the <see cref="SqlPropertyNames.TableRole"/> property
    /// </summary>
    public enum SqlTableRoleType
    {

        /// <summary>
        /// Specifies the absence of a role assignment
        /// </summary>
        [Description("Specifies the absence of a role assignment")]
        Unclassified,

        /// <summary>
        /// Identifies a type table
        /// </summary>
        [Description("Identifies a type table")]
        TypeTable,


        /// <summary>
        /// Specifies that the role is application-defined
        /// </summary>
        ApplicationDefined,


    }


}
