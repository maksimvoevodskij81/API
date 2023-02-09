namespace TaskAPI.Contracts.V1.Requests.Queries
{
    public class GetAllSearchQuery
    {
        public string SearchName { get; set; }
        public GetAllSearchQuery()
        {
            SearchName = string.Empty;
        }
        public GetAllSearchQuery(string filter)
        {
            SearchName = filter;
        }
    }
}
