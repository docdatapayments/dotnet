using System;
using System.Collections.Generic;
using System.Text;

namespace docdata_sdk_dotnet
{
    public class PaymentMenuRequest
    {
        public DDMerchant merchant { get; set; }
        public String language { get; set; }
        public DDPaymentCluster cluster { get; set; }

        public String success { get; set; }
        public String canceled { get; set; }
        public String pending { get; set; }
        public String error { get; set; }

        public String defaultPaymentMethod { get; set; }
        public Boolean skipPaymentChoice { get; set; }

        public PaymentMenuRequest(DDMerchant merchant, String language, DDPaymentCluster cluster)
        {
            this.merchant = merchant;
            this.language = language;
            this.cluster = cluster;
            this.skipPaymentChoice = false;
        }

        public Dictionary<String, String> getParameters()
        {

            Dictionary<String, String> parameters = new Dictionary<string, string>();

            parameters.Add("merchant_name", merchant.name);
            parameters.Add("client_language", language);
            parameters.Add("payment_cluster_key", cluster.key);

            if (null != success)
                parameters.Add("return_url_success", success);
            if (null != canceled)
                parameters.Add("return_url_canceled", canceled);
            if (null != pending)
                parameters.Add("return_url_pending", pending);
            if (null != error)
                parameters.Add("return_url_error", error);

            if (null != defaultPaymentMethod)
                parameters.Add("default_pm", defaultPaymentMethod);

            parameters.Add("default_act", skipPaymentChoice? "yes" : "no");

            return parameters;
        }
    }
}
