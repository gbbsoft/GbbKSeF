// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.IO;
using System.Text.Json;
using Azure.Core;

namespace KSeFAPI.Models
{
    public partial class HashSHAType : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("algorithm");
            writer.WriteStringValue(Algorithm);
            writer.WritePropertyName("encoding");
            writer.WriteStringValue(Encoding);
            writer.WritePropertyName("value");
            writer.WriteStringValue(Value);
            writer.WriteEndObject();
        }

        internal static HashSHAType DeserializeHashSHAType(JsonElement element)
        {
            string algorithm = default;
            string encoding = default;
            /*Stream*/ string value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("algorithm"))
                {
                    algorithm = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("encoding"))
                {
                    encoding = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("value"))
                {
                    value = property.Value.GetString();
                    continue;
                }
            }
            return new HashSHAType(algorithm, encoding, value);
        }
    }
}
