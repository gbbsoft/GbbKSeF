// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace KSeFAPI.Models
{
    /// <summary> The InvoiceStatusType. </summary>
    public partial class InvoiceStatusType
    {
        /// <summary> Initializes a new instance of InvoiceStatusType. </summary>
        internal InvoiceStatusType()
        {
        }

        /// <summary> Initializes a new instance of InvoiceStatusType. </summary>
        /// <param name="invoiceNumber"></param>
        /// <param name="ksefReferenceNumber"></param>
        /// <param name="acquisitionTimestamp"></param>
        internal InvoiceStatusType(string invoiceNumber, string ksefReferenceNumber, DateTimeOffset? acquisitionTimestamp)
        {
            InvoiceNumber = invoiceNumber;
            KsefReferenceNumber = ksefReferenceNumber;
            AcquisitionTimestamp = acquisitionTimestamp;
        }

        /// <summary> Gets the invoice number. </summary>
        public string InvoiceNumber { get; }
        /// <summary> Gets the ksef reference number. </summary>
        public string KsefReferenceNumber { get; }
        /// <summary> Gets the acquisition timestamp. </summary>
        public DateTimeOffset? AcquisitionTimestamp { get; }
    }
}