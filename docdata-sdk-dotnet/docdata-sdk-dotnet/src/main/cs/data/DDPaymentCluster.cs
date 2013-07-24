using System;
using System.Collections.Generic;
using System.Text;

namespace docdata_sdk_dotnet
{
    public class DDPaymentCluster
    {
        public String key { get; set; }
        public DDMoney money { get; set; }

        public DDPaymentCluster(String key, DDMoney money)
        {
            this.key = key;
            this.money = money;
        }

    }
}
