using System;
using System.Collections.Generic;
using System.Text;

using DocDataWSNameSpace;

namespace docdata_sdk_dotnet
{
    public class DDClient
    {
        // max 35 characters
        public String id { get; set; }
        // max 35 characters
        public String email { get; set; }
        public DDName name { get; set; }
        public gender gender { get; set; }

        public String street { get; set; }
        public String streetNumber { get; set; }
        public String streetBus { get; set; }
        public String address { get; set; }
        public String postalCode { get; set; }
        public String city { get; set; }
        public countryCode countryCode { get; set; }
        public languageCode languageCode { get; set; }

        public DateTime? dob { get; set; }
        public String phoneNumber { get; set; }
        public String mobileNumber { get; set; }
        public String companyName { get; set; }

        public DDClient(String id, String email, DDName name, String street, String streetNumber, String streetBus,
            String address, String postalCode, String city, countryCode countryCode, languageCode languageCode,
            gender gender)
        {
            this.id = id;
            this.email = email;
            this.name = name;
            this.street = street;
            this.streetNumber = streetNumber;
            this.streetBus = streetBus;
            this.address = address;
            this.postalCode = postalCode;
            this.city = city;
            this.countryCode = countryCode;
            this.languageCode = languageCode;
            this.gender = gender;
        }
    }
}
