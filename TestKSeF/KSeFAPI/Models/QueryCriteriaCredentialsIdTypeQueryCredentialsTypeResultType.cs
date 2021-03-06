// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace KSeFAPI.Models
{
    /// <summary> The QueryCriteriaCredentialsIdTypeQueryCredentialsTypeResultType. </summary>
    public readonly partial struct QueryCriteriaCredentialsIdTypeQueryCredentialsTypeResultType : IEquatable<QueryCriteriaCredentialsIdTypeQueryCredentialsTypeResultType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="QueryCriteriaCredentialsIdTypeQueryCredentialsTypeResultType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public QueryCriteriaCredentialsIdTypeQueryCredentialsTypeResultType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AllValue = "all";
        private const string StandardValue = "standard";
        private const string TokenValue = "token";

        /// <summary> all. </summary>
        public static QueryCriteriaCredentialsIdTypeQueryCredentialsTypeResultType All { get; } = new QueryCriteriaCredentialsIdTypeQueryCredentialsTypeResultType(AllValue);
        /// <summary> standard. </summary>
        public static QueryCriteriaCredentialsIdTypeQueryCredentialsTypeResultType Standard { get; } = new QueryCriteriaCredentialsIdTypeQueryCredentialsTypeResultType(StandardValue);
        /// <summary> token. </summary>
        public static QueryCriteriaCredentialsIdTypeQueryCredentialsTypeResultType Token { get; } = new QueryCriteriaCredentialsIdTypeQueryCredentialsTypeResultType(TokenValue);
        /// <summary> Determines if two <see cref="QueryCriteriaCredentialsIdTypeQueryCredentialsTypeResultType"/> values are the same. </summary>
        public static bool operator ==(QueryCriteriaCredentialsIdTypeQueryCredentialsTypeResultType left, QueryCriteriaCredentialsIdTypeQueryCredentialsTypeResultType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="QueryCriteriaCredentialsIdTypeQueryCredentialsTypeResultType"/> values are not the same. </summary>
        public static bool operator !=(QueryCriteriaCredentialsIdTypeQueryCredentialsTypeResultType left, QueryCriteriaCredentialsIdTypeQueryCredentialsTypeResultType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="QueryCriteriaCredentialsIdTypeQueryCredentialsTypeResultType"/>. </summary>
        public static implicit operator QueryCriteriaCredentialsIdTypeQueryCredentialsTypeResultType(string value) => new QueryCriteriaCredentialsIdTypeQueryCredentialsTypeResultType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is QueryCriteriaCredentialsIdTypeQueryCredentialsTypeResultType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(QueryCriteriaCredentialsIdTypeQueryCredentialsTypeResultType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
