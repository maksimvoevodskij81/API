namespace TaskAPI.Contracts.V1.Requests.Queries
{
    public class GetAllAddressQuery
    { 
        public string Search { get; set; }
        public GetAllAddressQuery()
        {
            Search= string.Empty;
        }
        public GetAllAddressQuery(string filter)
        {
            Search = filter;  
        }
    }
}
