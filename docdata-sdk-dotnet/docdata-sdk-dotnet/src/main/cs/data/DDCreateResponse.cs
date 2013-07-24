using System;
using System.Collections.Generic;
using System.Text;

using DocDataWSNameSpace;

namespace docdata_sdk_dotnet
{
    public class DDCreateResponse
    {
        public String paymentOrderKey { get; set; }
        public authorizationStatus paymentState;
        public String paymentId;

        public DDCreateResponse(String paymentOrderKey, paymentResponsePaymentSuccess paymentSuccess)
        {
            this.paymentOrderKey = paymentOrderKey;
            this.paymentState = paymentSuccess.status;
            this.paymentId = paymentSuccess.id;
        }
    }
}
