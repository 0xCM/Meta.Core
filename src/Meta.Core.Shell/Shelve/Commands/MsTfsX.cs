//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Commands
{
    using System;
    using System.Text;

    using static metacore;

    using static MsTfs;

    [CommandPattern]
    public class MsTfsX : CommandProcessPattern<MsTfsX, MsTfs, MsTfsResult>
    {
        public MsTfsX(IApplicationContext context)
            : base(context)
        { }

        protected override FileName ExecutableName
            => "tf.exe";

        protected override string GetWorkingDirectory(MsTfs spec)
            => spec.Settings.WorkingDirectory;


        protected override string FormatArguments(MsTfs spec)
        {
            var sb = new StringBuilder("vc");

            Action<FileManagementSettings> AddItems = settings
                => iter(settings.ItemList, item => sb.AppendFormat(" {0}", item));

            Action<FileManagementSettings> SetOptions = settings =>
            {
                settings.Recursive.OnValue(value => sb.Append(value ? " /recursive" : String.Empty));
                settings.NoPrompt.OnValue(value => sb.Append(value ? " /noprompt" : String.Empty));

            };

            switch (spec.Action)
            {

                case ToolAction.Checkin:
                    var settings = SupplyDefaults(spec.Settings as CheckinSettings);
                    AddItems(settings);
                    sb.Append($" /comment:{enquote(settings.Comment)}");
                    if (settings.OverridePolicy.GetValueOrDefault())
                        sb.Append($" /override:{enquote(settings.OverrideReason)}");
                    SetOptions(settings);
                    break;
                case ToolAction.Add:
                    break;
                case ToolAction.Checkout:
                    break;
                case ToolAction.Get:
                    break;
            }
            var format = sb.ToString();
            return format;
        }

        protected override Option<MsTfsResult> InterpretOutome(CommandProcessExecutionLog log)
            => log.ExitCode == 0  ? some(new MsTfsResult()) : none<MsTfsResult>();
    }
}