using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Security;

using docdata_sdk_dotnet;
using DocDataWSNameSpace;

namespace docdata_example
{
    public partial class PaymentExample : System.Web.UI.Page
    {
        // to test, replace this UUIDs with a valid linkID payment token UUID with type "NEW"
        public static String LINKID_NEW_TOKEN = "123456789";

        protected void Page_Load(object sender, EventArgs e)
        {

            // For development purposes, allow any SSL server certificate
            ServicePointManager.ServerCertificateValidationCallback = 
                new RemoteCertificateValidationCallback(WCFUtil.AnyCertificateValidationCallback);

            try
            {
                // Start payment transaction for new linkID token
                // Initialize the order and redirect to the payment menu
                String paymentTransaction = DDOperation.paymentRequestNewToken(LINKID_NEW_TOKEN,
                    ExampleUtil.getOrderReference(), ExampleUtil.AMOUNT, ExampleUtil.CURRENCY,
                    ExampleUtil.getDDConfig(), ExampleUtil.getDDClient());

                // get payment menu URL and redirect
                String paymentMenuURL = DDOperation.getPaymentMenuURL(paymentTransaction,
                    ExampleUtil.AMOUNT, ExampleUtil.CURRENCY, ExampleUtil.CLIENT_LANGUAGE.ToString(),
                    ExampleUtil.getDDConfig(), ExampleUtil.RETURN_SUCCESS_URL, ExampleUtil.CANCEL_SUCCESS_URL,
                    ExampleUtil.PENDING_SUCCESS_URL, ExampleUtil.ERROR_SUCCESS_URL);

                this.OutputLabel.Text = "<p>Payment transaction created...</p>";
                this.OutputLabel.Text += "<a href=\"" + paymentMenuURL + "\">Goto payment menu</a>";
            }
            catch (DDRequestNewTokenCompletedException ex)
            {
                // Side case:
                // Payment for new token is actually an existing token
                // This can happen if DocData failed to communicate to linkID the pretty print
                // Payment will succeed with the payment method attached to this token...
                DDStatusResponse statusResponse = DDOperation.getPaymentOrderStatus(
                    ex.paymentOrderKey, ExampleUtil.getDDConfig());
            }
        }

    }
}
