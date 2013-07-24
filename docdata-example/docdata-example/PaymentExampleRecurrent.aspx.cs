using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Security;

using DocDataWSNameSpace;
using docdata_sdk_dotnet;

namespace docdata_example
{
    public partial class PaymentExampleRecurrent : System.Web.UI.Page
    {
        // to test, replace this UUIDs with a valid linkID payment token UUID with type NOT "NEW"
        public static String LINKID_TOKEN = "5abe98d3-6e99-4efd-9dbd-baa47c8357f6";

        protected void Page_Load(object sender, EventArgs e)
        {

            // For development purposes, allow any SSL server certificate
            ServicePointManager.ServerCertificateValidationCallback = 
                new RemoteCertificateValidationCallback(WCFUtil.AnyCertificateValidationCallback);

            // Start payment transaction for new linkID token
            // Initialize the order and redirect to the payment menu
            DDPaymentResponse paymentResponse = DDOperation.paymentRequest(LINKID_TOKEN,
                    ExampleUtil.getOrderReference(), ExampleUtil.AMOUNT, ExampleUtil.CURRENCY,
                    ExampleUtil.getDDConfig(), ExampleUtil.getDDClient());

            this.OutputLabel.Text = "<h2>Payment finished!</h2>";
            this.OutputLabel.Text += "Transaction ID: " + paymentResponse.paymentOrderKey;
        }
    }
}
