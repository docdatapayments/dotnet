using System;
using System.Collections.Generic;
using System.Text;

using DocDataWSNameSpace;

namespace docdata_sdk_dotnet
{
    public class DDAddress
    {
        // max 35 characters
        public String street { get; set; }
        // max 35 characters
        public String houseNumber { get; set; }
        // max 35 characters
        public String postalCode { get; set; }
        // max 35 characters
        public String city { get; set; }
        public countryCode countryCode { get; set; }

        public String company { get; set; }
        public String houseNumberAddition { get; set; }

        public DDAddress(String street, String houseNumber, String postalCode, String city, countryCode countryCode)
        {
            this.street = street;
            this.houseNumber = houseNumber;
            this.postalCode = postalCode;
            this.city = city;
            this.countryCode = countryCode;
        }
    }
}
