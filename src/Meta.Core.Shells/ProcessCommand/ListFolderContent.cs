//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    [CommandActionSpec("cmd", "dir")]
    public class ListFolderContent : ExternalCommand<ListFolderContent>
    {
        public ListFolderContent()
        {
            Filter = "*.*";
        }

        public ListFolderContent
        (
            string Filter = null,
            bool BareFormat = false,
            bool Recursive = false,
            bool Hidden = false
        ) : this()
        {
            this.Filter = Filter ?? "*.*";
            this.BareFormat = BareFormat;
            this.Recursive = Recursive;

        }

        [CommandParameter(ParameterDescription: "Specifies drive, directory and files to list")]
        public string Filter { get; set; }

        [CommandParameter(ParameterDescription: "Content will be listed without attributes")]
        public bool BareFormat { get; set; }

        [CommandParameter(ParameterDescription: "If true, specifies that directories will be searched recursively; otherwise, the search is restricted to directory as specified by the Filter parameter")]
        public bool Recursive { get; set; }

        public override string FormatValue()
        {
            var sb = new StringBuilder($"/C {ActionName} {Filter}");
            if (BareFormat)
                sb.Append(" /b");
            if (Recursive)
                sb.Append(" /s");
            return sb.ToString();
        }

    }
}