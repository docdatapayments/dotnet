using System;
using System.Collections.Generic;
using System.Text;

namespace docdata_sdk_dotnet
{
    public class DDDestination
    {
        public DDName name { get; set; }
        public DDAddress address { get; set; }

        public DDDestination(DDName name, DDAddress address)
        {
            this.name = name;
            this.address = address;
        }
    }
}
