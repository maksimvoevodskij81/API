using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Web;
using TaskAPI.Options;
using TaskAPI.Contracts.V1.Responses;

namespace TaskAPI.Services
{
    public class GoogleDistanceMatrixApi
    {
        private string Key { get; set; }
        private string Url { get; set; }

        private string[] OriginAddresses { get; set; }

        private string[] DestinationAddresses { get; set; }

        public GoogleDistanceMatrixApi(string[] originAddresses, 
            string[] destinationAddresses, GoogleMapSettings googleMapSettings)
        {
            OriginAddresses = originAddresses;
            DestinationAddresses = destinationAddresses;

            if (string.IsNullOrEmpty(googleMapSettings.GoogleDistanceMatrixApiUrl))
            {
                throw new Exception("GoogleDistanceMatrixApiUrl is not set in AppSettings.");
            }
            Url = googleMapSettings.GoogleDistanceMatrixApiUrl;

            if (string.IsNullOrEmpty(googleMapSettings.GoogleDistanceMatrixApiKey))
            {
                throw new Exception("GoogleDistanceMatrixApiKey is not set in AppSettings.");
            }
            Key = googleMapSettings.GoogleDistanceMatrixApiKey;
        }

        public async Task<DistanseCalculationResponse> GetResponse()
        {
            using (var client = new HttpClient())
            {
                var uri = new Uri(GetRequestUrl());

                HttpResponseMessage response = await client.GetAsync(uri);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("GoogleDistanceMatrixApi failed with status code: " + response.StatusCode);
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<DistanseCalculationResponse>(content);
                }
            }
        }

        private string GetRequestUrl()
        {
            OriginAddresses = OriginAddresses.Select(HttpUtility.UrlEncode).ToArray();
            var origins = string.Join("|", OriginAddresses);
            DestinationAddresses = DestinationAddresses.Select(HttpUtility.UrlEncode).ToArray();
            var destinations = string.Join("|", DestinationAddresses);
            return $"{Url}?origins={origins}&destinations={destinations}&key={Key}";
        }
    }
}
