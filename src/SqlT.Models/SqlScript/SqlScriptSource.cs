//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{

    using Meta.Core;

    /// <summary>
    /// Specifies the supported source types from which scripts may be obtained
    /// </summary>
    public enum SqlScriptSourceType
    {
        /// <summary>
        /// Script is defined in an embedded resource
        /// </summary>
        EmbeddedResource,

        /// <summary>
        /// Script is defined in a dacpac
        /// </summary>
        Package,

        /// <summary>
        /// Script is defined in a database table
        /// </summary>
        DataStore
    }

    public class SqlScriptSource : ValueObject<SqlScriptSource>
    {

        public SqlScriptSource(SqlScriptSourceType SourceType, string SourceIdentifier, NodeFolderPath FileSystemLocation = null)
        {
            this.SourceType = SourceType;
            this.SourceIdentifier = SourceIdentifier;
            this.FileSystemLocation = FileSystemLocation;
        }

        /// <summary>
        /// Specifies the type of the script source
        /// </summary>
        public SqlScriptSourceType SourceType { get; }

        /// <summary>
        /// Specifies the script location in the semantics of the <see cref="SourceType"/>
        /// </summary>
        public string SourceIdentifier { get; }

        /// <summary>
        /// The location of the script in the file system, if applicable
        /// </summary>
        public Option<NodeFolderPath> FileSystemLocation { get; }

    }
}
