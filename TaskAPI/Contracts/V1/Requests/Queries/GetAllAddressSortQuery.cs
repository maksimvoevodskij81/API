namespace TaskAPI.Contracts.V1.Requests.Queries
{
    public class GetAllAddressSortQuery
    {
        public string Sort { get; set; }
        public string ColumnId { get; set; }
        public GetAllAddressSortQuery()
        {
            Sort = "ASC";
            ColumnId = "City";
        }
        public GetAllAddressSortQuery(string sort, string columnId)
        {
            Sort = sort;
            ColumnId = columnId;
        }
    }
}
