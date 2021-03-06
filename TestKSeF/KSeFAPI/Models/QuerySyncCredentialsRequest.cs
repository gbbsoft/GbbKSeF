// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace KSeFAPI.Models
{
    /// <summary> The QuerySyncCredentialsRequest. </summary>
    public partial class QuerySyncCredentialsRequest
    {
        /// <summary> Initializes a new instance of QuerySyncCredentialsRequest. </summary>
        /// <param name="queryCriteria"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="queryCriteria"/> is null. </exception>
        public QuerySyncCredentialsRequest(QueryCriteriaCredentialsType queryCriteria)
        {
            if (queryCriteria == null)
            {
                throw new ArgumentNullException(nameof(queryCriteria));
            }

            QueryCriteria = queryCriteria;
        }

        /// <summary> Gets the query criteria. </summary>
        public QueryCriteriaCredentialsType QueryCriteria { get; }
    }
}
