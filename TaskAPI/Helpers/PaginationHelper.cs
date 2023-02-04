using BackendData.DomainModel;
using TaskAPI.Contracts.V1.Requests.Query;
using TaskAPI.Contracts.V1.Responses;
using TaskAPI.Interfaces;

namespace TaskAPI.Helpers
{
    public class PaginationHelper<T>
    {

        public static PageResponse<T> CreatePaginatedResponse(IUriService uriService,
            PaginationFilter paginationFilter, List<T> response)
        {
            var nextPage = paginationFilter.PageNumber >= 1 ?
                uriService.GetAllAddressesUri(new PaginationQuery(paginationFilter.PageNumber + 1, paginationFilter.PageSize))
                .ToString() : null;
            var previousPage = paginationFilter.PageNumber - 1 >= 1 ?
                uriService.GetAllAddressesUri(new PaginationQuery(paginationFilter.PageNumber - 1, paginationFilter.PageSize))
               .ToString() : null;
           return new PageResponse<T>
           {
                Data = response,
                PageNumber = paginationFilter.PageNumber >= 1 ? paginationFilter.PageNumber : null,
                PageSize = paginationFilter.PageSize >= 1 ? paginationFilter.PageSize : null,
                NextPage = response.Any() ? nextPage : null,
                PreviousPage = previousPage
           };
        }

    }
}
