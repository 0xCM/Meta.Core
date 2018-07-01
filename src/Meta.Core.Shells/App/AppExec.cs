//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Reflection;
    using System.Threading.Tasks;

    using static metacore;

    /// <summary>
    /// The executable endpoint
    /// </summary>
    public class AppExec
    {
        public static readonly AppExec OK = new AppExec(0);
        public static readonly AppExec Error = new AppExec(-1);

        public static implicit operator AppExec(int ResultCode)
            => new AppExec(ResultCode);

        public AppExec(IShellConsole Shell, Task ShellTask)
        {
            this.Shell = some(Shell);
            this.ShellTask = ShellTask;
        }


        public AppExec(int ResultCode)
        {
            this.ResultCode = ResultCode;
        }

        public Option<IShellConsole> Shell { get; }

        public Option<Task> ShellTask { get; }

        public int? ResultCode { get; }
    }


}