using System;
using System.Collections.Generic;
using System.Text;

using DocDataWSNameSpace;

namespace docdata_sdk_dotnet
{
    public class DDStatusResponse
    {
        public bool orderPaid { get; set; }
        public bool orderWillBePaid { get; set; }
        public List<DDPaymentDetails> paymentDetails { get; set; }

        public DDStatusResponse(statusResponse statusResponse)
        {
            statusReport wsStatusreport = statusResponse.statusSuccess.report;

            if (0 == wsStatusreport.payment.Length)
                throw new DDNoPaymentInStatusReportException("No payment in status report ?!");

            // Payments
            this.paymentDetails = new List<DDPaymentDetails>();
            foreach(payment wsPayment in wsStatusreport.payment)
            {
                paymentDetails.Add(new DDPaymentDetails(wsPayment));
            }

            // Totals
            approximateTotals totals = wsStatusreport.approximateTotals;

            // Determine if order is payed using the safe route
            // Refers to the "Total captured" amount to see whether this equals the "Total registered amount"
            orderPaid = totals.totalRegistered > 0 && totals.totalRegistered == totals.totalCaptured;

            // Determine if order is payed using the quick route
            // Refers to whether the sum of "total shopper pending", "total acquired pending" and
            // "total acquirer authorized" matches the "total registered sum"
            orderWillBePaid = totals.totalRegistered > 0 &&
                (totals.totalShopperPending + totals.totalAcquirerPending + totals.totalAcquirerApproved == totals.totalRegistered);
        }

    }
}
