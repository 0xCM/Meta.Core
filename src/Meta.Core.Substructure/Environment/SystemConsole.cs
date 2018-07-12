//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Diagnostics.Tracing;
using System.Threading;

/// <summary>
/// Mediates access to the system console
/// </summary>
/// <remarks>
/// Access to the system console is serialized via a critical section and notifications are 
/// displayed with a color-coding that indicates the trace/severity level of the notification
/// </remarks>
public class SystemConsole : ISystemConsole
{
    public static class InitSettings
    {

        static InitSettings()
        {

            Width = 120;
            Height = 50;
        }

        public static void Reset()
        {

            Width = null;
            Height = null;
            TextColor = null;
            BackgroundColor = null;
            Clear = false;
        }

        public static int? Width { get; set; }

        public static int? Height { get; set; }

        public static ConsoleColor? TextColor { get; set; }

        public static ConsoleColor? BackgroundColor { get; set; }

        public static bool Clear { get; set; }
        
    }

    public static ISystemConsole Get() 
        => instance.Value;

    static Lazy<SystemConsole> instance  
        = new Lazy<SystemConsole>(() => new SystemConsole());

    static object locker = new object();
    

    AutoResetEvent KeyPressSignal = new AutoResetEvent(false);
    char? LastKeyPressValue;
    Thread ConsoleMonitor;

    SystemConsole()
    {
        InitSettings.Width.OnValue(v => Width = v);
        InitSettings.Height.OnValue(v => Height = v);
        InitSettings.TextColor.OnValue(v => TextColor = v);
        InitSettings.BackgroundColor.OnValue(v => BackgroundColor = v);       
        if (InitSettings.Clear)
            Clear();
        
    }


    public int Height
    {
        get
        {
            return Console.WindowHeight;
        }
        set
        {
            try
            {
                Console.WindowHeight = Math.Min(Console.LargestWindowHeight, value);
            }
            catch
            {
                Console.WriteLine("Could not set the console height");
            }
        }
    }

    public int Width
    {
        get
        {
            return Console.WindowWidth;
        }
        set
        {
            try
            {
                Console.WindowWidth = Math.Min(Console.LargestWindowWidth, value);
            }
            catch
            {
                Console.WriteLine("Could not set the console width");
            }
        }
    }

    public ConsoleColor BackgroundColor
    {
        get
        {
            return Console.BackgroundColor;
        }
        set
        {
            try
            {
                Console.BackgroundColor = value;
            }
            catch
            {
                Console.WriteLine("Could not set the console background");
            }
                
        }
    }

    public ConsoleColor TextColor
    {
        get
        {
            return Console.ForegroundColor;
        }
        set
        {
            try
            {
                Console.ForegroundColor = value;
            }
            catch
            {
                Console.WriteLine("Could not set the console foreground");
            }

        }
    }

    public void WriteLine(string text) 
        => Console.WriteLine(text);

    public void WriteLine(object o)
        => WriteLine(o.ToString());

    public void Write(string text) 
        => Console.Write(text);

    public string ReadLine() 
        => Console.ReadLine();


    public char ReadKey() 
        => Console.ReadKey().KeyChar;

    public void Clear()
    {
        try
        {
            Console.Clear();
        }
        catch
        {
            Console.WriteLine("Could not clear the console");
        }
    }

    public char? WaitForKey(string prompt, int timeout)
    {
        if (!string.IsNullOrWhiteSpace(prompt))
            WriteLine(prompt);
        return ReadKey(timeout);
    }

    public char? ReadKey(int timeout)
    {
        if(ConsoleMonitor == null)
        {
            ConsoleMonitor = 
                new Thread(new ThreadStart(() 
                => {
                        while (true)
                        {
                            LastKeyPressValue = ReadKey();
                            KeyPressSignal.Set();
                        }
                    })) { IsBackground = true};
            ConsoleMonitor.Start();
        }

        return  KeyPressSignal.WaitOne(timeout)  ? LastKeyPressValue : null;                                
    }
   
    public void Write(IAppMessage message, AppMessageFormatter formatter)
    {

        lock (locker)
        {
            var currentTextColor = TextColor;
            var currentBGColor = BackgroundColor;
            switch (message.EventLevel)
            {
                case EventLevel.Verbose:
                    TextColor = ConsoleColor.Gray;
                    break;
                case EventLevel.Informational:
                case EventLevel.LogAlways:
                    TextColor = ConsoleColor.DarkGreen;
                    break;
                case EventLevel.Warning:
                    TextColor = ConsoleColor.DarkYellow;
                    break;
                case EventLevel.Error:
                    TextColor = ConsoleColor.Red;
                    break;
                case EventLevel.Critical:
                    TextColor = ConsoleColor.Red;
                    BackgroundColor = ConsoleColor.Yellow;
                    break;
            }
            var output = formatter != null ? formatter(message) : message.Format();
            Console.WriteLine(output);
            Console.BackgroundColor = currentBGColor;
            Console.ForegroundColor = currentTextColor;
        }

    }

}

