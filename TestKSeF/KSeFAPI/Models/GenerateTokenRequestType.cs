// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace KSeFAPI.Models
{
    /// <summary> The GenerateTokenRequestType. </summary>
    public partial class GenerateTokenRequestType
    {
        /// <summary> Initializes a new instance of GenerateTokenRequestType. </summary>
        /// <param name="description"></param>
        /// <param name="credentialsRoleList"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="description"/> or <paramref name="credentialsRoleList"/> is null. </exception>
        public GenerateTokenRequestType(string description, IEnumerable<CredentialsRoleRequestTokenType> credentialsRoleList)
        {
            if (description == null)
            {
                throw new ArgumentNullException(nameof(description));
            }
            if (credentialsRoleList == null)
            {
                throw new ArgumentNullException(nameof(credentialsRoleList));
            }

            Description = description;
            CredentialsRoleList = credentialsRoleList.ToList();
        }

        /// <summary> Gets the description. </summary>
        public string Description { get; }
        /// <summary> Gets the credentials role list. </summary>
        public IList<CredentialsRoleRequestTokenType> CredentialsRoleList { get; }
    }
}
