namespace TaskAPI.ApiModels
{
    public class AddressDto
    {
        public int? Id { get; private set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public string? Country { get; set; }
        public string? Street { get; set; }
        public int? HouseNumber { get; set; }

        public AddressDto()
        {

        }
        public AddressDto(int addressId, string country, string city, string street, int houseNumber, string zipCode)
        {
            Id = addressId;
            City = city;
            ZipCode = zipCode;
            Country = country;
            Street = street;
            HouseNumber = houseNumber;
        }

    }
}
