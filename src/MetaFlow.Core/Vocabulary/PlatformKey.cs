//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License:MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using Meta.Core;

    public class PlatformKey
    {
        public static string Encrypt(string Content)
            => StringCipher.Encrypt(Content, new PlatformKey());

        public static string Decrypt(string Content)
            => StringCipher.Decrypt(Content, new PlatformKey());

        public static PlatformKey Get()
            => new PlatformKey();

        PlatformKey() { }

        public static implicit operator string(PlatformKey k)
            => "e1a094a2e5e744afb576762ebe14b1b2";
    }
}
