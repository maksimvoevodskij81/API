using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace TaskAPI.Contracts.V1.Requests.Queries
{
    public class DistanceCalculateQuery
    {
        [JsonProperty(PropertyName = "origin_addresses")]
        public string OriginAddresses { get; set; }

        [JsonProperty(PropertyName = "destination_addresses")]
        public string DestinationAddresses { get; set; }
    }
}
