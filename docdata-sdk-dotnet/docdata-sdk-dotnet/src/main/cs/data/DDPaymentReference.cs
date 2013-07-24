using System;
using System.Collections.Generic;
using System.Text;

namespace docdata_sdk_dotnet
{
    public class DDPaymentReference
    {
        public String linkID { get; set; }

        public DDPaymentReference(String linkID)
        {
            this.linkID = linkID;
        }
    }
}
