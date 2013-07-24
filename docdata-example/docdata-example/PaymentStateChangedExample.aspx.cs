using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Security;

using docdata_sdk_dotnet;

namespace docdata_example
{
    public partial class PaymentStateChangedExample : System.Web.UI.Page
    {
        public static readonly String ORDER_REF_PARAM = "order_id";


        public static readonly String TXN_ID = "9943a80f-3d33-409d-9dfe-5b0acb7e5a8d";

        protected void Page_Load(object sender, EventArgs e)
        {

            String orderRef = Request[ORDER_REF_PARAM];
            if (null == orderRef)
            {
                this.OutputLabel.Text = "No order reference specified!";
                return;
            }

            // For development purposes, allow any SSL server certificate
            ServicePointManager.ServerCertificateValidationCallback =
                new RemoteCertificateValidationCallback(WCFUtil.AnyCertificateValidationCallback);

            // replace by code that fetches the payment transaction from the specified order reference
            String transactionId = TXN_ID;

            // fetch status
            DDStatusResponse statusResponse = DDOperation.getPaymentOrderStatus(transactionId, 
                ExampleUtil.getDDConfig());

            if (statusResponse.orderPaid || statusResponse.orderWillBePaid)
            {
                this.OutputLabel.Text = "Success, order is paid!";
            }
            else
            {
                this.OutputLabel.Text = "<h2>Order not yet paid</h2>";
                foreach (DDPaymentDetails paymentDetails in statusResponse.paymentDetails)
                {
                    this.OutputLabel.Text += "  * Payment details: status=" + paymentDetails.authorizationStatus + "<br />";
                }
            }
        }
    }
}
