//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Data;
    using System.Data.SqlClient;

    using static metacore;
    
    public class SqlCopier : ISqlCopier
    {
        internal static SqlBulkCopy Create(SqlCopyOptions options, Action<int> observer = null)
        {
            var flags = SqlBulkCopyOptions.TableLock | SqlBulkCopyOptions.KeepNulls;
            if (options.Atomic)
                flags |= SqlBulkCopyOptions.UseInternalTransaction;

            if (options.TargetConnector.IsNone())
                throw new Exception("No target connection string is specified");

            var bcp = new SqlBulkCopy(options.TargetConnector.ValueOrDefault(), flags);

            var lastTotalCount = 0;
            Func<long, int> lastCount = (newTotalCount) =>
            {
                var last = newTotalCount - lastTotalCount;
                lastTotalCount = (int)newTotalCount;
                return (int)last;
            };

            if(options.BatchSize != null)
                bcp.BatchSize = options.BatchSize.Value;
            bcp.BulkCopyTimeout = options.Timeout;
            bcp.NotifyAfter = bcp.BatchSize;
            bcp.SqlRowsCopied += (sender, args)
                => observer?.Invoke(lastCount(args.RowsCopied));

            options.TargetTableName.OnSome(name => bcp.DestinationTableName = name);
            options.TableAssociation.OnSome(a =>
                {
                    iter(a.ToBcpMappings(), 
                        m => bcp.ColumnMappings.Add(m));
                    bcp.DestinationTableName = a.TargetTable;
                });

            return bcp;
        }


        public SqlCopier(SqlCopyOptions options, Action<int> observer = null)
        {
            this.options = options;
            this.observer = observer ?? (i => { });
            this.flags = 
                 SqlBulkCopyOptions.TableLock
               | SqlBulkCopyOptions.KeepNulls
               | SqlBulkCopyOptions.UseInternalTransaction;
        }

        SqlCopyOptions options { get; }

        Action<int> observer { get; }

        SqlBulkCopyOptions flags { get; }

        public SqlOutcome<int> CopyFrom(SqlDataFrame source)
        {
            using (var reader = source.GetReader())
                return CopyFrom(reader);
        }

        public SqlOutcome<int> CopyFrom(IDataReader reader)
        {

            using (var bcp = new SqlBulkCopy(options.TargetConnector.ValueOrDefault(), flags))
            {
                var lastTotal = 0;
                Func<long, int> lastCount = (newTotal) 
                    => 
                    {
                        var batchTotal = newTotal - lastTotal;
                        lastTotal = (int)newTotal;
                        return (int)batchTotal;
                    };

                if(options.BatchSize != null)
                    bcp.BatchSize = options.BatchSize.Value;
                bcp.BulkCopyTimeout = options.Timeout;
                bcp.NotifyAfter = bcp.BatchSize;
                bcp.SqlRowsCopied += (sender, args)
                    => observer.Invoke(lastCount(args.RowsCopied));

                options.TargetTableName.OnSome(
                    name => bcp.DestinationTableName = name);

                options.TableAssociation.OnSome(
                    a => iter(a.ToBcpMappings(),
                        m => bcp.ColumnMappings.Add(m)));

                options.TableAssociation.OnSome(
                    a => bcp.DestinationTableName = a.TargetTable);

                bcp.WriteToServer(reader);
                return bcp.RowsCopied();
            }
        }
    }

}
