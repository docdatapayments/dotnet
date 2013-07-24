using System;
using System.Collections.Generic;
using System.Text;

using DocDataWSNameSpace;

namespace docdata_sdk_dotnet
{
    /// <summary>
    /// When a payment request is used for a new token but the payment succeeds because the token is already
    /// linked to another payment method, this exception is thrown.
    /// </summary>
    public class DDRequestNewTokenCompletedException : System.Exception
    {
        public String paymentOrderKey { get; set; }

        public DDRequestNewTokenCompletedException(String paymentOrderKey)
        {
            this.paymentOrderKey = paymentOrderKey;
        }
    }
}
