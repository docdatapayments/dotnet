using System;
using System.Collections.Generic;
using System.Text;

using DocDataWSNameSpace;

namespace docdata_sdk_dotnet
{
    public class DDNoPaymentInStatusReportException : System.Exception
    {
        public String message { get; set; }

        public DDNoPaymentInStatusReportException(String message)
        {
            this.message = message;
        }
    }
}
