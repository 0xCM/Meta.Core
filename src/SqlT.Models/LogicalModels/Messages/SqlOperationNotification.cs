//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    public abstract class SqlOperationNotification 
    {
        public SqlOperationNotification()
        {

        }

        public SqlOperationNotification(string actionDescription)
        {
            this.ActionDescription = actionDescription;
        }

        public string ActionDescription { get; set; }


        public override string ToString()
        {
            return ActionDescription;
        }
    }
}
