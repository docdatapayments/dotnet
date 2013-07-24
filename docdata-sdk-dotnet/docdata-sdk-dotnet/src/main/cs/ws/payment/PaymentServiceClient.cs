using System;
using System.Collections.Generic;
using System.Text;

namespace docdata_sdk_dotnet
{
    public interface PaymentServiceClient
    {

        /// <summary>
        /// Creates a new payment order
        /// </summary>
        /// <param name="merchant"></param>
        /// <param name="paymentProfile"></param>
        /// <param name="paymentReference"></param>
        /// <param name="client"></param>
        /// <param name="money"></param>
        /// <param name="merchantOrderReference"></param>
        /// <param name="destination"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        /// <exception cref="DDWSException">Something unexpected happened</exception>
        /// <exception cref="DDPaymentErrorException"></exception>
        /// <exception cref="DDInsufficientDataException"></exception>
        DDCreateResponse createOrder(DDMerchant merchant, String paymentProfile, DDPaymentReference paymentReference,
            DDClient client, DDMoney money, String merchantOrderReference, DDDestination destination, decimal version);

        /// <summary>
        /// Fetch the specified payment transaction's status report
        /// </summary>
        /// <param name="merchant"></param>
        /// <param name="paymentOrderKey"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        /// <exception cref="DDWSException">Something unexpected happened</exception>
        /// <exception cref="DDNoPaymentInStatusReportException">No payment was found in the status report</exception>
        DDStatusResponse getPaymentOrderStatus(DDMerchant merchant, String paymentOrderKey, decimal version);
    
    }
}
