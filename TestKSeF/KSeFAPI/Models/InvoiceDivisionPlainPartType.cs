// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace KSeFAPI.Models
{
    /// <summary> The InvoiceDivisionPlainPartType. </summary>
    public partial class InvoiceDivisionPlainPartType
    {
        /// <summary> Initializes a new instance of InvoiceDivisionPlainPartType. </summary>
        /// <param name="partReferenceNumber"></param>
        /// <param name="partName"></param>
        /// <param name="partNumber"></param>
        /// <param name="partRangeFrom"></param>
        /// <param name="partRangeTo"></param>
        /// <param name="partExpiration"></param>
        /// <param name="plainPartHash"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="partReferenceNumber"/>, <paramref name="partName"/> or <paramref name="plainPartHash"/> is null. </exception>
        internal InvoiceDivisionPlainPartType(string partReferenceNumber, string partName, int partNumber, DateTimeOffset partRangeFrom, DateTimeOffset partRangeTo, DateTimeOffset partExpiration, FileUnlimitedHashType plainPartHash)
        {
            if (partReferenceNumber == null)
            {
                throw new ArgumentNullException(nameof(partReferenceNumber));
            }
            if (partName == null)
            {
                throw new ArgumentNullException(nameof(partName));
            }
            if (plainPartHash == null)
            {
                throw new ArgumentNullException(nameof(plainPartHash));
            }

            PartReferenceNumber = partReferenceNumber;
            PartName = partName;
            PartNumber = partNumber;
            PartRangeFrom = partRangeFrom;
            PartRangeTo = partRangeTo;
            PartExpiration = partExpiration;
            PlainPartHash = plainPartHash;
        }

        /// <summary> Gets the part reference number. </summary>
        public string PartReferenceNumber { get; }
        /// <summary> Gets the part name. </summary>
        public string PartName { get; }
        /// <summary> Gets the part number. </summary>
        public int PartNumber { get; }
        /// <summary> Gets the part range from. </summary>
        public DateTimeOffset PartRangeFrom { get; }
        /// <summary> Gets the part range to. </summary>
        public DateTimeOffset PartRangeTo { get; }
        /// <summary> Gets the part expiration. </summary>
        public DateTimeOffset PartExpiration { get; }
        /// <summary> Gets the plain part hash. </summary>
        public FileUnlimitedHashType PlainPartHash { get; }
    }
}