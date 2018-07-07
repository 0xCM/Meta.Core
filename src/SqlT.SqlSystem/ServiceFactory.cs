//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    public static class ServiceFactory
    {

        public static ISqlMetadataCapture SqlMetadataCapture(this IApplicationContext C)
            => C.Service<ISqlMetadataCapture>();

    }
}
