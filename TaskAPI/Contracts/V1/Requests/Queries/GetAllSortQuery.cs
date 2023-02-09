namespace TaskAPI.Contracts.V1.Requests.Queries
{
    public class GetAllSortQuery
    {
        public string Sort { get; set; }
        public string Column { get; set; }
        public GetAllSortQuery()
        {
            Sort = "ASC";
            Column = "City";
        }
        public GetAllSortQuery(string sort, string columnId)
        {
            Sort = sort;
            Column = columnId;
        }
    }
}
