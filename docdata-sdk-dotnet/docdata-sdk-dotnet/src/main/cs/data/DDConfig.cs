using System;
using System.Collections.Generic;
using System.Text;

using DocDataWSNameSpace;

namespace docdata_sdk_dotnet
{
    public class DDConfig
    {
        public String wsLocation { get; set; }
        public decimal wsVersion { get; set; }
        public String serviceLocation { get; set; }
        public String merchantName { get; set; }
        public String merchantPassword { get; set; }
        public String paymentProfile { get; set; }
        public String destinationFirstName { get; set; }
        public String destinationLastName { get; set; }
        public String destinationAddressStreet { get; set; }
        public String destinationAddressNumber { get; set; }
        public String destinationAddressCity { get; set; }
        public String destinationAddressPostalCode { get; set; }
        public countryCode destinationAddressCountryCode { get; set; }

        public DDConfig(String wsLocation, decimal wsVersion, String serviceLocation, 
            String merchantName, String merchantPassword, String paymentProfile,
            string destinationFirstName, string destinationLastName, string destinationAddressStreet,
            string destinationAddressNumber, string destinationAddressCity, string destinationAddressPostalCode,
            countryCode destinationAddressCountryCode)
        {
            this.wsLocation = wsLocation;
            this.wsVersion = wsVersion;
            this.serviceLocation = serviceLocation;
            this.merchantName = merchantName;
            this.merchantPassword = merchantPassword;
            this.paymentProfile = paymentProfile;
            this.destinationFirstName = destinationFirstName;
            this.destinationLastName = destinationLastName;
            this.destinationAddressStreet = destinationAddressStreet;
            this.destinationAddressNumber = destinationAddressNumber;
            this.destinationAddressCity = destinationAddressCity;
            this.destinationAddressPostalCode = destinationAddressPostalCode;
            this.destinationAddressCountryCode = destinationAddressCountryCode;
        }

        public DDMerchant getMerchant()
        {
            return new DDMerchant(this.merchantName, this.merchantPassword);
        }

        public DDDestination getDestination()
        {
            return new DDDestination(new DDName(destinationFirstName, destinationLastName),
                new DDAddress(destinationAddressStreet, destinationAddressNumber, destinationAddressPostalCode, 
                    destinationAddressCity, destinationAddressCountryCode));
        }
    }
}
