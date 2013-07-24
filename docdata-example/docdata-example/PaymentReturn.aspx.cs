using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace docdata_example
{
    public partial class PaymentReturn : System.Web.UI.Page
    {
        public static String RESULT_PARAM = "result";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (null == Request[RESULT_PARAM])
            {
                this.OutputLabel.Text = "Payment was successful!";
            }
            else
            {
                String result = Request[RESULT_PARAM];
                this.OutputLabel.Text = "Payment result: " + result;
            }
        }
    }
}
