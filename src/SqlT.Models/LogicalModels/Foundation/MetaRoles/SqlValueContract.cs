//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    /// <summary>
    /// Identifies a role played by a parameter, column or other data value
    /// </summary>
    public class SqlValueContract : ValueObject<SqlValueContract>
    {
      

        public SqlValueContract(string RoleName)
        {
            this.CategoryName = RoleName;
        }

        public string CategoryName { get; }

        public string ParameterName { get; }

        public override string ToString()
            => CategoryName;
    }

}
