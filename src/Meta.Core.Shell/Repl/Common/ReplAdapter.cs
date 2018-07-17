//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    using static metacore;


    public abstract class ReplAdapter<T> : ApplicationComponent
        where T : ReplAdapter<T>
    {
        
        public ReplAdapter(IApplicationContext C, ReplConfig Config)
            : base(C)

        {
            this.Config = Config;
            this.SessionId = concat(today().ToIsoString(), dot(), now().TimeOfDay.TotalSeconds.ToString());
            this.WorkingFolder = Config.WorkingFolder.ValueOrElse(() 
                => FolderPath.CurrentDirectory);
            this.LogFolder = Config.LogFolder.ValueOrElse(() 
                => WorkingFolder + FolderName.Parse(".repl")).CreateIfMissing().Require();
            this.Shell = Shell = ShellAdapter.make(Config.ExePath, string.Join(" ", Config.Args), OnDataMessage, OnErrorMessage).Require();
            this.ErrorLog = LogFolder + FileName.Parse(ReplName + dot() + SessionId).AddExtension("err.log");
            this.MessageLog = LogFolder + FileName.Parse(ReplName + dot() + SessionId).AddExtension("msg.log");
        }


        FilePath MessageLog { get; }

        FilePath ErrorLog { get; }

        protected ReplConfig Config { get; }
        
        protected FolderPath WorkingFolder { get; }

        protected FolderPath LogFolder { get; }

        protected Option<FilePath> LogSent(string data)
            => MessageLog.Append("sent>>" + eol() + data + eol() + "/sent>>" + eol()).Map(_ => MessageLog);
           
        protected Option<FilePath> LogReceipt(string data)
            => MessageLog.AppendLine(data).Map(_ => MessageLog);

        protected Option<FilePath> LogError(string data)
            => ErrorLog.Append(data).Map(_ => ErrorLog);

        void OnDataMessage(string message)
        {
            Notify(inform(message));
            LogReceipt(message).OnNone(Notify);
        }

        void OnErrorMessage(string message)
        {
            Notify(error(message));
            LogError(message).OnNone(Notify);
        }

        public void Send(string message)
        {
            Shell.DataSender(message);
            LogSent(message).OnNone(Notify);
        }

        public virtual string ReplName
            => GetType().Name.Replace("Repl", string.Empty).ToLowerInvariant();

        public string SessionId { get; }

        ShellAdapter Shell { get; }


    }

    public abstract class ReplAdapter<T,C> : ReplAdapter<T>
            where T : ReplAdapter<T>
            where C : ReplConfig<C>
    {
        public ReplAdapter(IApplicationContext C, C Config)
            : base(C, Config)

        {
            this.Config = Config;
        }

        protected new C Config { get; }
    }
}