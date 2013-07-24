using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

using DocDataWSNameSpace;

namespace docdata_sdk_dotnet
{
    public class DDOperation
    {

        /// <summary>
        /// Start a Docdata payment transaction with an existing linkID payment token ( not "NEW" )
        /// </summary>
        /// <param name="linkIDPaymentReference">the linkID payment token ID</param>
        /// <param name="orderReference">order reference</param>
        /// <param name="price">price to pay ( in  cents )</param>
        /// <param name="currency">currency</param>
        /// <param name="config">DocData configuration</param>
        /// <param name="client">Client who is making the payment</param> 
        /// <returns></returns>
        public static DDPaymentResponse paymentRequest(String linkIDPaymentReference, String orderReference,
            double price, currency currency, DDConfig config, DDClient client)
        {
            if (null == linkIDPaymentReference || 0 == linkIDPaymentReference.Length)
            {
                throw new RuntimeException("Need a non empty linkID payment reference!");
            }

            try
            {
                DDCreateResponse createResponse = createPaymentOrder(linkIDPaymentReference, orderReference, price,
                    currency, config, client);

                // fetch status
                try
                {
                    return new DDPaymentResponse(createResponse.paymentOrderKey, createResponse.paymentId,
                        getPaymentOrderStatus(createResponse.paymentOrderKey, config));
                }
                catch (DDNoPaymentInStatusReportException e)
                {
                    throw new RuntimeException(e);
                }
                
            }
            catch (DDInsufficientDataException e)
            {
                throw new DDTokenNotRecognizedException(e.key);
            }
        }

        /// <summary>
        /// Start a DocData payment transaction with a "NEW" linkID payment token
        /// </summary>
        /// <param name="newLinkIDPaymentReference"></param>
        /// <param name="orderReference"></param>
        /// <param name="price"></param>
        /// <param name="currency"></param>
        /// <param name="config"></param>
        /// <param name="client"></param>
        /// <returns></returns>
        public static String paymentRequestNewToken(String newLinkIDPaymentReference, String orderReference,
            double price, currency currency, DDConfig config, DDClient client)
        {

            if (null == newLinkIDPaymentReference || 0 == newLinkIDPaymentReference.Length)
            {
                throw new RuntimeException("Need a non empty linkID payment reference!");
            }

            try
            {
                DDCreateResponse createResponse = createPaymentOrder(newLinkIDPaymentReference, orderReference,
                    price, currency, config, client);

                // Payment request with NEW token should throw exception...
                throw new DDRequestNewTokenCompletedException(createResponse.paymentOrderKey);
            }
            catch (DDInsufficientDataException e)
            {
                // expected
                return e.key;
            }
        }

        /// <summary>
        /// Starts a DocData payment, without using any linkID payment token
        /// </summary>
        /// <param name="orderReference"></param>
        /// <param name="price"></param>
        /// <param name="currency"></param>
        /// <param name="config"></param>
        /// <param name="client"></param>
        /// <returns></returns>
        public static String paymentRequestWithoutToken(String orderReference, double price, currency currency,
            DDConfig config, DDClient client)
        {

            try
            {
                DDCreateResponse createResponse = createPaymentOrder(null, orderReference,
                    price, currency, config, client);

                throw new RuntimeException("Payment without token should return insufficient data... ?!");
            }
            catch (DDInsufficientDataException e)
            {
                // expected
                return e.key;
            }
        }

        /// <summary>
        /// Fetch payment status using the SOAP WS client
        /// </summary>
        /// <param name="paymentOrderKey">the payment order key</param>
        /// <param name="config">the DocData configuration</param>
        /// <returns>status report of the requested transaction</returns>
        public static DDStatusResponse getPaymentOrderStatus(String paymentOrderKey, DDConfig config)
        {

            PaymentServiceClient wsClient = new PaymentServiceClientImpl(config.wsLocation);

            try
            {

                return wsClient.getPaymentOrderStatus(config.getMerchant(), paymentOrderKey, config.wsVersion);
            }
            catch (DDWSException e)
            {
                throw new RuntimeException(e);
            }
        }

        /// <summary>
        /// Get the DocData payment menu URL
        /// </summary>
        /// <param name="paymentTransaction"></param>
        /// <param name="price"></param>
        /// <param name="currency"></param>
        /// <param name="language"></param>
        /// <param name="config"></param>
        /// <param name="successReturnURL"></param>
        /// <param name="cancelledReturnURL"></param>
        /// <param name="pendingReturnURL"></param>
        /// <param name="errorReturnURL"></param>
        /// <returns></returns>
        public static String getPaymentMenuURL(String paymentTransaction, double price, currency currency,
            String language, DDConfig config, String successReturnURL, String cancelledReturnURL,
            String pendingReturnURL, String errorReturnURL)
        {
            PaymentMenuRequest paymentMenuRequest = new PaymentMenuRequest(config.getMerchant(), language,
                new DDPaymentCluster(paymentTransaction, new DDMoney(price, currency)));
            
            paymentMenuRequest.success = successReturnURL;
            paymentMenuRequest.canceled = cancelledReturnURL;
            paymentMenuRequest.pending = pendingReturnURL;
            paymentMenuRequest.error = errorReturnURL;

            String redirectUrl = config.serviceLocation + "?command=show_payment_cluster";

            Dictionary<String, String> parameters = paymentMenuRequest.getParameters();
            foreach(String key in parameters.Keys)
            {
                redirectUrl += "&" + key + "=" + HttpUtility.UrlEncode(parameters[key]);
            }

            return redirectUrl;
        }

        private static DDCreateResponse createPaymentOrder(String linkIDPaymentReference, String orderReference,
            double price, currency currency, DDConfig config, DDClient client)
        {

            PaymentServiceClient wsclient = new PaymentServiceClientImpl(config.wsLocation);

            // setup request
            DDMoney money = new DDMoney(price, currency);
            DDPaymentReference paymentReference = new DDPaymentReference(linkIDPaymentReference);

            // perform request
            try
            {
                return wsclient.createOrder(config.getMerchant(), config.paymentProfile, paymentReference, client, money,
                    orderReference, config.getDestination(), config.wsVersion);
            }
            catch (DDWSException e)
            {
                throw new RuntimeException(e);
            }
            catch (DDPaymentErrorException e)
            {
                throw new RuntimeException(e);
            }
        }
    }
}
