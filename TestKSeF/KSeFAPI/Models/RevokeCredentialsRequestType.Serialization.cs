// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace KSeFAPI.Models
{
    public partial class RevokeCredentialsRequestType : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("credentialsIdentifier");
            writer.WriteObjectValue(CredentialsIdentifier);
            writer.WritePropertyName("description");
            writer.WriteStringValue(Description);
            writer.WritePropertyName("credentialsRoleList");
            writer.WriteStartArray();
            foreach (var item in CredentialsRoleList)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }
    }
}