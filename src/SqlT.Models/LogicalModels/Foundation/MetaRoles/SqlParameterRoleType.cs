namespace SqlT.Models
{
    /// <summary>
    /// Classifies the role played by a query parameter
    /// </summary>
    /// <remarks>
    /// The literals defined here must match the entries in the ParameterUsage table in the reference database
    /// </remarks>
    public enum QueryParameterRole
    {
        /// <summary>
        /// No usage has been specified
        /// </summary>
        None = 0,

        /// <summary>
        /// Parameter specifies a database server
        /// </summary>
        Server = 1,

        /// <summary>
        /// Parameter specifies a database catalog
        /// </summary>
        Catalog = 2,

        /// <summary>
        /// Parameter specifies the maximum number of records that may be retrieved per execution
        /// </summary>
        ResultLimit = 3,

        /// <summary>
        /// Parameter specifies a sequence number
        /// </summary>
        SequentialMarker = 4,

        /// <summary>
        /// Parameter specifies the name of a schema
        /// </summary>
        SchemaName = 5,

        /// <summary>
        /// Parameter specifies the name of a table
        /// </summary>
        TableName = 6,

        /// <summary>
        /// Parameter specified the inclusive lower bound of a period of time
        /// </summary>
        MinTimestamp = 7,

        /// <summary>
        /// Parameter specified the inclusive upper bound of a period of time
        /// </summary>
        MaxTimestamp = 8,

        /// <summary>
        /// Parameter specifies a point in time from which changes are calculated
        /// </summary>
        ChangeMarker = 9
    }
}
