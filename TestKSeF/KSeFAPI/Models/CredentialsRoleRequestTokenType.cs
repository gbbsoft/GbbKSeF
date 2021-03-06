// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace KSeFAPI.Models
{
    /// <summary> The CredentialsRoleRequestTokenType. </summary>
    public partial class CredentialsRoleRequestTokenType
    {
        /// <summary> Initializes a new instance of CredentialsRoleRequestTokenType. </summary>
        /// <param name="roleType"></param>
        /// <param name="roleDescription"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="roleDescription"/> is null. </exception>
        public CredentialsRoleRequestTokenType(CredentialsRoleRequestTokenTypeRoleType roleType, string roleDescription)
        {
            if (roleDescription == null)
            {
                throw new ArgumentNullException(nameof(roleDescription));
            }

            RoleType = roleType;
            RoleDescription = roleDescription;
        }

        /// <summary> Gets the role type. </summary>
        public CredentialsRoleRequestTokenTypeRoleType RoleType { get; }
        /// <summary> Gets the role description. </summary>
        public string RoleDescription { get; }
    }
}
