// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace KSeFAPI.Models
{
    /// <summary> The ExceptionDetailType. </summary>
    public partial class ExceptionDetailType
    {
        /// <summary> Initializes a new instance of ExceptionDetailType. </summary>
        /// <param name="exceptionCode"></param>
        /// <param name="exceptionDescription"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="exceptionDescription"/> is null. </exception>
        internal ExceptionDetailType(int exceptionCode, string exceptionDescription)
        {
            if (exceptionDescription == null)
            {
                throw new ArgumentNullException(nameof(exceptionDescription));
            }

            ExceptionCode = exceptionCode;
            ExceptionDescription = exceptionDescription;
        }

        /// <summary> Gets the exception code. </summary>
        public int ExceptionCode { get; }
        /// <summary> Gets the exception description. </summary>
        public string ExceptionDescription { get; }
    }
}
