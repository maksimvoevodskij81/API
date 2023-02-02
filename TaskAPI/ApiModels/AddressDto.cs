namespace TaskAPI.ApiModels
{
    public class AddressDto
    {
        public int AddressId { get; private set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string StreetLine { get; set; }
        public string HouseNumber { get; set; }


    }
}
