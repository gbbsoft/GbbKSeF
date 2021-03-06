// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace KSeFAPI.Models
{
    public partial class UploadResponse
    {
        internal static UploadResponse DeserializeUploadResponse(JsonElement element)
        {
            DateTimeOffset timestamp = default;
            string referenceNumber = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("timestamp"))
                {
                    timestamp = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("referenceNumber"))
                {
                    referenceNumber = property.Value.GetString();
                    continue;
                }
            }
            return new UploadResponse(timestamp, referenceNumber);
        }
    }
}
