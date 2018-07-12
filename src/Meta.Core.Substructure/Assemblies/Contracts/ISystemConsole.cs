//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

/// <summary>
/// Defines basic contract for console/shell interaction
/// </summary>
public interface ISystemConsole
{
    int Height { get; set; }

    int Width { get; set; }

    ConsoleColor BackgroundColor { get; set; }

    ConsoleColor TextColor { get; set; }

    void WriteLine(string text);

    void WriteLine(object o);

    void Write(IAppMessage message, AppMessageFormatter formatter = null);

    void Write(string txt);

    string ReadLine();

    char ReadKey();

    char? ReadKey(int timeout);

    void Clear();


}



