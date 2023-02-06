using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace TaskAPI.Contracts.V1.Requests.Queries
{
    public class DistanceCalculateQuery
    {
        public string OriginAddresses { get; set; } = string.Empty;

        public string DestinationAddresses { get; set; } = string.Empty;
    }
}
