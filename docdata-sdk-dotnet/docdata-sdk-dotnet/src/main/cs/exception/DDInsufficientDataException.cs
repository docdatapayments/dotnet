using System;
using System.Collections.Generic;
using System.Text;

using DocDataWSNameSpace;

namespace docdata_sdk_dotnet
{
    public class DDInsufficientDataException : System.Exception
    {
        public String key { get; set; }

        public DDInsufficientDataException(String key)
        {
            this.key = key;
        }
    }
}
