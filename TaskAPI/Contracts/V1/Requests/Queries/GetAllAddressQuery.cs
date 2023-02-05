namespace TaskAPI.Contracts.V1.Requests.Queries
{
    public class GetAllAddressQuery
    { 
        public string Filter { get; set; }
        public GetAllAddressQuery()
        {
            Filter= string.Empty;
        }
        public GetAllAddressQuery(string filter)
        {
            Filter = filter;  
        }
    }
}
