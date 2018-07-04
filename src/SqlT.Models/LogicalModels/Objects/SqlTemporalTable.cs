namespace SqlT.Models
{
    public abstract class SqlTemporalTable<T,S> : SqlTable<T,S>
        where T : SqlTemporalTable<T,S>, new()
        where S : SqlSchema<S>
    {

        protected SqlTemporalTable(S Schema)
            : base(Schema)
        {

        }

    }
}
