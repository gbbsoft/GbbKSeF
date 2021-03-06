// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace KSeFAPI.Models
{
    public partial class CredentialsIdentifierResponseType
    {
        internal static CredentialsIdentifierResponseType DeserializeCredentialsIdentifierResponseType(JsonElement element)
        {
            if (element.TryGetProperty("type", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "fingerprint": return CredentialsIdentifierResponseIndividualCertificateFingerprintType.DeserializeCredentialsIdentifierResponseIndividualCertificateFingerprintType(element);
                    case "nip": return CredentialsIdentifierResponseIndividualNipType.DeserializeCredentialsIdentifierResponseIndividualNipType(element);
                    case "pesel": return CredentialsIdentifierResponseIndividualPeselType.DeserializeCredentialsIdentifierResponseIndividualPeselType(element);
                    case "system": return CredentialsIdentifierResponseSystemType.DeserializeCredentialsIdentifierResponseSystemType(element);
                    case "token": return CredentialsIdentifierResponseAuthorisationTokenType.DeserializeCredentialsIdentifierResponseAuthorisationTokenType(element);
                }
            }
            Optional<string> identifier = default;
            string type = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("identifier"))
                {
                    identifier = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"))
                {
                    type = property.Value.GetString();
                    continue;
                }
            }
            return new CredentialsIdentifierResponseType(identifier.Value, type);
        }
    }
}
