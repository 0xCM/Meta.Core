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

    public class GhciRepl : ReplAdapter<GhciRepl,GhciConfig>
    {
        public static Option<GhciRepl> Create(IApplicationContext C, GhciConfig Config)
            => Try(() => new GhciRepl(C,Config));

        public GhciRepl(IApplicationContext C, GhciConfig Config)
            : base(C, Config) { }
                //=> Shell = ShellAdapter.make(Config.ExePath, string.Join(" ", Config.Args), DataReceiver, ErrorReceiver).Require();

        //ShellAdapter Shell { get; }

        //void OnDataMessage(string message)
        //{
        //    Notify(inform(message));
        //}

        //void OnErrorMessage(string message)
        //{
        //    Notify(error(message));
        //}

        //public void Send(string message)
        //    => DataSender(message);

        //public Action<string> DataSender
        //    => Shell.DataSender;

        //public Action<string> DataReceiver
        //    => OnDataMessage;

        //public Action<string> ErrorReceiver
        //    => OnErrorMessage;


    }

}