using System;
using System.Collections.Generic;
using System.Text;

using DocDataWSNameSpace;

namespace docdata_sdk_dotnet
{
    public class DDMoney
    {
        public double amount { get; set; }
        public currency currency { get; set; }

        public DDMoney(double amount, currency currency)
        {
            this.amount = amount;
            this.currency = currency;
        }
    }
}
