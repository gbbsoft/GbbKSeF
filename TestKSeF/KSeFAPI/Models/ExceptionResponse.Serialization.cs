// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace KSeFAPI.Models
{
    public partial class ExceptionResponse
    {
        internal static ExceptionResponse DeserializeExceptionResponse(JsonElement element)
        {
            ExceptionType exception = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("exception"))
                {
                    exception = ExceptionType.DeserializeExceptionType(property.Value);
                    continue;
                }
            }
            return new ExceptionResponse(exception);
        }
    }
}
