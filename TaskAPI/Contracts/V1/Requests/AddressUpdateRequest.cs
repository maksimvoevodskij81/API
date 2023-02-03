namespace TaskAPI.Contracts.V1.Requests
{
    public class AddressUpdateRequest 
    {
        public int? Id { get; internal set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public string? Country { get; set; }
        public string? Street { get; set; }
        public string? HouseNumber { get; set; }
    }
}
