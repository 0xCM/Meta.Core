using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meta.Core.Http
{
    public partial class HttpResultCodes
    {
        public static HttpResultCode Find(int number) => 
            (new HttpResultCodes()).First(x => x.Value == number);

        public static HttpResultCode Find(string name) =>
            (new HttpResultCodes()).First(x => x.Name == name);
    }
}
