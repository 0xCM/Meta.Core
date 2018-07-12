//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// 
// License:MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Diagnostics;

    using Meta.Core;

    using SqlT.Core;
    using SqlT.Workflow;

    using MetaFlow.Core;

    using static metacore;

    using N = SystemNode;

    public static class ContextX
    {
        public static ISystemContext SystemContext(this INodeContext C, SystemIdentifier System)
            => new SystemContext(C, System);

        public static ISystemContext SystemContext(this IApplicationContext C, N Host, SystemIdentifier System)
            => C.NodeContext(Host).SystemContext(System);

        public static IConfigurationService<T> Configuration<T>(this INodeContext C)
            where T : class, ISqlTableTypeProxy, new()
            => C.Service<IConfigurationService>(typeof(T).Name) as IConfigurationService<T>;

        public static IConfigurationService<T> Configuration<T>(this IApplicationContext C)
            where T : class, ISqlTableTypeProxy, new()
            => C.NodeContext(C.ExecutingNode()).Configuration<T>();

        public static N ExecutingNode(this IApplicationContext C)
            => N.Local;

        public static void InvokeExternalTool(this IApplicationContext C, FilePath tool, IEnumerable<object> toolArgs)
        {
            var processArgs = string.Join(" ", toolArgs);

            var process = System.Diagnostics.Process.Start(
                new ProcessStartInfo
                {
                    FileName = tool,
                    Arguments = processArgs,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false
                });

            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            process.OutputDataReceived += (sender, eventArgs)
                =>
            {
                if (isNotBlank(eventArgs.Data))
                    C.NotifyStatus(eventArgs.Data);
            };
            process.ErrorDataReceived += (sender, eventArgs)
                =>
            {
                if (isNotBlank(eventArgs.Data))
                    C.NotifyError(eventArgs.Data);
            };

            process.WaitForExit();

            C.Notify(inform($"Executed tool {tool.FileSystemPath}"));
        }

        public static IAppMessage Notify(this IApplicationContext C, SqlMessage message,
                [CallerMemberName] string callerFile = null,
                [CallerMemberName] string callerName = null)
            => C.Notify(message.IsErrorMessage
                         ? AppMessage.Error(message.MessageText, callerFile, callerName)
                         : AppMessage.Inform(message.MessageText, callerFile, callerName));


        public static SystemIdentifier ToSystemIdentifier(this PlatformSystemKind kind)
            => kind.ToString();

        public static PlatformSqlSettings StoreSettings(this IApplicationContext C)
            => C.Settings<PlatformSqlSettings>();

        public static IAppMessage ToApplicationMessage(this SqlNotification n)
            => AppMessage.Inform(n.Detail);

        public static void SqlObserver(this IApplicationContext C, SqlNotification n)
            => C.Notify(n.ToApplicationMessage());

        static void Notify(this IApplicationContext C, SqlNotification n)
            => C.NotifyStatus($"{n}");

        public static NodeFilePath NodeFile(this N n, FilePath AbsolutePath)
            => new NodeFilePath(n, AbsolutePath);
    }
}


