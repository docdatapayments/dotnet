using System;
using System.Collections.Generic;
using System.Text;

namespace docdata_sdk_dotnet
{
    public class DDPaymentResponse
    {
        public String paymentOrderKey { get; set; }
        public String paymentId { get; set; }
        public DDStatusResponse statusReponse { get; set; }

        public DDPaymentResponse(String paymentOrderKey, String paymentId, DDStatusResponse statusResponse)
        {
            this.paymentOrderKey = paymentOrderKey;
            this.paymentId = paymentId;
            this.statusReponse = statusReponse;
        }

    }
}
