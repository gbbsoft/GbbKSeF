// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace KSeFAPI.Models
{
    public partial class QuerySyncCredentialsResponse
    {
        internal static QuerySyncCredentialsResponse DeserializeQuerySyncCredentialsResponse(JsonElement element)
        {
            DateTimeOffset timestamp = default;
            string referenceNumber = default;
            IReadOnlyList<CredentialsBaseTypeObject> credentialsList = default;
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
                if (property.NameEquals("credentialsList"))
                {
                    List<CredentialsBaseTypeObject> array = new List<CredentialsBaseTypeObject>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(CredentialsBaseTypeObject.DeserializeCredentialsBaseTypeObject(item));
                    }
                    credentialsList = array;
                    continue;
                }
            }
            return new QuerySyncCredentialsResponse(timestamp, referenceNumber, credentialsList);
        }
    }
}
