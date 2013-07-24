using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Security;

using docdata_sdk_dotnet;
using DocDataWSNameSpace;

namespace docdata_example
{
    public partial class PaymentExampleNoToken : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // For development purposes, allow any SSL server certificate
            ServicePointManager.ServerCertificateValidationCallback = 
                new RemoteCertificateValidationCallback(WCFUtil.AnyCertificateValidationCallback);

                // Start payment transaction
                // Initialize the order and redirect to the payment menu
                String paymentTransaction = DDOperation.paymentRequestWithoutToken(
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
    }
}
