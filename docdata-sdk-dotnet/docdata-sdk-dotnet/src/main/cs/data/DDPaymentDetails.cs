using System;
using System.Collections.Generic;
using System.Text;

using DocDataWSNameSpace;

namespace docdata_sdk_dotnet
{
    public enum DDAuthorizationConfidenceLevel { ACQUIRER_PENDING, SHOPPER_PENDING, ACQUIRER_APPROVED }

    public class DDPaymentDetails
    {
        public String paymentId { get; set; }
        public DDAuthorizationConfidenceLevel confidenceLevel { get; set; }
        public authorizationStatus authorizationStatus { get; set; }
        public amount paymentAmount { get; set; }

        public DDPaymentDetails(payment payment)
        {
            paymentId = payment.id;

            confidenceLevel = null != payment.authorization.confidenceLevel &&
                payment.authorization.confidenceLevel.Length > 0 
                ? parse(payment.authorization.confidenceLevel) : DDAuthorizationConfidenceLevel.SHOPPER_PENDING;

            paymentAmount = payment.authorization.amount;
        }

        public DDAuthorizationConfidenceLevel parse(String confidenceLevel)
        {
            if (confidenceLevel.Equals(DDAuthorizationConfidenceLevel.ACQUIRER_PENDING.ToString()))
                return DDAuthorizationConfidenceLevel.ACQUIRER_PENDING;
            if (confidenceLevel.Equals(DDAuthorizationConfidenceLevel.SHOPPER_PENDING.ToString()))
                return DDAuthorizationConfidenceLevel.SHOPPER_PENDING;
            if (confidenceLevel.Equals(DDAuthorizationConfidenceLevel.ACQUIRER_APPROVED.ToString()))
                return DDAuthorizationConfidenceLevel.ACQUIRER_APPROVED;

            throw new RuntimeException("Confidence level " + confidenceLevel + " is not supported!");
        }
    }
}
