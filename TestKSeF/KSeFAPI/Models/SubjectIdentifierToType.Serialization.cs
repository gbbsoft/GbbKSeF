// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace KSeFAPI.Models
{
    public partial class SubjectIdentifierToType : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("type");
            writer.WriteStringValue(Type);
            writer.WriteEndObject();
        }

        internal static SubjectIdentifierToType DeserializeSubjectIdentifierToType(JsonElement element)
        {
            if (element.TryGetProperty("type", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "none": return SubjectIdentifierToNoneType.DeserializeSubjectIdentifierToNoneType(element);
                    case "onip": return SubjectIdentifierToCompanyType.DeserializeSubjectIdentifierToCompanyType(element);
                    case "other": return SubjectIdentifierToOtherTaxType.DeserializeSubjectIdentifierToOtherTaxType(element);
                }
            }
            string type = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("type"))
                {
                    type = property.Value.GetString();
                    continue;
                }
            }
            return new SubjectIdentifierToType(type);
        }
    }
}