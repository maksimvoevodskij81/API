using Microsoft.AspNetCore.WebUtilities;
using TaskAPI.Contracts.V1;
using TaskAPI.Contracts.V1.Requests.Query;
using TaskAPI.Interfaces;

namespace TaskAPI.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;
        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetAddressUri(string addressId)
        {
            return new Uri(_baseUri + ApiRouts.Addresses.Get.Replace("{addressId}", addressId));
        }

        public Uri GetAllAddressesUri(PaginationQuery pagination)
        {
            var uri = new Uri(_baseUri);
            if (pagination == null)
                return uri;

            var modifieUri = QueryHelpers.AddQueryString(_baseUri, "pageNumber", pagination.PageNumber.ToString());
            modifieUri = QueryHelpers.AddQueryString(modifieUri, "pageSize", pagination.PageSize.ToString());
            return new Uri(modifieUri);
        }
    }
}
