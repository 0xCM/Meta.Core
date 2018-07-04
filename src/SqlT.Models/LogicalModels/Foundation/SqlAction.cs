//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Meta.Models;
    using Meta.Syntax;

    using SqlT.Core;
    using SqlT.Syntax;


    using static metacore;
    using sxc = SqlT.Syntax.contracts;


    /// <summary>
    /// Represents a non-DDL specification
    /// </summary>
    /// <typeparam name="T">A derived subtype</typeparam>
    public abstract class SqlAction<T> : SqlModel<T>, ISqlAction<T>
        where T : IModel, ISqlAction
    {



        public IReadOnlyList<SqlRoutineParameter> SqlParameters { get; }

        protected IModelType GetActionType()
            => ModelType;

        protected SqlAction(params SqlRoutineParameter[] Parameters)
        {
            this.SqlParameters = rolist(Parameters);
        }

        Option<IName> _ActionName;

        protected SqlAction(IName ActionName, params SqlRoutineParameter[] Parameters)
        {
            this._ActionName = some(ActionName);
            this.SqlParameters = rolist(Parameters);
        }

        public string ActionName
            =>  _ActionName.Map(n => n.ToString(), 
                    () => GetActionType().SpecifyingType.Name);

        public virtual bool RequiresScript 
            => false;        

        public virtual Option<Type> ResultType 
            => none<Type>();

        public Option<SqlRoutineParameter> this[string name]
            => SqlParameters.FirstOrDefault(x => x.ParameterName == name);
        

    }




}
