using System;
using System.Collections.Generic;
using System.Text;

using DocDataWSNameSpace;

namespace docdata_sdk_dotnet
{
    public class DDWSException : System.Exception
    {
        public error wsError { get; set; }

        public DDWSException(error wsError)
        {
            this.wsError = wsError;
        }
    }
}
