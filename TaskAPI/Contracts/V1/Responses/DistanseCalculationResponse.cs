using Newtonsoft.Json;

namespace TaskAPI.Contracts.V1.Responses
{
    public class DistanseCalculationResponse
    {
        public string Status { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "origin_addresses")]
        public string[]? OriginAddresses { get; set; }

        [JsonProperty(PropertyName = "destination_addresses")]
        public string[]? DestinationAddresses { get; set; }

        public Row[]? Rows { get; set; }
        public class Data
        {
            public int Value { get; set; }
            public string Text { get; set; } = string.Empty;
        }
        public class Element
        {
            public string Status { get; set; } = string.Empty;
            public Data? Duration { get; set; }
            public Data? Distance { get; set; }
        }

        public class Row
        {
            public Element[]? Elements { get; set; }
        }
    }
}
