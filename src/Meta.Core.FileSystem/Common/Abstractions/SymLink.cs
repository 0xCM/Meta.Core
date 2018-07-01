//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;


    using static metacore;

    /// <summary>
    /// Represents a symbolic link to a file or folder
    /// </summary>
    /// <typeparam name="S">The source type</typeparam>
    /// <typeparam name="L">The link type</typeparam>
    public abstract class SymLink<S, L>
        where S : IFileSystemObject
        where L : IFileSystemObject
    {

        protected SymLink(S Source, L Link)
        {

            this.Source = Source;
            this.Link = Link;
        }

        public S Source { get; }

        public L Link { get; }

        public override string ToString()
            => $"{Link} --> {Source}";
    }
}