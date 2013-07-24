using System;
using System.Collections.Generic;

using docdata_sdk_dotnet;
using DocDataWSNameSpace;

namespace docdata_example
{
    class ExampleUtil
    {
        // Payment info
        public static double AMOUNT = 42 * 100;
        public static currency CURRENCY = currency.EUR;

        public static String RETURN_SUCCESS_URL = "http://localhost:62429/PaymentReturn.aspx";
        public static String CANCEL_SUCCESS_URL = "http://localhost:62429/PaymentReturn.aspx?result=canceled";
        public static String PENDING_SUCCESS_URL = "http://localhost:62429/PaymentReturn.aspx?result=pending";
        public static String ERROR_SUCCESS_URL = "http://localhost:62429/PaymentReturn.aspx?result=error";

        // DocData configuration
//        public static String WS_LOCATION = "https://192.168.5.14:8443/demo-payment/ws";
        public static String WS_LOCATION = "https://test.docdatapayments.com/ps/services/paymentservice/1_0?wsdl";
        public static decimal WS_VERSION = 1;
//        public static String SERVICE_LOCATION = "https://192.168.5.14:8443/demo-payment/PaymentService";
        public static String SERVICE_LOCATION = "https://test.docdatapayments.com/ps/menu";

        // Merchant configuration
        public static String MERCHANT_NAME = "test";
        public static String MERCHANT_PW = "pw";

        // Payment profile
        public static String PAYMENT_PROFILE = "default";

        // Merchant info
        public static String DEST_FIRST = "First";
        public static String DEST_LAST = "Last";
        public static String DEST_ADDRESS_STREET = "Street";
        public static String DEST_ADDRESS_NUMBER = "Number";
        public static String DEST_ADDRESS_CITY = "City";
        public static String DEST_ADDRESS_POSTAL_CODE = "9000";
        public static countryCode DEST_ADDRESS_COUNTRY_CODE = countryCode.BE;

        // Client info
        public static String CLIENT_ID = "1";
        public static String CLIENT_EMAIL = "foo@bar.com";
        public static String CLIENT_FIRST = "First";
        public static String CLIENT_LAST = "Last";
        public static String CLIENT_STREET = "Street";
        public static String CLIENT_STREET_NUMBER = "1";
        public static String CLIENT_STREET_BUS = "B";
        public static String CLIENT_POSTAL_CODE = "9000";
        public static String CLIENT_CITY = "Gent";
        public static countryCode CLIENT_COUNTRY_CODE = countryCode.BE;
        public static languageCode CLIENT_LANGUAGE = languageCode.en;
        public static gender CLIENT_GENDER = gender.M;

        public static DDConfig getDDConfig()
        {
            return new DDConfig(WS_LOCATION, WS_VERSION, SERVICE_LOCATION, MERCHANT_NAME, MERCHANT_PW,
                PAYMENT_PROFILE, DEST_FIRST, DEST_LAST, DEST_ADDRESS_STREET, DEST_ADDRESS_NUMBER,
                DEST_ADDRESS_CITY, DEST_ADDRESS_POSTAL_CODE, DEST_ADDRESS_COUNTRY_CODE);
        }

        public static DDClient getDDClient()
        {
            return new DDClient(CLIENT_ID, CLIENT_EMAIL, new DDName(CLIENT_FIRST, CLIENT_LAST),
                CLIENT_STREET, CLIENT_STREET_NUMBER, CLIENT_STREET_BUS, getClientAddress(),
                CLIENT_POSTAL_CODE, CLIENT_CITY, CLIENT_COUNTRY_CODE, CLIENT_LANGUAGE, CLIENT_GENDER);
        }

        public static String getClientAddress()
        {
            return CLIENT_STREET + " " + CLIENT_STREET_NUMBER + " " + CLIENT_STREET_BUS + " "
                + CLIENT_POSTAL_CODE + " " + CLIENT_CITY + " " + CLIENT_COUNTRY_CODE;
        }

        public static String getOrderReference()
        {
            Random rnd = new Random();
            int orderRef = rnd.Next();
            return orderRef.ToString();
        }

    }
}