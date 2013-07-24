using System;
using System.Collections.Generic;
using System.Text;

namespace docdata_sdk_dotnet
{
    public class DDMerchant
    {
        // max 50 characters
        public String name { get; set; }

        // max 35 characters
        public String password { get; set; }

        public DDMerchant(String name, String password)
        {
            this.name = name;
            this.password = password;
        }
    }
}
