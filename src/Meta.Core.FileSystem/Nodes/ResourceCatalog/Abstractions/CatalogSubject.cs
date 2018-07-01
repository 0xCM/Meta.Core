//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Resources
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;

    using static metacore;
    

    public abstract class CatalogSubject : INodeCatalogSubject
    {
        string DeriveRelativeLocation()
            => string.Join("/", Parent.RelativeLocation, Name);

        protected CatalogSubject(SystemResourceScheme Scheme, string host, string Name, INodeCatalogSubject Parent = null)
        {
            this.Parent = Parent;
            this.Scheme = Scheme;
            this.IsRoot = Parent == null;
            this.SymbolicHost = host;
            this.Name = IsRoot ? $"/{host}/{Name}" : Name;
            this.Lineage = DeriveLineage().ToList();
            this.RelativeLocation = IsRoot ? this.Name : DeriveRelativeLocation();
            this.Urn = DeriveUrn();
            this.LineageSegments = Urn.NonSchemeComponents.Zip(RelativeLocation.Split('/'), (x, y) => (x, y)).ToList();
            this.Segment = (Urn.ToString(), RelativeLocation.ToString());           
        }

        protected CatalogSubject(SystemUri Uri, INodeCatalogSubject Parent = null)
            : this(new SystemResourceScheme(Uri.Scheme), Uri.Host, Uri.Path, Parent)
        {

        }
        
        SystemResourceScheme Scheme { get; }

        public INodeCatalogSubject Parent { get; }

        public string Name { get; }

        public string SymbolicHost { get; }

        public bool IsRoot { get; }

        public IReadOnlyList<INodeCatalogSubject> Lineage { get; }

        public SystemResourceUrn Urn { get; }

        public string RelativeLocation { get; }


        public (string name, string locator) Segment { get; }

        public IReadOnlyList<(string name, string locator)> LineageSegments { get; }


        IEnumerable<INodeCatalogSubject> DeriveLineage()
        {
            yield return this;
            var ancestor = Parent;
            while (ancestor != null)
            {
                yield return ancestor;
                ancestor = ancestor.Parent;
            }
            
        }

        SystemResourceUrn DeriveUrn()
        {
            var t = GetType();
            if(!t.IsNested)
                return new SystemResourceUrn(Scheme, RelativeLocation);
            else
            {
                var components = t.FullName.Replace("lib.", SymbolicHost + "/").Split('+');
                return SystemResourceUrn.FromComponents(Scheme, components);
            }

        }


        public Uri ToLocalUri(FileName file = null)
        {
            var components = map(Lineage.Reverse().ToList(), x => x.Name);
            var directory = FolderPath.Parse(string.Join("/", components));
            if (file != null)
                return new Uri((directory + file).FileSystemPath);
            else
                return new Uri(directory.FileSystemPath);


        }



        public override string ToString()
            =>  Urn.ToString();
                    
    }

    public abstract class CatalogSubject<T> : CatalogSubject
        where T : CatalogSubject<T>
    {

        protected CatalogSubject(SystemResourceScheme scheme, string host, string name)
            : base(scheme, host, name)
        {

        }

        protected CatalogSubject(SystemUri uri)
            : base(uri)
        {

        }

        protected CatalogSubject(string name, INodeCatalogSubject parent)
            : base(parent.Urn.Scheme, parent.SymbolicHost,  name, parent)
        { }

    }


}