// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace KSeFAPI.Models
{
    /// <summary> The InvoiceRequestKSeF. </summary>
    public partial class InvoiceRequestKSeF
    {
        /// <summary> Initializes a new instance of InvoiceRequestKSeF. </summary>
        /// <param name="ksefReferenceNumber"></param>
        /// <param name="invoiceDetails"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="ksefReferenceNumber"/> or <paramref name="invoiceDetails"/> is null. </exception>
        public InvoiceRequestKSeF(string ksefReferenceNumber, InvoiceQueryDetailsType invoiceDetails)
        {
            if (ksefReferenceNumber == null)
            {
                throw new ArgumentNullException(nameof(ksefReferenceNumber));
            }
            if (invoiceDetails == null)
            {
                throw new ArgumentNullException(nameof(invoiceDetails));
            }

            KsefReferenceNumber = ksefReferenceNumber;
            InvoiceDetails = invoiceDetails;
        }

        /// <summary> Gets the ksef reference number. </summary>
        public string KsefReferenceNumber { get; }
        /// <summary> Gets the invoice details. </summary>
        public InvoiceQueryDetailsType InvoiceDetails { get; }
    }
}
