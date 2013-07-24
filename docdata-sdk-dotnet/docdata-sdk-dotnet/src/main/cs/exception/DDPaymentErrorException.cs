using System;
using System.Collections.Generic;
using System.Text;

using DocDataWSNameSpace;

namespace docdata_sdk_dotnet
{
    public class DDPaymentErrorException : System.Exception
    {
        public String key { get; set; }
        public paymentResponsePaymentError paymentError { get; set; }

        public DDPaymentErrorException(String key, paymentResponsePaymentError paymentError)
        {
            this.key = key;
            this.paymentError = paymentError;
        }
    }
}
