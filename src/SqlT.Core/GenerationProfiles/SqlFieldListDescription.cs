//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System.ComponentModel;

    /// <summary>
    /// Characterizes a structural field list
    /// </summary>
    [Description("Characterizes a structural field list")]
    public class SqlFieldListDescription
    {
        public SqlFieldListDescription()
        {
            this.ListName = string.Empty;
            this.RowSource = string.Empty;
            this.IdentifierColumn = string.Empty;
            this.TableType = string.Empty;
            this.TypedIdentifierType = string.Empty;
            this.IdentifierValueColumn = string.Empty;
            this.RowSourceType = GenerationRowSourceKind.Table;                   
        }

        /// <summary>
        /// The name of the generated list
        /// </summary>
        [Description("The name of the generated list")]
        public string ListName { get; set; }

        /// <summary>
        /// The schema-qualified name of the object from which the list items will be constructed
        /// </summary>
        [Description("The schema-qualified name of the object from which the list items will be constructed")]
        public string RowSource { get; set; }

        /// <summary>
        /// The source that will be queried to obtain the list item rows; defaults to table if unspecified
        /// </summary>
        [Description("The source that will be queried to obtain the list item rows")]
        public GenerationRowSourceKind RowSourceType { get; set; }
        

        /// <summary>
        /// The name of the column in the source table that determines the programmatic identifier
        /// </summary>
        [Description("The name of the column in the source table that determines the programmatic identifier")]
        public string IdentifierColumn { get; set; }

        /// <summary>
        /// If specified, indicates the type name of the table data type on which the list will be based
        /// </summary>
        [Description("If specified, indicates the type name of the table data type on which the list will be based")]
        public string TableType { get; set; }

        /// <summary>
        /// If specified, indicates the type name of the typed identifier upon which to base the list
        /// </summary>
        [Description("If specified, indicates the type name of the typed identifier upon which to base the list")]
        public string TypedIdentifierType { get; set; }

        /// <summary>
        /// If specified, indicates the name of the column to use for the typed identifier value
        /// </summary>
        [Description("If specified, indicates the column used to determine the value of a typed identifier field")]
        public string IdentifierValueColumn { get; set; }

        public override string ToString()
            => $"{RowSource} => {ListName}";
    }
}