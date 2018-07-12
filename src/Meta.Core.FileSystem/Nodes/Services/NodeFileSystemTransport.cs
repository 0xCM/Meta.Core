//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Resources
{

    using System;
    using System.Linq;
    using System.Collections.Generic;

    using static metacore;

    using static AppMessage;


    class NodeFileSystemTransport : ApplicationService<NodeFileSystemTransport, INodeFileSystemChannel>, INodeFileSystemChannel
    {

        IResourceCatalog Catalog { get; }
        INodeFileSystemLocator Locator { get; }

        public NodeFileSystemTransport(IApplicationContext C)
            : base(C)
        {
            this.Catalog = C.SubjectCatalog();
            //this.Locator = C.SystemResources();
            
        }

        Option<FilePath> InvokedTransfer(Option<FilePath> result, NodeFlow flow, SystemResourceUrn urn)
        {
            result.Map(
               file => C.Notify(Inform($"{flow.SourceNode}:{file.FileName} ==> {flow.TargetNode}")),
               () => C.Notify(result.Message));
            return result;
        }


        Option<FilePath> TransferFile(NodeFlow flow, SystemResourceUrn urn)
                    => from srcFile in Locator.UncFilePath(flow.SourceNode, urn)
                       from dstFile in Locator.UncFilePath(flow.TargetNode, urn)
                       from result in srcFile.CopyTo(dstFile)
                       select result;

        Option<FilePath> INodeFileSystemChannel.TransferFile(NodeFlow flow, SystemResourceUrn urn)
            => InvokedTransfer(TransferFile(flow, urn),flow,urn); 


        Option<string> Summarize(IEnumerable<Option<FilePath>> results)
            => string.Join($"{eol()}", from result in results
                                let message = result.Message
                                where not(message.IsEmpty)
                                select message.ToString());


        IEnumerable<SystemResourceUrn> Items<S>(S subject, SystemNode Node, string match = null)
            where S : CatalogSubject<S>
        {
            var files = Locator.UncShare(Node, subject).Content(match).ToList();
            foreach (var file in files)
                yield return new SystemResourceUrn(subject.Urn.Scheme, 
                    $"{subject.Urn.EverythingButScheme}/{file.FileName}");

        }

        public Option<string> TransferFiles<S>(NodeFlow flow, string match = null)
            where S : CatalogSubject<S> =>
                Summarize(map(Items(Catalog.Subject<S>(), flow.SourceNode, match), urn => Self.TransferFile(flow, urn)));
    }


}