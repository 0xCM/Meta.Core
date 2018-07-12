//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// 
// License:MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Meta.Core;
    using SqlT.Core;
    using MetaFlow.Core.Storage;

    using static metacore;

    public class Secure
    {
        Secure CipherString(string s)
            => new Secure(StringCipher.Encrypt(s, PlatformKey.Get()));

        //Secure CipherJson(Json J)
        //    => new Secure(StringCipher.Encrypt(J, PlatformKey.Get()));

        //Json DecipherJson(Secure S)
        //    => StringCipher.Decrypt(S.Content, PlatformKey.Get());

        public string Decipher()
            => StringCipher.Decrypt(Content, PlatformKey.Get());

        public Secure(string Content)
            => this.Content = Content;

        public string Content { get; }

    }
}
