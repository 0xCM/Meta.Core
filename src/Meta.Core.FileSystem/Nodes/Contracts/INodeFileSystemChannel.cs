namespace Meta.Core.Resources
{
    public interface INodeFileSystemChannel 
    {
        Option<FilePath> TransferFile(NodeFlow flow, SystemResourceUrn urn);
        Option<string> TransferFiles<S>(NodeFlow flow, string match = null)
            where S : CatalogSubject<S>;

    }
}