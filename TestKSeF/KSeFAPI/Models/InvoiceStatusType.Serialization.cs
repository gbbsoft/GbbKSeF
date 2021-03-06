// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace KSeFAPI.Models
{
    public partial class InvoiceStatusType
    {
        internal static InvoiceStatusType DeserializeInvoiceStatusType(JsonElement element)
        {
            Optional<string> invoiceNumber = default;
            Optional<string> ksefReferenceNumber = default;
            Optional<DateTimeOffset> acquisitionTimestamp = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("invoiceNumber"))
                {
                    invoiceNumber = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("ksefReferenceNumber"))
                {
                    ksefReferenceNumber = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("acquisitionTimestamp"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    acquisitionTimestamp = property.Value.GetDateTimeOffset("O");
                    continue;
                }
            }
            return new InvoiceStatusType(invoiceNumber.Value, ksefReferenceNumber.Value, Optional.ToNullable(acquisitionTimestamp));
        }
    }
}
