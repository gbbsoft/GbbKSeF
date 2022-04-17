// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace KSeFAPI.Models
{
    /// <summary> The QueryInvoiceAsyncStatusResponseDivisionType. </summary>
    public readonly partial struct QueryInvoiceAsyncStatusResponseDivisionType : IEquatable<QueryInvoiceAsyncStatusResponseDivisionType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="QueryInvoiceAsyncStatusResponseDivisionType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public QueryInvoiceAsyncStatusResponseDivisionType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string HourValue = "hour";
        private const string DayValue = "day";
        private const string WeekValue = "week";
        private const string MonthValue = "month";
        private const string YearValue = "year";

        /// <summary> hour. </summary>
        public static QueryInvoiceAsyncStatusResponseDivisionType Hour { get; } = new QueryInvoiceAsyncStatusResponseDivisionType(HourValue);
        /// <summary> day. </summary>
        public static QueryInvoiceAsyncStatusResponseDivisionType Day { get; } = new QueryInvoiceAsyncStatusResponseDivisionType(DayValue);
        /// <summary> week. </summary>
        public static QueryInvoiceAsyncStatusResponseDivisionType Week { get; } = new QueryInvoiceAsyncStatusResponseDivisionType(WeekValue);
        /// <summary> month. </summary>
        public static QueryInvoiceAsyncStatusResponseDivisionType Month { get; } = new QueryInvoiceAsyncStatusResponseDivisionType(MonthValue);
        /// <summary> year. </summary>
        public static QueryInvoiceAsyncStatusResponseDivisionType Year { get; } = new QueryInvoiceAsyncStatusResponseDivisionType(YearValue);
        /// <summary> Determines if two <see cref="QueryInvoiceAsyncStatusResponseDivisionType"/> values are the same. </summary>
        public static bool operator ==(QueryInvoiceAsyncStatusResponseDivisionType left, QueryInvoiceAsyncStatusResponseDivisionType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="QueryInvoiceAsyncStatusResponseDivisionType"/> values are not the same. </summary>
        public static bool operator !=(QueryInvoiceAsyncStatusResponseDivisionType left, QueryInvoiceAsyncStatusResponseDivisionType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="QueryInvoiceAsyncStatusResponseDivisionType"/>. </summary>
        public static implicit operator QueryInvoiceAsyncStatusResponseDivisionType(string value) => new QueryInvoiceAsyncStatusResponseDivisionType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is QueryInvoiceAsyncStatusResponseDivisionType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(QueryInvoiceAsyncStatusResponseDivisionType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}