using System;
using System.Collections.Generic;
using System.Text;

namespace docdata_sdk_dotnet
{
    public class DDName
    {
        public String first { get; set; }
        public String last { get; set; }

        public String prefix { get; set; }
        public String initials { get; set; }
        public String middle { get; set; }
        public String suffix { get; set; }

        public DDName(String first, String last)
        {
            this.first = first;
            this.last = last;
        }
    }
}
