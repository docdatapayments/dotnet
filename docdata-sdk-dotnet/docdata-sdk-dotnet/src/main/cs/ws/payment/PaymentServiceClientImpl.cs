using System;
using System.Collections.Generic;
using System.ServiceModel;

using DocDataWSNameSpace;

namespace docdata_sdk_dotnet
{
    public class PaymentServiceClientImpl : PaymentServiceClient
    {
        /*
         * Generated with:
         * 
         * SvcUtil /wrapped /namespace:*,DocDataWSNameSpace /directory:target\services src\main\resources\docdata-ws\paymentservice.wsdl src\main\resources\docdata-ws\paymentservice.xsd src\main\resources\docdata-ws\types.xsd
         * 
         */
        private PaymentServiceSOAP paymentServiceSOAPClient;

        public PaymentServiceClientImpl(String location)
        {
            BasicHttpBinding binding = WCFUtil.BasicHttpOverSSLBinding();
            EndpointAddress address = new EndpointAddress(location);

            this.paymentServiceSOAPClient = new PaymentServiceSOAPClient(binding, address);

        }

        public DDCreateResponse createOrder(DDMerchant merchant, String paymentProfile,
            DDPaymentReference paymentReference, DDClient client, DDMoney money, String merchantOrderReference,
            DDDestination destination, decimal version)
        {
            bool hasPaymentReference = null != paymentReference && 
                null != paymentReference.linkID && 
                paymentReference.linkID.Length > 0;

            createRequest request = new createRequest();

            // merchant
            merchant wsMerchant = new merchant();
            wsMerchant.name = merchant.name;
            wsMerchant.password = merchant.password;
            request.merchant = wsMerchant;

            // payment preferences
            paymentPreferences wsPaymentPreferences = new paymentPreferences();
            wsPaymentPreferences.profile = paymentProfile;
            request.paymentPreferences = wsPaymentPreferences;

            // payment reference
            paymentReference wsPaymentReference = new paymentReference();
            wsPaymentReference.ItemElementName = ItemChoiceType.linkId;
            wsPaymentReference.Item = paymentReference.linkID;

            // only add payment reference when linkID is set ( can be null when paying with debit card )
            if (hasPaymentReference)
            {
                paymentRequest wsPaymentRequest = new paymentRequest();
                wsPaymentRequest.Item = wsPaymentReference;
                request.paymentRequest = wsPaymentRequest;
            }

            // shopper
            shopper wsShopper = new shopper();
            wsShopper.id = client.id;
            wsShopper.dateOfBirth = convert(client.dob);
            wsShopper.email = client.email;
            wsShopper.gender = client.gender;
            language wsLanguage = new language();
            wsLanguage.code = client.languageCode;
            wsShopper.language = wsLanguage;
            wsShopper.name = convert(client.name);
            wsShopper.mobilePhoneNumber = client.mobileNumber;
            wsShopper.phoneNumber = client.phoneNumber;
            request.shopper = wsShopper;

            // money
            amount wsAmount = new amount();
            wsAmount.currency = money.currency;
            wsAmount.Value = (int)money.amount;
            request.totalGrossAmount = wsAmount;

            // order reference
            request.merchantOrderReference = merchantOrderReference;

            // destination
            request.billTo = getDestination(client);

            // version
            request.version = version;

            // make request
            createResponse1 response1 = this.paymentServiceSOAPClient.create(new createRequest1(request));
            if (null == response1)
                throw new RuntimeException("Create order request failed!");

            createResponse response = response1.createResponse;

            // parse response
            if (null != response.createError)
                throw new DDWSException(response.createError.error);

            String key = response.createSuccess.key;

            // only check this when using a payment reference
            if (hasPaymentReference)
            {

                // payment order got through, now check if it succeeded or not
                if (null != response.createSuccess.paymentResponse.paymentError)
                    throw new DDPaymentErrorException(key, response.createSuccess.paymentResponse.paymentError);

                // linkID token used, order created, now need to redirect to DocData's payment meny
                if (null != response.createSuccess.paymentResponse.paymentInsufficientData)
                    throw new DDInsufficientDataException(key);

                // order created for known token
                return new DDCreateResponse(key, response.createSuccess.paymentResponse.paymentSuccess);
            }
            else
            {
                // Completed without any reference, now need to redirect to DocData's payment meny
                throw new DDInsufficientDataException(key);
            }
        }

        public DDStatusResponse getPaymentOrderStatus(DDMerchant merchant, String paymentOrderKey, decimal version)
        {
            statusRequest wsRequest = new statusRequest();

            // merchant
            merchant wsMerchant = new merchant();
            wsMerchant.name = merchant.name;
            wsMerchant.password = merchant.password;
            wsRequest.merchant = wsMerchant;

            wsRequest.paymentOrderKey = paymentOrderKey;
            wsRequest.version = version;

            statusResponse1 response1 = this.paymentServiceSOAPClient.status(new statusRequest1(wsRequest));
            if (null == response1)
            {
                throw new RuntimeException("Get payment status request failed!");
            }
            statusResponse response = response1.statusResponse;

            // parse response
            if (null != response.statusError)
            {
                throw new DDWSException(response.statusError.error);
            }

            return new DDStatusResponse(response);
        }

        /*
         * Helper methods
         */

        public String convert(DateTime? dateTime)
        {
            if (null == dateTime) return null;

            return dateTime.Value.ToString("yyyy-MM-dd");
        }

        public name convert(DDName name)
        {
            name wsName = new name();
            wsName.first = name.first;
            wsName.initials = name.initials;
            wsName.last = name.last;
            wsName.middle = name.middle;
            wsName.prefix = name.prefix;
            wsName.suffix = name.suffix;
            return wsName;
        }

        public destination getDestination(DDClient client)
        {
            destination wsDestination = new destination();
            wsDestination.address = getAddress(client);
            wsDestination.name = convert(client.name);
            return wsDestination;
        }

        public address getAddress(DDClient client)
        {
            address wsAddress = new address();
            wsAddress.city = client.city;
            wsAddress.company = client.companyName;
            wsAddress.houseNumber = client.streetNumber;
            wsAddress.houseNumberAddition = client.streetBus;
            wsAddress.postalCode = client.postalCode;
            wsAddress.street = client.street;

            country wsCountry = new country();
            wsCountry.code = client.countryCode;
            wsAddress.country = wsCountry;

            return wsAddress;
        }
    }
}
