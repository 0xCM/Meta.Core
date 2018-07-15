//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using static metacore;

    [CommandSpec("tfs")]
    public class MsTfs : CommandSpec<MsTfs, MsTfsResult>
    {
        public enum ToolAction
        {
            /// <summary>
            /// Specifies that files/folders should be added to TFS
            /// </summary>
            Add = 1,

            /// <summary>
            /// Commits pending changes to the current workspace
            /// </summary>
            Checkin = 2,

            /// <summary>
            /// Makes local files writable and changes its pending Change status to "edit" in the workspace.
            /// </summary>
            Checkout = 3,

            /// <summary>
            /// Retrieves a read-only copy of a file from Team Foundation
            /// Server to the workspace and creates folders on disk to contain it.
            /// </summary>
            Get = 4,
        }

        public abstract class ActionSettings
        {
            public string WorkingDirectory { get; set; }
        }

        public abstract class FileManagementSettings : ActionSettings
        {
            [DefaultValue(true)]
            public bool? Recursive { get; set; }

            [DefaultValue(true)]
            public bool? NoPrompt { get; set; }

            public IReadOnlyList<string> ItemList { get; set; }
        }

        public class CheckinSettings : FileManagementSettings
        {
            [DefaultValue("Automated Checkin")]
            public string Comment { get; set; }

            [DefaultValue(true)]
            public bool? OverridePolicy { get; set; }

            [DefaultValue("Automated Checkin")]
            public string OverrideReason { get; set; }
        }
        
        public MsTfs()
        {

        }

        public MsTfs(ToolAction Action, ActionSettings Settings)
        {
            this.Action = Action;
            this.Settings = Settings;
        }

        public ToolAction Action { get; set; }

        public ActionSettings Settings { get; set; }
    }


    public class MsTfsResult
    {

    }


}

