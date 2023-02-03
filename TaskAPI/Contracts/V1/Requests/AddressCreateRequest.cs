namespace TaskAPI.Contracts.V1.Requests
{
    public class AddressCreateRequest
    {
        public int? Id { get; internal set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public string? Country { get; set; }
        public string? Street { get; set; }
        public int? HouseNumber { get; set; }
        
    }
}
