
[SqlProxyBrokerFactory]
class BROKER_FACTORY_NAME : SqlProxyBrokerFactory<BROKER_FACTORY_NAME>
{
    /// <summary>
    /// The name of the catalog that provided the source metadata from
    /// which the proxies were constructed
    /// </summary>
    public const string SourceCatalog = @"SOURCE_CATALOG";

    public static new ISqlProxyBroker CreateBroker(SqlConnectionString cs)
            => ((SqlProxyBrokerFactory<BROKER_FACTORY_NAME>)(new BROKER_FACTORY_NAME())).CreateBroker(cs);

}


