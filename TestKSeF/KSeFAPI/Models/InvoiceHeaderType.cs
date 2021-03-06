// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace KSeFAPI.Models
{
    /// <summary> The InvoiceHeaderType. </summary>
    public partial class InvoiceHeaderType
    {
        /// <summary> Initializes a new instance of InvoiceHeaderType. </summary>
        /// <param name="invoiceReferenceNumber"></param>
        /// <param name="ksefReferenceNumber"></param>
        /// <param name="invoiceHash"></param>
        /// <param name="invoicingDate"></param>
        /// <param name="acquisitionTimestamp"></param>
        /// <param name="subjectBy"></param>
        /// <param name="subjectTo"></param>
        /// <param name="net"></param>
        /// <param name="vat"></param>
        /// <param name="gross"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="invoiceReferenceNumber"/>, <paramref name="ksefReferenceNumber"/>, <paramref name="invoiceHash"/>, <paramref name="subjectBy"/>, <paramref name="subjectTo"/>, <paramref name="net"/>, <paramref name="vat"/> or <paramref name="gross"/> is null. </exception>
        internal InvoiceHeaderType(string invoiceReferenceNumber, string ksefReferenceNumber, FileUnlimitedHashType invoiceHash, DateTimeOffset invoicingDate, DateTimeOffset acquisitionTimestamp, SubjectByType subjectBy, SubjectToType subjectTo, string net, string vat, string gross)
        {
            if (invoiceReferenceNumber == null)
            {
                throw new ArgumentNullException(nameof(invoiceReferenceNumber));
            }
            if (ksefReferenceNumber == null)
            {
                throw new ArgumentNullException(nameof(ksefReferenceNumber));
            }
            if (invoiceHash == null)
            {
                throw new ArgumentNullException(nameof(invoiceHash));
            }
            if (subjectBy == null)
            {
                throw new ArgumentNullException(nameof(subjectBy));
            }
            if (subjectTo == null)
            {
                throw new ArgumentNullException(nameof(subjectTo));
            }
            if (net == null)
            {
                throw new ArgumentNullException(nameof(net));
            }
            if (vat == null)
            {
                throw new ArgumentNullException(nameof(vat));
            }
            if (gross == null)
            {
                throw new ArgumentNullException(nameof(gross));
            }

            InvoiceReferenceNumber = invoiceReferenceNumber;
            KsefReferenceNumber = ksefReferenceNumber;
            InvoiceHash = invoiceHash;
            InvoicingDate = invoicingDate;
            AcquisitionTimestamp = acquisitionTimestamp;
            SubjectBy = subjectBy;
            SubjectTo = subjectTo;
            SubjectToKList = new ChangeTrackingList<SubjectToType>();
            SubjectsOtherList = new ChangeTrackingList<SubjectOtherType>();
            SubjectsAuthorizedList = new ChangeTrackingList<SubjectAuthorizedType>();
            Net = net;
            Vat = vat;
            Gross = gross;
        }

        /// <summary> Initializes a new instance of InvoiceHeaderType. </summary>
        /// <param name="invoiceReferenceNumber"></param>
        /// <param name="ksefReferenceNumber"></param>
        /// <param name="invoiceHash"></param>
        /// <param name="invoicingDate"></param>
        /// <param name="acquisitionTimestamp"></param>
        /// <param name="subjectBy"></param>
        /// <param name="subjectByK"></param>
        /// <param name="subjectTo"></param>
        /// <param name="subjectToKList"></param>
        /// <param name="subjectsOtherList"></param>
        /// <param name="subjectsAuthorizedList"></param>
        /// <param name="net"></param>
        /// <param name="vat"></param>
        /// <param name="gross"></param>
        internal InvoiceHeaderType(string invoiceReferenceNumber, string ksefReferenceNumber, FileUnlimitedHashType invoiceHash, DateTimeOffset invoicingDate, DateTimeOffset acquisitionTimestamp, SubjectByType subjectBy, SubjectByType subjectByK, SubjectToType subjectTo, IReadOnlyList<SubjectToType> subjectToKList, IReadOnlyList<SubjectOtherType> subjectsOtherList, IReadOnlyList<SubjectAuthorizedType> subjectsAuthorizedList, string net, string vat, string gross)
        {
            InvoiceReferenceNumber = invoiceReferenceNumber;
            KsefReferenceNumber = ksefReferenceNumber;
            InvoiceHash = invoiceHash;
            InvoicingDate = invoicingDate;
            AcquisitionTimestamp = acquisitionTimestamp;
            SubjectBy = subjectBy;
            SubjectByK = subjectByK;
            SubjectTo = subjectTo;
            SubjectToKList = subjectToKList;
            SubjectsOtherList = subjectsOtherList;
            SubjectsAuthorizedList = subjectsAuthorizedList;
            Net = net;
            Vat = vat;
            Gross = gross;
        }

        /// <summary> Gets the invoice reference number. </summary>
        public string InvoiceReferenceNumber { get; }
        /// <summary> Gets the ksef reference number. </summary>
        public string KsefReferenceNumber { get; }
        /// <summary> Gets the invoice hash. </summary>
        public FileUnlimitedHashType InvoiceHash { get; }
        /// <summary> Gets the invoicing date. </summary>
        public DateTimeOffset InvoicingDate { get; }
        /// <summary> Gets the acquisition timestamp. </summary>
        public DateTimeOffset AcquisitionTimestamp { get; }
        /// <summary> Gets the subject by. </summary>
        public SubjectByType SubjectBy { get; }
        /// <summary> Gets the subject by k. </summary>
        public SubjectByType SubjectByK { get; }
        /// <summary> Gets the subject to. </summary>
        public SubjectToType SubjectTo { get; }
        /// <summary> Gets the subject to k list. </summary>
        public IReadOnlyList<SubjectToType> SubjectToKList { get; }
        /// <summary> Gets the subjects other list. </summary>
        public IReadOnlyList<SubjectOtherType> SubjectsOtherList { get; }
        /// <summary> Gets the subjects authorized list. </summary>
        public IReadOnlyList<SubjectAuthorizedType> SubjectsAuthorizedList { get; }
        /// <summary> Gets the net. </summary>
        public string Net { get; }
        /// <summary> Gets the vat. </summary>
        public string Vat { get; }
        /// <summary> Gets the gross. </summary>
        public string Gross { get; }
    }
}
