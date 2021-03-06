// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace KSeFAPI.Models
{
    public partial class CredentialsTokenType
    {
        internal static CredentialsTokenType DeserializeCredentialsTokenType(JsonElement element)
        {
            Optional<IReadOnlyList<CredentialsRoleResponseTokenType>> credentialsRoleList = default;
            Optional<CredentialsPlainType> parent = default;
            Optional<string> description = default;
            Optional<int> status = default;
            Optional<object> identifier = default;
            string type = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("credentialsRoleList"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<CredentialsRoleResponseTokenType> array = new List<CredentialsRoleResponseTokenType>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(CredentialsRoleResponseTokenType.DeserializeCredentialsRoleResponseTokenType(item));
                    }
                    credentialsRoleList = array;
                    continue;
                }
                if (property.NameEquals("parent"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    parent = CredentialsPlainType.DeserializeCredentialsPlainType(property.Value);
                    continue;
                }
                if (property.NameEquals("description"))
                {
                    description = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("status"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    status = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("identifier"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    identifier = property.Value.GetObject();
                    continue;
                }
                if (property.NameEquals("type"))
                {
                    type = property.Value.GetString();
                    continue;
                }
            }
            return new CredentialsTokenType(identifier.Value, type, Optional.ToList(credentialsRoleList), parent.Value, description.Value, Optional.ToNullable(status));
        }
    }
}
