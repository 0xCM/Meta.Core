//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using SqlT.Core;
    using System;
    using System.Linq;

    using Meta.Models;

    using static metacore;

    public abstract class SqlModel : IModel
    {

        protected SqlModel()
        {
         
            this.ModelType = new SqlModelType(GetType().ClrType().Require());
        }

        public virtual IModelType ModelType { get; }
    }

    public abstract class SqlModel<M>  : SqlModel
        where M : IModel
    {
        public static ReadOnlyList<ValueMember> ValueMembers { get; }        

        static SqlModel()
        {
            try
            {
                ValueMembers = typeof(M).GetValueMembers();
            }
            catch (Exception e)
            {
                SystemConsole.Get().Write(error(e));
            }
        }

        protected SqlModel()
            : base()
        {
            
        }        
    }

}
