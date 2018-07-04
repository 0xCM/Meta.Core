//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;
    using SqlT.SqlSystem;
    using SqlT.Models;


    public static partial class SqlBrokerExtensions
    {
        public static Option<SqlBooleanValue> Exists(this ISqlSchemaHandle h)
            => h.Database().SystemViews()
                           .GetVirtualView<vSchema>()
                           .Exists(x => x.Name == h.ElementName) 
            ? SqlBooleanValue.True : SqlBooleanValue.False;

        /// <summary>
        /// Creates the schema represented by the handle if it does not exist
        /// </summary>
        /// <param name="h"></param>
        /// <returns></returns>
        public static Option<ConditionalCreateResult> CreateIfMissing(this ISqlSchemaHandle h)
        {
            var exists = h.Exists();
            if (exists.IsNone())
                return exists.ToNone<ConditionalCreateResult>();

            var create = exists.Value() == SqlBooleanValue.False;
            if (create)
            {
                var sql = $"create schema [{h.ElementName}]";
                return h.Database().Broker
                        .ExecuteNonQuery(sql)
                        .ToOption()
                        .Map(_ => ConditionalCreateResult.Created);
            }
            else
                return ConditionalCreateResult.NotCreated;
        }
    }
}