//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Collections;
    
    /// <summary>
    /// An exception to which typed error data can be attached
    /// </summary>
    /// <typeparam name="T">The error data type</typeparam>
    public class Exception<T> : Exception
    {

        public Exception(IAppMessage AppMessage, T Content = default)
        {
            this.AppMessage = AppMessage;
            this.Content = Content;
        }


        public Exception(string reason, string member, string path, int line)
            : base(reason)
        {
            this.AppMessage = global::AppMessage.Empty;
            this.Content = default;
            this.Member = member;
            this.Path = path;
            this.Line = line;
        }

        public Exception(T data, string reason, string member, string path, int line)
            : base(reason)
        {
            this.AppMessage = global::AppMessage.Empty;
            this.Content = data;
            this.Member = member;
            this.Path = path;
            this.Line = line;
        }

        public IAppMessage AppMessage { get; }

        /// <summary>
        /// Data to associate with the exception
        /// </summary>
        public Option<T> Content { get; }

        /// <summary>
        /// The name of the member in which the error occurred
        /// </summary>
        public string Member { get; }

        /// <summary>
        /// The path the the file in which the <see cref="Member"/> is defined
        /// </summary>
        public string Path { get; }

        /// <summary>
        /// The <see cref="Path"/> line number where the error occurred
        /// </summary>
        public int Line { get; }

        public override IDictionary Data
            => Content.MapValueOrDefault(content 
                => new Dictionary<string, T> { ["ErrorData"] = content }, base.Data);

        public override string ToString()
            => $"{Member} | {Path} Line: {Line}: {Message}";
    }
}