//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.SqlClient;

    /// <summary>
    /// Encapsulates a potential value returned by a databse operation proxy or framework-level method. 
    /// By definition, value is specified if and only if the invoked operation succeeded
    /// </summary>
    /// <typeparam name="P">The type of the potential value</typeparam>
    public struct SqlOutcome<P> : ISqlOutcome
    {

        public static implicit operator Option<P>(SqlOutcome<P> outcome)
            => outcome.ToOption();


        public static SqlOutcome<P> Fail(IApplicationMessage Reason)
            => new SqlOutcome<P>(Reason);

        
        /// <summary>
        /// Unwraps the potential value if it exists; otherwise, raises an exception
        /// </summary>
        /// <param name="x">The outcome to evaluate</param>
        /// <returns></returns>
        public static P operator ~ (SqlOutcome<P> x)
        {
            if (x.Failed)
                throw new Exception(x.Message.IsEmpty ? "Reason for failure unknown" : x.Message.MessageText);                
            return x.Payload;
        }

        public static bool operator == (SqlOutcome<P> x, SqlOutcome<P> y) 
            => x.Succeeded && y.Succeeded && x.Payload.Equals(y.Payload);

        public static bool operator != (SqlOutcome<P> x, SqlOutcome<P> y) 
            => !(x == y);

        public static bool operator true(SqlOutcome<P> x)
            => x.Succeeded;
        public static bool operator false(SqlOutcome<P> x) 
            => !x.Succeeded;

        public static implicit operator bool(SqlOutcome<P> x)
            => x.Succeeded;

        public static bool operator !(SqlOutcome<P> x)
            => !x.Succeeded;

        public static implicit operator SqlOutcome<P>(P x) 
            => new SqlOutcome<P>(x);

        public static implicit operator SqlOutcome<bool>(SqlOutcome<P> x) 
            => x.Failed 
            ? new SqlOutcome<bool>(false, x.Messages.ToArray()) 
            : new SqlOutcome<bool>(true, x.Messages.ToArray());

        public readonly bool Succeeded;
        public readonly P Payload;
        public IReadOnlyList<SqlMessage> Messages;
        public readonly SqlMessage Message;
        public readonly string Sql;

        public SqlOutcome(SqlException e)
        {
            this.Sql = string.Empty;
            this.Succeeded = false;
            this.Messages = e.ErrorMessages().ToList();
            this.Payload = default(P);
            this.Message = Messages.FirstOrDefault() ?? new SqlMessage(e.Message);
        }

        static SqlMessage CreateErrorMessage(SqlException e, string sql)
        {
            var message = new StringBuilder();
            foreach (var m in e.ErrorMessages())
                message.AppendLine(m);
            message.AppendLine(sql);
            return new SqlMessage(message.ToString());

        }

        static SqlMessage CreateErrorMessage(Exception e, string sql)        
            =>   new SqlMessage($"{e.Message} {sql ?? string.Empty}");

        

        public SqlOutcome(SqlException e, string sql = null)
        {
            this.Sql = sql;
            this.Messages = e.ErrorMessages().ToList();
            this.Message = CreateErrorMessage(e, sql);
            this.Succeeded = false;
            this.Payload = default(P);

        }

        public SqlOutcome(IApplicationMessage Message)
        {
            this.Sql = string.Empty;
            this.Message = new SqlMessage(Message.Format(false));
            this.Messages = new SqlMessage[] { this.Message};
            this.Succeeded = false;
            this.Payload = default(P);
        }



        public SqlOutcome(Exception e, string sql = null)
        {
            this.Sql = string.Empty;
            this.Messages = new[] { new SqlErrorMessage(e) };
            this.Succeeded = false;
            this.Message = CreateErrorMessage(e, sql);
            this.Payload = default(P);
        }


        public SqlOutcome(params SqlMessage[] Messages)
        {
            this.Sql = string.Empty;
            this.Succeeded = false;
            this.Messages = Messages;
            this.Payload = default(P);
            this.Message = this.Messages[0];
        }


        SqlOutcome(P Payload, bool Succeeded, params SqlMessage[] Messages)
        {
            this.Sql = string.Empty;           
            this.Succeeded = Succeeded;
            this.Payload = Payload;
            this.Messages = Messages.ToList();
            this.Message = Messages.Length != 0 ? Messages[0] : SqlMessage.Empty;
        }

        public SqlOutcome(P Payload, params SqlMessage[] Messages)
        {

            this.Sql = string.Empty;
            this.Succeeded = true;
            this.Payload = Payload;
            this.Messages = Messages.ToList();
            this.Message = Messages.Length != 0 ? Messages[0] : SqlMessage.Empty;
        }


        public bool Failed 
            => !Succeeded;

        public SqlOutcome<P> WithNewMessage(string Message)        
            => new SqlOutcome<P>(Payload, Succeeded, new SqlMessage(Message));
        
            

        public SqlOutcome<P> OnSuccess(Action<P> f)
        {
            if (Succeeded)
                f(Payload);
            return this;
        }

        public SqlOutcome<P> OnSuccess(Func<P, SqlMessage> f)
        {
            if (Succeeded)
                return new SqlOutcome<P>(Payload,  f(Payload));
            return this;
        }

        public SqlOutcome<P> OnFailure(Func<SqlMessage, SqlMessage> f)
        {
            if (Failed)
                return new SqlOutcome<P>(f(new SqlMessage(Messages.First())));
            else
                return this;
        }

        public SqlOutcome<P> OnFailure(Action<SqlErrorMessage> f)
        {
            if (Failed)
                f(new SqlErrorMessage(Messages.Render()));
            return this;
        }

        public SqlOutcome<X> Map<X>(Func<P, SqlOutcome<X>> success)
            => Succeeded ? success(Payload) : new SqlOutcome<X>(Messages.ToArray());

        public override string ToString() 
            => Succeeded ? Payload.ToString() : Messages.FirstOrDefault()?.ToString() ?? String.Empty;

        public SqlOutcome<X> Failure<X>()
            => new SqlOutcome<X>(Messages.ToArray());

        public SqlOutcome<X> Evaluate<X>(Func<P,X> onSuccess) 
            => Failed ? new SqlOutcome<X>(Messages.ToArray()) : new SqlOutcome<X>(onSuccess(Payload));

        public override bool Equals(object obj)
        {
            if(Succeeded)
            {
                var other = (SqlOutcome<P>)obj;
                if (other.Succeeded)
                    return Object.Equals(this.Payload, other.Payload);
            }
            return false;           
        }
        public override int GetHashCode()
            => Succeeded ? Payload.GetHashCode() : 0;


        public P PayloadOrDefault(P @default = default(P)) 
            => Succeeded ? Payload : @default;

        public P Require()
        {
            if (Succeeded)
                return Payload;

            throw new Exception($"Payload does not exist: {Message}");
        }

        public P Require(Action<SqlMessage> onFailure)
        {
            if (Failed)
                onFailure(Messages.First());

            return Payload;

        }

        public SqlOutcome<S> TryMapValue<S>(Func<P, S> f)
            => Succeeded ? SqlOutcome.Success(f(Payload), Message) : SqlOutcome.Failure<S>(Message);

        public S MapValueOrElse<S>(Func<P, S> ifSome, Func<S> ifNone)
            => Succeeded ? ifSome(Payload) : ifNone();

        public S MapValueOrElse<S>(Func<P, S> ifSome, Func<SqlMessage,S> ifNone)
            => Succeeded ? ifSome(Payload) : ifNone(Message);

        public S MapValueOrElse<S>(Func<P, SqlMessage, S> ifSome, Func<SqlMessage, S> ifNone)
            => Succeeded ? ifSome(Payload, Message) : ifNone(Message);


        public S MapValueOrDefault<S>(Func<P, S> ifSome)
            => Succeeded ? ifSome(Payload)
                      : (typeof(S) == typeof(string) ? ((S)((object)string.Empty)) : default(S));
        public S MapValueOrDefault<S>(Func<P, S> ifSome, S @default)
            => Succeeded ? ifSome(Payload) : @default;

        bool ISqlOutcome.Succeeded 
            => Succeeded;

        object ISqlOutcome.Payload 
            => Payload;

        SqlMessage ISqlOutcome.Message 
            => Message;

    }


}


