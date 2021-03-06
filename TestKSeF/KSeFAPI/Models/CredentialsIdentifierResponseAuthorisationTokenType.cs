// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace KSeFAPI.Models
{
    /// <summary> The CredentialsIdentifierResponseAuthorisationTokenType. </summary>
    public partial class CredentialsIdentifierResponseAuthorisationTokenType : CredentialsIdentifierResponseType
    {
        /// <summary> Initializes a new instance of CredentialsIdentifierResponseAuthorisationTokenType. </summary>
        internal CredentialsIdentifierResponseAuthorisationTokenType()
        {
            Type = "token";
        }

        /// <summary> Initializes a new instance of CredentialsIdentifierResponseAuthorisationTokenType. </summary>
        /// <param name="identifier"></param>
        /// <param name="type"></param>
        internal CredentialsIdentifierResponseAuthorisationTokenType(string identifier, string type) : base(identifier, type)
        {
            Type = type ?? "token";
        }
    }
}
