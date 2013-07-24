using System;
using System.Collections.Generic;
using System.Text;

using DocDataWSNameSpace;

namespace docdata_sdk_dotnet
{
    public class DDTokenNotRecognizedException : System.Exception
    {
        public String key { get; set; }

        public DDTokenNotRecognizedException(String key)
        {
            this.key = key;
        }
    }
}
