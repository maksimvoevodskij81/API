namespace TaskAPI.ApiModels
{
    public class AddressDto
    {
        public int AddressId { get; private set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }

        public AddressDto()
        {

        }
        public AddressDto(int addressId, string city, string zipCode, string country, string street, int houseNumber)
        {
            AddressId= addressId;
            City= city;
            ZipCode= zipCode;
            Country= country;
            Street= street;
            HouseNumber = houseNumber;
        }

    }
}
