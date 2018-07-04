//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System.Data;

    /// <summary>
    /// Defines contract for copying data from one source to another by 
    /// means of a <see cref="SqlDataFrame"/> or a <see cref="IDataReader"/>
    /// </summary>
    public interface ISqlCopier
    {
        SqlOutcome<int> CopyFrom(SqlDataFrame source);

        SqlOutcome<int> CopyFrom(IDataReader reader);
    }

}
